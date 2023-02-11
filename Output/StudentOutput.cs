
namespace Library.Output
{
    public class StudentOutput
    {
        public List<Student> payload { get; set; }

        public StudentOutput(){
            payload = new List<Student>();
        }

    }
    public class Student
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public bool isBorrowing { get; set; }
        public bool isBlacklisted { get; set; }
    }

}
