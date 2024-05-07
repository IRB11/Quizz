namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckAvailabilityOfQuizzNumber
    {

        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckAvailabilityOfQuizzNumber()
        {

        }


        public string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
