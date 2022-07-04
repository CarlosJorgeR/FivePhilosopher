// See https://aka.ms/new-console-template for more information
using FivePhilosophersProblem;

const int chairNumber = 5;
var names = new string[chairNumber] {
    "Socrates",
    "Platon",
    "Sartre",
    "Kant",
    "Marx",
};
var colors = new ConsoleColor[chairNumber] {
    ConsoleColor.Blue, ConsoleColor.Red,
    ConsoleColor.Yellow , ConsoleColor.Green,
    ConsoleColor.White
};
var philosophers = names.Select((name, index) =>
    new Philosopher(name,
    index % names.Length,
    (index + 1) % names.Length,colors[index])).ToArray();

IStrategyDinnerPhilosophers strategy = new SimpleStrategy();
strategy.revolve(philosophers);