using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FivePhilosophersProblem
{
    public class ByTurnStrategy : IStrategyDinnerPhilosophers
    {
        public void revolve(Philosopher[] philosophers)
        {
            //var half = philosophers.Length / 2;
            //var halffCeil = Math.Ceiling(philosophers.Length / 2);
            var half = (int)Math.Ceiling((decimal)philosophers.Length / 2);
            
            var barrier = new Barrier(half);
            var forks_semaphore = philosophers.Select(_ => new Semaphore(1, 1)).ToArray();
            var tasks = new Task[half];
            for (int i = 0; i < half; i++)
            {
                int x = i * 2;
                var task = Task.Factory.StartNew(() =>
                {
                    tryToEating(x,
                        philosophers,
                        forks_semaphore,
                        barrier);
                });
                tasks[i] = task;

            }
            Task.WaitAll(tasks);
        }
        private void tryToEating(int philosopherUbication,
                                Philosopher[] philosophers,
                                Semaphore[] forks_semaphore,
                                Barrier barrier)
        {
            while (true)
            {
                var philosopher = philosophers[philosopherUbication];
                var forkLeft_semaphore = forks_semaphore[philosopher.LeftForkUbication];
                var forkRight_semaphore = forks_semaphore[philosopher.RightForkUbication];
                philosopher.TakeLeftFork();
                forkLeft_semaphore.WaitOne();
                philosopher.TakeRigthFork();
                forkRight_semaphore.WaitOne();
                philosopher.Eat();
                forkLeft_semaphore.Release();
                forkRight_semaphore.Release();
                //espera q los pares terminen
                barrier.SignalAndWait();
                philosopherUbication++;
                if (philosopherUbication == forks_semaphore.Length)
                    philosopherUbication = 0;

            }

        }
    }
}
