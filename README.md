# SM Programming Exercise

This repository forms part of an interview process whereby the applicant needs to work to a particular brief, provided by the company. The brief is provided below for posterity, after which follows my input.

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

## Extensibility Options
As part of the brief, the applicant is required to structure this code so that extensibility is 