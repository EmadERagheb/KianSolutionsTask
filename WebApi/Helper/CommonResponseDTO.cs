namespace WebApi.Helper
{
    public class CommonResponseDTO
    {

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public string? Detail { get; set; }
        public CommonResponseDTO(int stateCode, string? message = default, string? detail = null)
        {
            StatusCode = stateCode;
            Message = message ?? GetDefaultMessage(stateCode);
            Detail = detail;
        }


        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created",
                204 => "Deleted",
                400 => "The provided data does not meet the validation requirements",
                401 => "Invalid credentials provided. Please log in with valid credentials to access this resource",
                402 => "Payment required. Please complete the payment process to access this resource.",
                403 => "you don't have permission to execute this method",
                404 => "The page or resource you requested does not exist",
                405 => "method not allowed",
                500 => "We're experiencing technical difficulties. Our team is working to resolve the issue as quickly as possible.",
                _ => "please try again later"

            };
        }
    }

}
