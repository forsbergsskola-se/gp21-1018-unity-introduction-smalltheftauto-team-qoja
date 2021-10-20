using System;

namespace ZooOK
{

    public abstract class Animal
    {
        public override string ToString() => GetType().Name;
    }

     public abstract class Mammal : Animal {}

    public class Bear : Mammal {}
    public class Donkey : Mammal
    {
        
    }
    public class Lion : Mammal
    {
        
    }
    public abstract class Fish : Animal
    {
        
    }
    
    public class Salmon : Fish
    {
        
    }
    public class Clownfish : Fish
    {
        
    }

    public abstract class Student
    {
        
    }
    
    

    public class Zoo<TAnimal> where TAnimal : Animal // A zoo that doesnt yet have a type, but whatever we give it later, it must be of the inherited Animal.
    {

        private TAnimal[] AnimalArray = {};
       // public TAnimal[] animalArray = new []{};
       
        public void AddAnimal(TAnimal animal) //Method that takes animal of the not yet decided type(which has to be inherited from Animal)
        {
            //Store Animals in array.
            Array.Resize(ref AnimalArray, AnimalArray.Length+1); // The array gets rezised to add more animals.
           // TAnimal[] AnimalArray = new TAnimal[animal];
           AnimalArray[^1] = animal;

           //Array.Resize(ref array); has to be used.

        }

        public bool HasAnimal<TSpecies>() where TSpecies : TAnimal , new ()
        {
            foreach (var currentAnimal in AnimalArray) //i = 0; i < AnimalsInZoo; i++)
            {

                if (currentAnimal is TAnimal) return true;


            }

            return false;
        }

    }

    // public class Zoo<Fish> : Zoo 
    // {
    //     
    // }
    class Program
    {
        static void Main(string[] args)
        {
            Zoo<Fish> fishZoo = new Zoo<Fish>();
            Zoo<Mammal> mammalZoo = new Zoo<Mammal>();
            Zoo<Donkey> donkeyZoo = new Zoo<Donkey>();
            fishZoo.AddAnimal(new Clownfish());
            Zoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.AddAnimal(new Bear());
            fishZoo.HasAnimal<Clownfish>();
            //fishZoo.HasAnimal<Bear>();
            
            

           // Console.WriteLine(fishZoo.HasAnimal<Bear>());
           
            // Console.WriteLine(fishZoo.HasAnimal<Clownfish>());
            // Zoo<Animal> animalZoo2 = new Zoo<Fish>();
            // animalZoo.AddAnimal(new Salmon());
            // animalZoo.AddAnimal(new Lion());
            // animalZoo.AddAnimal(new Donkey());
            // Console.WriteLine("This should be True: "+animalZoo.HasAnimal<Fish>());

        }
    }
}
