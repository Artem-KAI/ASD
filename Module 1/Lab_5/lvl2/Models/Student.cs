namespace lvl2.Models
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int RecordBookNumber { get; set; }
        public bool HasMilitaryTraining { get; set; }

        public Student(string lastName, string firstName, string middleName,
            int recordBookNumber, bool hasMilitaryTraining)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            RecordBookNumber = recordBookNumber;
            HasMilitaryTraining = hasMilitaryTraining;
        }

        public override string ToString()
        {
            string military = HasMilitaryTraining ? "Так" : "Ні";
            return $"| {FirstName,-10} | {LastName,-12} | Заліковка: {RecordBookNumber,-5} | Військ. підг.: {military} |";
        }
    }
}