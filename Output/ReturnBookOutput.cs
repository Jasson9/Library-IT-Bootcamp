
namespace Library.Output
{
    public class ReturnBookOutput
    {
        public int status { get; set; }
        public string message { get; set; }

        public ReturnBookOutput(){
            status = 200;
            message = "ok";
        }

    }
}
