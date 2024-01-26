namespace Product.API.Errors
{
    public class BaseCommonResponse
    {
        public BaseCommonResponse(int stuatusCode, string message = null)
        {
            StuatusCode = stuatusCode;
            Message = message ?? DefaultMessageForSatusCode(stuatusCode);
        }

        private string DefaultMessageForSatusCode(int stuatusCode)
         => stuatusCode switch
         {
             400 => "bad request",
             401 => "not authorize",
             404 => "resource not found",
             500 => "server error",
             _ => null
         };


        public int StuatusCode { get; set; }
        public string Message { get; set; }
    }
}
