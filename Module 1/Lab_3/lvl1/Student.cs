using System;

namespace lvl1;


public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public string Hobby { get; set; }

    public Student(string lastName, string firstName, int course, string studentId, string hobby)
    {
        LastName = lastName;
        FirstName = firstName;
        Course = course;
        StudentId = studentId;
        Hobby = hobby;
    }

    public override string ToString()
    {
        return $"{LastName,-15} {FirstName,-15} {Course,-6} {StudentId,-12} {Hobby,-10}";
    }
}
