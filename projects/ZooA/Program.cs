using System;

namespace ZooA
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo<Fish> fishZoo = new Zoo<Fish>();
            fishZoo.AddAnimal(new Fish()); // OKAY
            fishZoo.AddAnimal(new Clownfish()); // OKAY
            
            Zoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.AddAnimal(new Fish()); // OKAY
            animalZoo.AddAnimal(new Clownfish()); // OKAY
            animalZoo.AddAnimal(new Lion()); // OKAY
            animalZoo.AddAnimal(new Donkey()); // OKAY
            
            Zoo<Lion> lionZoo = new Zoo<Lion>();
            animalZoo.AddAnimal(new Lion()); // OKAY
            animalZoo.AddAnimal(new Lion()); // OKAY
            animalZoo.AddAnimal(new Lion()); // OKAY
            
            //Zoo<Fish> fishZoo = new Zoo<Fish>();
            //fishZoo.AddAnimal(new Lion()); // ERROR!
            
            //Zoo<Salmon> salmonZoo = new Zoo<Salmon>();
            //salmonZoo.AddAnimal(new Fish()); // ERROR!


        }
    }

    class Animal
    {
        public override string ToString() => GetType().Name;
    }

    class Mamal : Animal
    {
        
    }

    class Bear : Mamal
    {
        
    }

    class  Lion : Mamal
    {
        
    }

    class Donkey: Mamal
    {
        
    }

    class Fish : Animal
    {
        
    }

    class Salmon: Fish
    {
        
    }

    class Clownfish : Fish
    {
        
    }

   

    class Zoo<T> where T : Animal
    {
        private T[] arrayT = { };

        public void AddAnimal(T tAnimal)
        {
            Array.Resize(ref arrayT, arrayT.Length+1);
            arrayT[arrayT.Length-1] = tAnimal;
        }

        public bool HasAnimal<T_>()
        {
            foreach (var item in arrayT)
            {
                if (item is T_) return true;
                
            }

            return false;
        }
    }

  
    
    
    
}
