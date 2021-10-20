using System;

namespace ZooA
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    abstract class Animal
    {
        
    }

    abstract class Mamal : Animal
    {
        
    }

    class Bear : Mamal
    {
        
    }

    class  Lion : Mamal
    {
        
    }

    class Donckey: Mamal
    {
        
    }

    abstract class Fish : Animal
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
        
    }

  
    
    
    
}
