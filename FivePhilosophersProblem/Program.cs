// See https://aka.ms/new-console-template for more information
using FivePhilosophersProblem;
var names = new string[5] {
    "Socrates",
    "Platon",
    "Sartre",
    "Kant",
    "Marx",
};
var colors = new ConsoleColor[5] {
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