namespace StackTraining
{
    public class Mediator
    {
        public Man Man { set; get; }
        public Woman Woman { set; get; }

        public void GetPartent(Person person)
        {
            if (person is Man)
            {
                this.Man = (Man)person;
            }
            else
            {
                this.Woman = (Woman)person;
            }
            if (Man.Condition == Woman.Condition)
            {
                System.Console.WriteLine($"{Man.Name}和{Woman.Name} 绝配");
            }
            else
            {
                System.Console.WriteLine($"{Man.Name}和{Woman.Name} 不合适");

            }
        }
    }
}
