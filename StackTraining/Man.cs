namespace StackTraining
{
    public class Man : Person
    {
        public Man(string name, int c) : base(name, c)
        {

        }
        public override void GetPartner(Person person)
        {
            if (person is Man)
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
