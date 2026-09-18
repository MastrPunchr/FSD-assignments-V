namespace temp;

public abstract class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }

    public Employee(string name, int id)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be empty");
        
        Name = name;
        ID = id;
    }

    public abstract decimal CalculatePay();

    public override string ToString()
    {
        return $"Name: {Name}   ID: {ID}    Salary: {CalculatePay():C}";
    }
}

public class SalariedEmployee : Employee
{
    private readonly decimal _annualSalary;
    public SalariedEmployee(string name, decimal salary, int id) : base(name, id)
    {
        _annualSalary = salary;
    }

    public override decimal CalculatePay()
    { 
        return _annualSalary / 26m;
    }
}

public class HourlyEmployee : Employee
{
    private readonly decimal _rate;
    private readonly decimal _hours;
    public HourlyEmployee(string name, decimal rate, decimal hours, int id) : base(name, id)
    {
        if (hours <= 0 || rate <= 0 )
            throw new ArgumentException("no values can be null or zero");
        _rate = rate; 
        _hours = hours;
    }

    public override decimal CalculatePay()
    {
        return _hours <= 40 ? _rate * _hours : _rate * 40 + _rate * 1.5m * (_hours - 40);
    }
}

public class Intern : Employee
{
    private readonly decimal _stipend;
    public Intern(string name, int id, decimal stipend) : base(name, id)
    {
        _stipend = stipend;
    }

    public override decimal CalculatePay()
    {
        return _stipend;
    }
}