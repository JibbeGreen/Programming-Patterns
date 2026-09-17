# Programming Patterns

A collection of reusable programming patterns implemented in C#, with a focus on practical, easy-to-understand examples that can be applied across different types of projects.

The repository contains a selection of behavioral, architectural, and communication-oriented patterns that help structure code, reduce coupling, and make systems easier to extend and maintain.

## Patterns

### Combinator

The **Combinator** pattern allows multiple operations or behaviors to be composed together into a single operation.

Useful when you want to build complex behavior by combining smaller, reusable pieces.

### Command

The **Command** pattern encapsulates an action as an object.

This allows actions to be stored, passed around, queued, executed later, or potentially undone without tightly coupling the caller to the object performing the action.

### Event Bus

The **Event Bus** provides a centralized mechanism for publishing and subscribing to events.

It helps decouple systems by allowing publishers and subscribers to communicate without needing direct references to each other.

### Mediator

The **Mediator** pattern centralizes communication between objects.

Instead of objects communicating directly with one another, they communicate through a mediator, reducing dependencies and helping keep individual components focused on their own responsibilities.

### Service Locator

The **Service Locator** pattern provides a central location for retrieving services or dependencies.

It can be useful when multiple parts of an application need access to shared services without having to pass those dependencies through every layer of the application.

### SOAP

The **SOAP** pattern provides a simple way to structure and organize communication between components using a service-oriented approach.

It demonstrates how functionality can be exposed through services while keeping the implementation details separated from the code consuming those services.

### State Machine

The **State Machine** pattern organizes behavior into discrete states and controls transitions between them.

It is particularly useful for systems whose behavior changes depending on their current state, such as characters, UI flows, game systems, or application workflows.

### Visitor

The **Visitor** pattern separates an operation from the objects on which it operates.

This makes it possible to add new operations without modifying the classes representing the objects being operated on.

## Repository Structure

Each pattern is implemented as a separate example, making it possible to study and use the patterns independently.

```text
Programming-Patterns/
├── Combinator/
├── Command/
├── EventBus/
├── Mediator/
├── ServiceLocator/
├── SOAP/
├── StateMachine/
└── Visitor/
```

> The exact directory structure may differ depending on the current organization of the project.

## Purpose

This repository is intended as a reference and learning resource for understanding common programming patterns and how they can be implemented in C#.

The examples aim to demonstrate the core idea behind each pattern without adding unnecessary complexity.

## Getting Started

Clone the repository:

```bash
git clone https://github.com/jibbegreen/Programming-Patterns.git
```

Then open the project in your preferred C# development environment and explore the individual pattern implementations.

## Choosing a Pattern

Different patterns solve different problems. As a general guideline:

| Pattern             | Useful for                                    |
| ------------------- | --------------------------------------------- |
| **Combinator**      | Combining small behaviors or operations       |
| **Command**         | Encapsulating actions and requests            |
| **Event Bus**       | Decoupled event-based communication           |
| **Mediator**        | Centralizing communication between components |
| **Service Locator** | Accessing shared services                     |
| **SOAP**            | Service-oriented communication                |
| **State Machine**   | Managing state-dependent behavior             |
| **Visitor**         | Adding operations to object structures        |

Patterns are tools rather than rules. Choose one when it makes the design easier to understand, maintain, or extend—not simply because a pattern exists.

## Contributing

Contributions, improvements, and additional examples are welcome.

When adding a new pattern, try to keep the implementation focused on demonstrating the pattern itself and include clear, readable examples.

## License

See the repository's license for information about using and distributing the code.