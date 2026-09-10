# Heltevagten

## About the project

Heltevagten is a C# console application that simulates a superhero emergency dispatch system.

The system can:

* Register heroes
* Report incidents
* Dispatch heroes to incidents
* Resolve incidents
* Check hero availability
* Search for heroes and incidents
* Choose different dispatch strategies
* Demonstrate callbacks using named methods and lambda expressions

## Hero Types

The system contains three hero types:

* HealingHero
* StrongHero
* FlyingHero

Each hero has a different signature move.

## Dispatch Strategies

The application supports three dispatch strategies:

* First Available Hero
* Strongest Hero
* High Severity

The strategy is selected through the `IDispatchStrategy` interface, which keeps the dispatch logic flexible.

## Main Concepts Used

This project demonstrates:

* Classes and objects
* Inheritance
* Abstract classes
* Interfaces
* Encapsulation
* Collections
* Generic methods
* Lambda expressions
* Delegates / `Action`
* Custom exceptions
* Dependency injection
* Polymorphism

## How to Run

1. Open the project in Visual Studio.
2. Build the solution.
3. Run the console application.
4. Use the menu to test the different functions.

## Error Handling

The application uses custom exceptions to handle situations such as:

* No suitable hero being available
* A hero already being unavailable

The exceptions are caught and handled without crashing the application.

## Callback

When an incident is resolved, a callback is used to perform additional actions.

The project demonstrates both:

* A named callback method
* A lambda callback

## Project Structure

The project contains classes for:

* Heroes
* Incidents
* Dispatch center
* Dispatch strategies
* Interfaces
* Custom exceptions

## Author

Jyothsna Batta
