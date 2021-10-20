using System;

namespace ZooJO {
    public abstract class Animal {
        public override string ToString() => GetType().Name;
    }

    //Mammal
    public abstract class Mammal : Animal {}
    public class Bear : Mammal {}
    public class Donkey : Mammal {}
    public class Lion : Mammal {}
    //Fish
    public class Fish : Animal {}
    public class Salmon : Fish {}
    public class Clownfish : Fish {}
    //Student
    public class Student {}
    
    //Zoo
    public class Zoo<TAnimal> where TAnimal : Animal {
        private static TAnimal[] _animals = {};
        public void AddAnimal(TAnimal animal) {
            
            Array.Resize(ref _animals, _animals.Length + 1);
            _animals[^1] = animal;
        }
        

        public bool HasAnimal<TSpecies>() where TSpecies : TAnimal{
            foreach (var animalInZoo in _animals) {
                if (animalInZoo is TAnimal) {
                    return true;
                }
            }
            return false;
        }
    }

    class Program {
        static void Main(string[] args) {
            Zoo<Fish> fishZoo = new Zoo<Fish>();
            fishZoo.AddAnimal(new Salmon());
            fishZoo.AddAnimal(new Clownfish());
            fishZoo.AddAnimal(new Salmon());
            Console.WriteLine("This should be True: "+fishZoo.HasAnimal<Clownfish>());
        }
    }
}
