using System;

namespace OOPlesson;

public class Person
{
    string name;
    int age;

    public Person(string personName, int personAge)
    {
        this.name = personName;
        this.age = personAge;
    }
    public override string ToString()
    {
        return $"Name: {name}, Age: {age}";
    }
}
