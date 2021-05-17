using System;

namespace ConsoleApp2
{ 
    class Account
    {
        public float sum { get; set; }
        public int number { get; set; }
        public DateTime date { get; set; }

        public Account(float sum, int number,DateTime date)
        {
            this.sum = sum;
            this.number = number;
            this.date = date;
        }
        public void Sum()
        {
            Console.WriteLine(sum);
        }
     public virtual void Date()
        {
           Console.WriteLine(date.ToLocalTime());
        }

        public void addPercentage(float value, DateTime endDate)
        {
            int years = endDate.Year - this.date.Year;


            for (int i = 0; i < years; i++)
            {
                sum += (sum * (value / 100));
            }

            Console.WriteLine($"Total sum after {years} years adding {value} % is: {sum}");
        }
    }


    class IndividualAccount : Account
    {
        public string acctype { get; set; }
        public IndividualAccount(float sum, int number, DateTime date, string acctype) : base(sum,number,date)
            {
            this.acctype=acctype;
            }
        public virtual void withdraw(float amount)
            {
                sum = sum - amount; 
            }
    }

    class EntityAccount : Account 
    {
        public EntityAccount(float sum, int number, DateTime date) : base(sum, number, date)
        {
            this.sum = sum;
            this.number = number;
            this.date = date;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2020, 05, 17);
            DateTime indEndDate = new DateTime(2022, 05, 17);
            DateTime entityEndDate = new DateTime(2026, 05, 17);

            IndividualAccount acc = new IndividualAccount(100, 5, date, "Smth");
            acc.addPercentage(10, indEndDate);

            EntityAccount entAcc = new EntityAccount(1000, 515, date);
            entAcc.addPercentage(5, entityEndDate);

        }
    }
}
