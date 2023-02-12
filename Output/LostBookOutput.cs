
namespace Library.Output
{
    public class LostBookOutput
    {
        public int status { get; set; }
        public string message { get; set; }

        public LostBookOutput(){
            status = 200;
            message = "ok";
        }

    }
}
