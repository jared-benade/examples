# Open-Closed Principle 

## Definition
A software module/class is open for extension and closed for modification.

## Examples

Given a class that filters computer monitors based off of various filter criteria. 

### Incorrect
The computer monitor filter class needs to be modified everytime a new filter is required.

### Correct
New filter specifications can be created (that follow an interface that the computer monitor filter class works with) and then the filter class does not need to be modified to handle these new cases.