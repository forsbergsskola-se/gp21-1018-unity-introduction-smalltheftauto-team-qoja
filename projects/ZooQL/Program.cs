using System;

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

    public class Zoo<T> where T:Animal
    {
        private T[] _arrayT = {};
        public void AddAnimal(T t)
        {
            Array.Resize(ref _arrayT, _arrayT.Length + 1);
            _arrayT[^1] = t;
            //foreach (var VARIABLE in _arrayT) Console.WriteLine(VARIABLE);
        }

        public bool HasAnimal<Tcheck>() where Tcheck:T
        {
            foreach (var item in _arrayT)
            {
                if (item is Tcheck) return true;
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
