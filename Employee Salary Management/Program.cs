using System;

namespace DemoMid2
{
    //cline program
    class Program
    {
        static void Main(string[] args)
        {
            // create derived-class objects
            SalariedEmployee salariedEmployee = new SalariedEmployee("Mohaiminul", "Islam", "2017490036", 800.00M);
            HourlyEmployee hourlyEmployee = new HourlyEmployee("Kasfiya","Lija", "12345678", 60.0M, 20.0M);
            CommissionEmployee commissionEmployee = new CommissionEmployee("Nusrat", "Keya", "201900587", 10000.00M, .06M);
            Console.WriteLine("Employees processed individually:\n");
            Console.WriteLine("{0}\nearned: {1:C}\n",
                salariedEmployee, salariedEmployee.Earnings());
            Console.WriteLine("{0}\nearned: {1:C}\n",
                hourlyEmployee, hourlyEmployee.Earnings());
            Console.WriteLine("{0}\nearned: {1:C}\n",
                commissionEmployee, commissionEmployee.Earnings());
            // create four-element Employee array
            Employee[] employees = new Employee[4];
            // initialize array with Employees of derived types
            employees[0] = salariedEmployee;
            employees[1] = hourlyEmployee;
            employees[2] = commissionEmployee;
            Console.Read();
        } // end Main
    } // end class PayrollSystemTest
      // Employee abstract base class.
    public abstract class Employee
    {// read-only property that gets employee's first name
        public string FirstName { get; private set; }
        // read-only property that gets employee's last name
        public string LastName { get; private set; }
        // read-only property that gets employee's social security number
        public string EmployeeIDnumber { get; private set; }
        // three-parameter constructor
        public Employee(string first, string last, string id)
        {
            FirstName = first;
            LastName = last;
            EmployeeIDnumber = id;
        } // end three-parameter Employee constructor
          // return string representation of Employee object, using properties
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}", FirstName, LastName, EmployeeIDnumber);
        } // end method ToString
        // abstract method overridden by derived classes
    } // end abstract class Employee
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;
        // four-parameter constructor
        public SalariedEmployee(string first, string last, string ssn, decimal salary) : base(first, last, ssn)
        {
            WeeklySalary = salary; // validate salary via property
        } // end four-parameter SalariedEmployee constructor
          // property that gets and sets salaried employee's salary
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            } // end get
            set
            {
                if (value >= 0) // validation
                    weeklySalary = value;
                else
                    throw new ArgumentOutOfRangeException("WeeklySalary", value, "WeeklySalary must be >= 0");
            } // end set
        } // end property WeeklySalary
        // calculate earnings; override abstract method Earnings in Employee
        public decimal Earnings()
        {
            return WeeklySalary;
        } // end method Earnings
        // return string representation of SalariedEmployee object
        public override string ToString()
        {
            return string.Format("salaried employee: {0}\n{1}: {2:C}",
            base.ToString(), "weekly salary", WeeklySalary);
        } // end method ToString
    } // end class SalariedEmployee
    public class HourlyEmployee : Employee
    {
        private decimal wage; // wage per hour
        private decimal hours; // hours worked for the week
                               // five-parameter constructor
        public HourlyEmployee(string first, string last, string ssn, decimal hourlyWage, decimal hoursWorked) : base(first, last, ssn)
        {
            Wage = hourlyWage; // validate hourly wage via property
            Hours = hoursWorked; // validate hours worked via property
        } // end five-parameter HourlyEmployee constructor
          // property that gets and sets hourly employee's wage
        public decimal Wage
        {
            get
            {
                return wage;
            } // end get
            set
            {
                if (value >= 0) // validation
                    wage = value;
                else
                    throw new ArgumentOutOfRangeException("Wage", value, "Wage must be >= 0");
            } // end set
        } // end property Wage
          // property that gets and sets hourly employee's hours
        public decimal Hours
        {
            get
            {
                return hours;
            } // end get
            set
            {
                if (value >= 0 && value <= 168) // validation
                    hours = value;
                else throw new ArgumentOutOfRangeException("Hours", value, "Hours must be >= 0 and <= 168");
            } // end set
        } // end property Hours
        // calculate earnings; override Employee’s abstract method Earnings
        public decimal Earnings()
        {
            return Wage * Hours;
        } // end method Earnings
        // return string representation of HourlyEmployee object
        public override string ToString()
        {
            return string.Format("hourly employee: {0}\n{1}: {2:C}; {3}: {4:F2}", base.ToString(), "hourly wage", Wage, "hours worked", Hours);
        } // end method ToString
    }// end class HourlyEmployee
    public class CommissionEmployee : Employee
    {
        private decimal grossSales; // gross weekly sales
        private decimal commissionRate; // commission percentage
                                        // five-parameter constructor
        public CommissionEmployee(string first, string last, string ssn, decimal sales, decimal rate) : base(first, last, ssn)
        {
            GrossSales = sales; // validate gross sales via property
            CommissionRate = rate; // validate commission rate via property
        } // end five-parameter CommissionEmployee constructor
          // property that gets and sets commission employee's gross sales
        public decimal GrossSales
        {
            get
            {
                return grossSales;
            } // end get
            set
            {
                if (value >= 0)
                    grossSales = value;
                else throw new ArgumentOutOfRangeException("GrossSales", value, "GrossSales must be >= 0");
            } // end set
        } // end property GrossSales
          // property that gets and sets commission employee's commission rate
        public decimal CommissionRate
        {
            get
            {
                return commissionRate;
            } // end get
            set
            {
                if (value > 0 && value < 1)
                    commissionRate = value;
                else
                    throw new ArgumentOutOfRangeException("CommissionRate", value, "CommissionRate must be > 0 and < 1");
            } // end set
        } // end property CommissionRate
        // calculate earnings; override abstract method Earnings in Employee
        public decimal Earnings()
        {
            return CommissionRate * GrossSales;
        } // end method Earnings
        // return string representation of CommissionEmployee object
        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}","commission employee", base.ToString(), "gross sales", GrossSales, "commission rate", CommissionRate);
        } // end method ToString
    } // end class CommissionEmployee
  }