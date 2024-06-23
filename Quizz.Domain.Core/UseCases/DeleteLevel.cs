using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases
{
    public class DeleteLevel: IDeleteLevel
    {
        private ILevelRepository levelRepository;
        private List<ICheckRuleLevel<LevelRequest>> rules;

        public DeleteLevel(ILevelRepository levelRepository, List<ICheckRuleLevel<LevelRequest>> rules)
        {
            this.levelRepository = levelRepository;
            this.rules = rules;
        }

        public async Task<LevelResponse> Handle(LevelRequest levelRequest)
        {
            if (CheckIfLevelIsUsed(levelRequest))
            {
                levelRequest.IsActive = false;
                await levelRepository.Update(levelRequest);
                return new LevelResponse()
                {
                    Id = (long)levelRequest.Id,
                    Content = levelRequest.Content,
                    IsActive = false,
                };
            }

            try
            {
                // Attempt to delete the level
                bool success = await levelRepository.DeleteLevel(levelRequest);

                if (!success)
                {
                    return new LevelResponse
                    {
                        Id = -1,
                        Content = "Level could not be deleted because it does not exist."
                    };
                }

                // Return success response
                return new LevelResponse
                {
                    Id = (long)levelRequest.Id,
                    Content = "Level deleted successfully."
                };
            }
            catch (ArgumentNullException ex)
            {
                // Handle the case where levelRequest is null
                return new LevelResponse
                {
                    Id = -1,
                    Content = $"ArgumentNullException: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                return new LevelResponse
                {
                    Id = -1,
                    Content = $"An error occurred: {ex.Message}"
                };
            }
            return null;

            #region local methods

            bool CheckIfLevelIsUsed(LevelRequest levelRequest)
            {
                return levelRepository.levelIsUsed(levelRequest).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            #endregion
        }
    }
}