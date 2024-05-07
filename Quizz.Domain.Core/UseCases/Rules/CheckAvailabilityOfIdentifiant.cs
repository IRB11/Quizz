namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckAvailabilityOfIdentifiant 
    {

        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckAvailabilityOfIdentifiant()
        {

        }

        public string GetErrorMessage()
        {
            return errorMessage;
        }

    }
}
