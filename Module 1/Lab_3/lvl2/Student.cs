using System;

namespace lvl2;

public class Student
{
    public string LastName;
    public string FirstName;
    public int Course;
    public string StudentCard;
    public string Hobby;

    public Student(string lastName, string firstName, int course, string studentCard, string hobby)
    {
        LastName = lastName;
        FirstName = firstName;
        Course = course;
        StudentCard = studentCard;
        Hobby = hobby;
    }

    public override string ToString()
    {
        return $"{LastName,-15}{FirstName,-15}{Course,-8}{StudentCard,-12}{Hobby,-10}";
    }
}
