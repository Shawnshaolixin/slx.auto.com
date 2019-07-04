namespace StackTraining
{
    public abstract class Person
    {
        public Person(string name, int condition)
        {
            this.Name = name;
            this.Condition = condition;
        }
        public string Name { get; set; }
        public int Condition { get; set; }
        public abstract void GetPartner(Person p);
    }
}
