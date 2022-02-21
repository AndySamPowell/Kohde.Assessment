namespace Kohde.Assessment
{
    public class Human : Animal, IHuman
    {
        
        public string Gender { get; set; }



        public override string ToString()
        {
            return Name;
        }


    }
}