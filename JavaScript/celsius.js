/*Write a program that:
Prompts the user to enter a temperature in Celsius.
Converts it to Fahrenheit using the formula: (Celsius * 9/5) + 32.
Logs the result: "The temperature in Fahrenheit is [Fahrenheit].*/

let celsius = prompt("Enter a temperature in celsius (number only)");

let fahrenheit = (celsius * 1.8) + 32;

alert(`The temperature in Fahrenheit is ${fahrenheit} degrees`);