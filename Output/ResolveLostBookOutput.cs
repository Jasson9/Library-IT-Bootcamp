
namespace Library.Output
{
    public class ResolveLostBookOutput
    {
        public int status { get; set; }
        public string message { get; set; }

        public ResolveLostBookOutput(){
            status = 200;
            message = "ok";
        }

    }
}
