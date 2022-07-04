using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivePhilosophersProblem
{
    public interface IStrategyDinnerPhilosophers
    {
        void revolve(Philosopher[] philosophers);
    }
}
