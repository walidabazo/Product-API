namespace Product.API.Errors
{
    public class BaseCommonResponse
    {
        public BaseCommonResponse(int stuatusCode, string message = null)
        {
            StuatusCode = stuatusCode;
            Message = message ?? DefaultMessageForSatusCode(stuatusCode);
        }
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

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
