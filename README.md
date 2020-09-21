# SM Programming Exercise

This repository forms part of an interview process whereby the applicant needs to work to a particular brief, provided by the company.
The brief is provided below for posterity, after which follows my input.
<br/> <br/>
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
<br/> <br/>

## Installation
To build from source, clone the repository. The application is built on .NET Core 3.1, so the relevant SDK is required. If using Visual Studio, dependencies should 
be automatically pulled from Nuget. `Program.Main()` is the entry point. Alternatively, a single release is provided.
<br/> <br/>

## Assumptions
1. There is some input validation in place to allow graceful exits, but in general it is assumed the inputs will not be malformed 
2. At least one command is provided, even if it is `0 - quit`
3. There will not be invalid commands e.g. `-1`or `5` or `Left`. If so these will be ignored and not throw an exception
4. The mimimum size of the table is `1 x 1`
<br/> <br/>

## Testing
I have written a few test cases with NUnit, these are not exhaustive, but should form a good foundation for further testing.
<br/> <br/>
## Extensibility Options
As part of the brief, the applicant is required to structure the code so that some thought is given to future extensibility.
The company asks some questions regarding extensibility, below are are my answers:
<br/> <br/>

>Would it be easy to...
> * Handle different shapes than a rectangle?

Broadly, yes. The `GridBase` base class is used as the base class for `Table`. The intention here is that for a 
new shape of table, a new class should be created that inherits from `GridBase` and the methods `SetGridShape()` and 
`BoundaryBreached()` should be overridden with logic pertaining to the new shape.

> * Add more commands like rotating the table instead of the object?

Yes, the `Command` object is an enumeration which could be added to, and used with any other entity. The `Simulation.Run()` method
can be extended to include, for example, a `RunTableCommands()` method. In addition, the interface `ICommandable` can be implemented in other objects, such as the
table itself. This interface is implemented in both the `Tile` and `Table` classes, but merely stubbed in `Table` by way of demonstration.

> * Change the binary form of the protocol to JSON?

Yes. Rather than accepting a concrete type, the `Simulation` class takes an object of `IData` in its constructor. Any data entity being used with the
`Simulation` class must implement this interface. The brief requires the input to be from `stdin`, hence the `StdinData` class is an implementation of this interface.
For completeness' sake, an implementation of JSON data is provided as the `JsonData` class, which just accepts JSON as a string. This could of course be
JSON from a file, or XML from an API - the same principal applies.
<br/> <br/>

## Final words and further work 
There is much more that could be done to increase the robustness and flexibility of this application and, as with all projects, understanding as much
about the possible future scope is what dictates the degree to which the code should 'flex'. However, I hopefully demonstrated my knowledge and abilities
to an acceptable level. Below are a few examples of changes to the brief that could be achieved with some minor modification, and others that would require more
restructuring:

>* Making the tile bigger than `1 x 1`, and not necessarily a square (.e.g `3 x 2`) 
  
Perhaps if the tile were, for example, `2 x 2` all 4 squares that make up the body would have to be off the table in order 
to get the `-1, -1` result. This shouldn't be too painful to implement by perhaps adding an `Area` property to the `Tile` class, and adjusting the
logic in the `BoundaryBreached` getter.
>* Diagonal movement
  
 This could probably be quite simple to implement by adding to the `Rotation` and `Bearing` enums, as well as editing the switch statements in each of the `ICommandable`
  interface's implementations in the `Tile` class. However, combining this feature with some of the others in the list might make it worth replacing `ICommandable` with 
  an abstract base class.

>* Different starting direction 
  
Fairly easy to implement by editing the constructor of the `Tile` object or other object implementing `ICommandable`
>* Skipping tiles/jumping/teleporting
  
Should be quite simple to implement, by adding to the `Command` enum and adding a `Jump()` method to perhaps take `x` and `y` coordinates to jump to
>* Multiple tiles and different command lists for each

In this case perhaps one could change `Tile` and `CommandList` properties in the `Simulation` object to `IEnumerable<Tile>` and 
`IEnumerable<CommandList>` respectivley (of course the `CommandList` class would need to be created in this case).


> * More data about the Simulation

Right now the `ResultData` property of the `Simulation` class is just a `string` because the return data is so simple. Adding more data to this output, 
for example 'number of moves', would probably warrant the creation of a new entity whose sole purpose is to extract and present data from a collection of
one or more `ICommandable` and or `GridBase` child classes objects; a new interface may also be pertinent in the latter case

 
>* What if the grid were in 3D space?

This would probably constitute a drastic change in scope, and the implementation of this has not been given consideration.

