namespace lvl2.Models
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StudentId { get; set; }
        public string Group { get; set; }

        public Student(string lastName, string firstName, string studentId, string group)
        {
            LastName = lastName;
            FirstName = firstName;
            StudentId = studentId;
            Group = group;
        }

        public override string ToString()
        {
            return $"| {Group,-7} | {StudentId,-10} | {LastName,-12} {FirstName,-10} |";
        }
    }
}