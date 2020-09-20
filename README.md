# SM Programming Exercise

This repository forms part of an interview process whereby the applicant needs to work to a particular brief, provided by the company.
The brief is provided below for posterity, after which follows my input.

___
>  ## Brief
> 
> The purpose of this test is to cover general practices, design and structure as well as
> algorithmic solutions for a smaller project.
> You can make assumptions if nothing is specifically stated, but ​be sure to document​ these.
> The end result should be a ​command line based program​ that will perform simple
> simulations of a moving object. The program will read from ​stdin​ and write to ​stdout
> according to a certain protocol (see below).
> 
> 
> ## Protocol
> It is important to ​follow the protocol ​correctly so that your final output can be easily
> tested and verified.
> 
> First, your solution reads a header from ​stdin​ like this:
> 
> * The size of the table as two integers [width, height]
> * The objects starting position as two integers [x, y]
> 
> This is followed by an arbitrarily long stream of commands of integers.
> When the simulation is complete, your program outputs the answer to ​stdout​ as per
> below:
> 
> * If the simulation succeeded: The objects final position as two integers [x, y]
> * If the simulation failed (the object falls off the table): [-1, -1] should be returned
> 
> Adding extra output to ​stdout​ will make it harder for us to test your solution.
> 
> #### Commands
> The object always has a direction (north, east, south or west). A simulation always starts
> with direction north. North means that if the object sits on [2, 4] and moves forward one
> step, the object will now stand on [2, 3].
> 
> The commands are:
> 
> * ```0 = quit simulation and print results to ​stdout```
> * ```1 = move forward one step```
> * ```2 = move backwards one step```
> * ```3 = rotate clockwise 90 degrees (eg north to east)```
> * ```4 = rotate counterclockwise 90 degrees (eg west to south)```
> 
> ## Example
> 
> If the program gets ​4,4,2,2​ as input, the table is initiated to size 4 x 4 with the object in
> position [2, 2] with direction north. Then, commands ​1,4,1,3,2,3,2,4,1,0​ are read
> from ​stdin​ and executed. The final output would then be the end position of the object,
> in this case ​[0, 1]​.
___

## Installation

## Assumptions
1. The inputs will not be malformed in any way, though extra spaces and commas in each of the headers are accounted for are accounted for
2. At least one command is provided, even if it is ```0 - quit```
3. There will not be invalid commands e.g. ```-1```or ```5``` or ```Left```
4. The mimimum size of the table is 1 x 1

## Extensibility Options
As part of the brief, the applicant is required to structure the code so that priority is given to extensibility.
The company asks some questions regarding extensibility, below are are my answers:

>Would it be easy to...
> * Handle different shapes than a rectangle

The ```GridBase``` base class is used as the base class for ```Table```. The intention here is that for a 
new shape of table, a new class should be created that inherits from `GridBase` and the methods `SetGridShape()` and 
`BoundaryBreached()` should be overridden with logic pertaining to the new shape.

> * Add more commands like rotating the table instead of the object

The `Command` object is an enumeration which could be added to, and used with any other entity. The `Simulation.Run()` method
can be extended to include, for example, a `RunTableCommands()` method. In addition, the interface `ICommandable` can be implemented in other objects, such as the
table itself. This is infterface is implemented in both the `Tile` and `Table` classes, but merly stubs in `Table` by way of demonstration.

> * Change the binary form of the protocol to JSON

Rather than accepting concrete type, the `Simulation` class takes an object of `IProtocolData` in its constructor. Any data entity being used with the
`Simulation` class must implement this interface. The breif requires the input to be from `stdin`, hence the `StdinData` class is an implementation of this interface.
An implementation of JSON data is also demonstrated as the `JsonData` class.

