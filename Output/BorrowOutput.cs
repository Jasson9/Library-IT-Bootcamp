
namespace Library.Output
{
    public class BorrowOutput
    {
        public int status { get; set; }
        public string message { get; set; }

        public BorrowOutput(){
            status = 200;
            message = "ok";
        }

    }
}
