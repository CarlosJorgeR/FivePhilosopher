using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivePhilosophersProblem
{
    public class SimpleStrategy : IStrategyDinnerPhilosophers
    {
        public void revolve(Philosopher[] philosophers)
        {
            var forks_semaphore = philosophers.Select(_ => new Semaphore(1, 1)).ToArray();
            var tasks = new Task[philosophers.Length];
            for (int i = 0; i < philosophers.Length; i++)
            {
                int x = i;
                var task = Task.Factory.StartNew(() =>
                  {
                      tryToEating(philosophers[x],
                      forks_semaphore[philosophers[x].LeftForkUbication],
                      forks_semaphore[philosophers[x].RightForkUbication]);
                  });
                tasks[i] = task;

            }
            Task.WaitAll(tasks);
        }
        private void tryToEating(Philosopher philosopher, Semaphore forkLeft_semaphore, Semaphore forkRight_semaphore)
        {
            while (true)
            {
                philosopher.TakeLeftFork();
                forkLeft_semaphore.WaitOne();
                Thread.Sleep(100);
                philosopher.TakeRigthFork();
                forkRight_semaphore.WaitOne();
                philosopher.Eat();
                forkLeft_semaphore.Release();
                forkRight_semaphore.Release();
            }

        }
    }
}
