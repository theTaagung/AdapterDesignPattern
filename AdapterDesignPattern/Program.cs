using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human john = new Human("Smith", "John");
            //PrintHumanName.Print(john);

            Animal tommy = new Animal("Tommy");
            //PrintHumanName.Print(tommy);

            PrintHumanName.Print(new AnimalToHumanAdapter(tommy));
        }
    }
    static class PrintHumanName
    {
        public static void Print(IHuman human)
        {
            Console.WriteLine(human.FName + '-' + human.LName);
        }
    }
    public interface IHuman
    {
        //string Name { get; set; }
        string FName { get; set; }
        string LName { get; set; }
    }

    public class Human : IHuman
    {      
        public Human(string Lname, string Fname)
        {
            LName = Lname;
            FName = Fname;
        }

        public string FName { get; set; }
        public string LName { get; set; }
       
    }

    public interface IAnimal
    {
        string AnimalName { get; set; }
    }

    public class Animal : IAnimal
    {
        public string AnimalName { get; set; }

        public Animal(string aName)
        {
            AnimalName = aName;
        }

    }

    public class AnimalToHumanAdapter : IHuman
    {
        private readonly IAnimal animal;

        public AnimalToHumanAdapter(IAnimal animal)
        {
            this.animal = animal;
        }

        public string FName {
            get { return animal.AnimalName; }
            set { animal.AnimalName = value; }
        }

        public string LName {
            get { return "No last name"; }
            set { animal.AnimalName = "No last name"; }
        }
    }


}
