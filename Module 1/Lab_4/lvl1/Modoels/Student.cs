namespace lvl1.Modoels
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IdCard { get; set; }
        public string Group { get; set; }

        public Student(string lastName, string firstName, string idCard, string group)
        {
            LastName = lastName;
            FirstName = firstName;
            IdCard = idCard;
            Group = group;
        }

        public override string ToString()
        {
            return $"| {Group,-8} | {IdCard,-10} | {LastName,-12} {FirstName,-10} |";
        }
    }
}