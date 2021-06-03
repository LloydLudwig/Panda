## Variable declaration: 
`int X = 22`
Int denotes integer variable
X is the name of the variable 
22 is the value stored

## Mathematical expressions:
`Int x = 32`
`Int y = 12`
`Int z = (x + y)`
Variable z will be the sum of x and y
All arithmetic equations but separate each items with whitespaces and be enclosed by brackets

`Int a = (x – (y * z))`
Panda script will support full arithmetic operations
Panda will not support mathematical functions (eg. Sin, Cos, Tan) and mathematical constants (eg, e, Pi) 

## Selection:
`If (condition):
Code
end_if`

Each statement must end with end_if token equivalent

### Conditions:
Panda script supports the following operators:
`==`, `>`, `<`, `>=`, `<=`, `!=`
- Conditions can only be applied to the currently one planed data type being integers 
- Conditions can only use one pair of values and an operator
- This means that more conditions require the use of nested if statements
eg.
`if (21 <= 25)`
**Code**
`end_if`

Output:
print (data)
will print the content of the bracket
the data must be enclosed by a bracket
if there is a variable references with the brackets then the values of the variables will replace the references 

## Iteration:
Iteration will be implemented with a goto function much like BASIC

For loop implementation in panda code:

`Int I = 10`
</br>
`If ( I < 10 )`
</br>
**`some code in here`**
</br>
`I = I – 1
goto(2)`
