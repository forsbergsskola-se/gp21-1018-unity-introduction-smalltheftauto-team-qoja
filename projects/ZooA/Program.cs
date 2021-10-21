using System;
using System.Collections.Generic;

public class Program {
    
    public class Animal{}
    public class Mammal : Animal{}
    public class Bear : Mammal{}
    public class Donkey : Mammal{}
    public class Lion : Mammal{}
    public class Fish : Animal{}
    public class Salmon : Fish{}
    public class Clownfish : Fish{}
    public class Student{}

    static void Main() {
        {
            Zoo<Fish> fishZoo = new Zoo<Fish>();
            fishZoo.AddAnimal(new Fish()); // OKAY
            fishZoo.AddAnimal(new Clownfish()); // OKAY
        }
        
        {
            Zoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.AddAnimal(new Fish()); // OKAY
            animalZoo.AddAnimal(new Clownfish()); // OKAY
            animalZoo.AddAnimal(new Lion()); // OKAY
            animalZoo.AddAnimal(new Donkey()); // OKAY
        }
        
        {
            Zoo<Lion> lionZoo = new Zoo<Lion>();
            lionZoo.AddAnimal(new Lion()); // OKAY
            lionZoo.AddAnimal(new Lion()); // OKAY
            lionZoo.AddAnimal(new Lion()); // OKAY
        }
        
        // {
        //     Zoo<Student> studentZoo = new Zoo<Student>(); // ERROR!
        // }
        //
        // {
        //     Zoo<Fish> fishZoo = new Zoo<Fish>();
        //     fishZoo.AddAnimal(new Lion()); // ERROR!
        // }
        //
        // {
        //     Zoo<Animal> animalZoo = new Zoo<Animal>();
        //     animalZoo.AddAnimal(new Student()); // ERROR!
        // }
        //
        // {
        //     Zoo<Salmon> salmonZoo = new Zoo<Salmon>();
        //     salmonZoo.AddAnimal(new Fish()); // ERROR!
        // }
        //
        // {
        //     Zoo<Salmon> salmonZoo = new Zoo<Salmon>();
        //     salmonZoo.HasAnimal<Lion>(); // ERROR!
        // }
        
        {
            Zoo<Fish> fishZoo = new Zoo<Fish>();
            fishZoo.AddAnimal(new Salmon());
            fishZoo.AddAnimal(new Salmon());
            Console.WriteLine("This should be False: "+fishZoo.HasAnimal<Clownfish>());
        }
    }

    class Zoo<TAnimal> where TAnimal : Animal {
        List<TAnimal> animals = new List<TAnimal>();

        public void AddAnimal(TAnimal animal) {
            this.animals.Add(animal);
        }

        public bool HasAnimal<TSpecies>() where TSpecies : TAnimal {
            // TODO return true/false, depending on whether any TAnimal in animals is of type TSpecies
        }
    }
}