using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivePhilosophersProblem
{
    public class Philosopher
    {
        public readonly string Name;
        public readonly ConsoleColor Color;
        public  int LeftForkUbication { get; private set; }
        public  int RightForkUbication { get; private set; }

        public static Random Random = new Random();
        public Philosopher(string Name, int LeftForkUbication, int RightForkUbication, ConsoleColor Color)
        {
            this.Name = Name;
            this.LeftForkUbication = LeftForkUbication;
            this.RightForkUbication = RightForkUbication;
            this.Color = Color;
            
        }
        public void TakeRigthFork() {
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Name} is taking the right fork.......");
            Thread.Sleep(Random.Next(1000));
        }
        public void TakeLeftFork()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"{Name} is taking the left fork......");
            Thread.Sleep(Random.Next(1000));
        }
        public void Eat() {
            Console.ForegroundColor= Color;
            Console.WriteLine($"{Name} is eating");
            Thread.Sleep(Random.Next(1000));
          
        }
    }
}
