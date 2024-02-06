namespace Product.API.Errors
{
    public class ApiException : BaseCommonResponse
    {
        
        private readonly string details;
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public ApiException(int stuatusCode, string message = null,string Details=null) : base(stuatusCode, message)
        {
           
            details = Details;
        }
        public string Details { get;set; }

    }
}
