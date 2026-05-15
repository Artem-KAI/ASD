namespace lvl3.Models
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Group { get; set; }

        public Student(string lastName, string firstName, string group)
        {
            LastName = lastName;
            FirstName = firstName;
            Group = group;
        }

        public override string ToString() => $"| {Group,-7} | {LastName,-12} {FirstName,-10} |";
    }
}