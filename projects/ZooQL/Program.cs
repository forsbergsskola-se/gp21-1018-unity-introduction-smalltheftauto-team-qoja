using System;
using System.Collections.Generic;

namespace ZooQL
{
    public class Animal
    {
        public override string ToString() => GetType().Name;
    }
    public class Mammal:Animal{}
    public class Bear:Mammal{}
    public class Donkey:Mammal{}
    public class Lion:Mammal{}
    public class Fish:Animal{}
    public class Salmon:Fish{}
    public class Clownfish:Fish{}
    public class Student{}

    public class Zoo<TAnimal> where TAnimal:Animal
    {
        //private TAnimal[] _arrayT = {};
        //private TAnimal[] animals = Array.Empty<TAnimal>();
        List<TAnimal> animals = new List<TAnimal>();
        public void AddAnimal(TAnimal animal)
        {
            //Array.Resize(ref animals, animals.Length + 1);
            //animals[^1] = animal;
            //foreach (var VARIABLE in _arrayT) Console.WriteLine(VARIABLE);
            this.animals.Add((animal));
        }

        public bool HasAnimal<TCheck>() where TCheck:TAnimal
        {
            foreach (var item in animals)
            {
                if (item is TCheck) return true;
            }
            return false;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
             Zoo<Fish> fishZoo = new Zoo<Fish>();
             fishZoo.AddAnimal(new Fish());
             fishZoo.AddAnimal(new Clownfish());
             Zoo<Animal> animalZoo = new Zoo<Animal>();
             animalZoo.AddAnimal(new Fish());
             animalZoo.AddAnimal(new Clownfish());
             animalZoo.AddAnimal(new Lion());
             animalZoo.AddAnimal(new Donkey());
             Zoo<Lion> lionZoo = new Zoo<Lion>();
             animalZoo.AddAnimal(new Lion());
             animalZoo.AddAnimal(new Lion());
             animalZoo.AddAnimal(new Lion());
             
             Console.WriteLine("This should be True: "+fishZoo.HasAnimal<Clownfish>());
        }
    }
}
