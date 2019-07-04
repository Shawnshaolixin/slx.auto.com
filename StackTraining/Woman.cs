namespace StackTraining
{
    public class Woman : Person
    {
        public Woman(string name, int condition) : base(name, condition)
        {

        }
        public override void GetPartner(Person person)
        {
            if (person is Woman)
            {
                System.Console.WriteLine("同性不可以");
            }
            else
            {
                if (person.Condition == this.Condition)
                {
                    System.Console.WriteLine($"{person.Name}和{this.Name} 绝配");
                }
            }
        }


    }
}
