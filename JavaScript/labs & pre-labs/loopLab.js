//Write a for loop that prints numbers from 1 to 5 to the console.

for (let i = 1; i<6; i++) console.log(i);

//Write a for loop that prints numbers from 5 to 1 to the console.

for (let i = 5; i > 0; i--) console.log(i);

//Write a for loop that prints the even numbers from 1 to 10.

for (let i = 1; i < 11; i++) if (i % 2 == 0) console.log(i);

//Write a for loop that prints the odd numbers from 1 to 10.

for (let i = 1; i < 11; i++) if (i % 2 != 0) console.log(i);
//Use a for loop to calculate and print the sum of numbers from 1 to 5.

let sum = 0;

for (let i = 1; i <= 5; i++) sum += i;

console.log(sum);
//Write a for loop that prints the multiplication table for the number 3 (from 1 to 10).

for (let i = 1; i <= 10; i++) console.log(`3 * ${i} = ${3 * i}`);

//Write a for loop that prints numbers from 1 to 10, but stops (breaks) when it reaches 5.

for (let i = 1; i <=10; i++){
    if (i === 5) break;
    console.log(i);
}

//Write a for loop that prints numbers from 1 to 10, but skips the number 5. (use continue)

for (let i = 1; i <= 10; i++){
    if (i === 5) continue;
    console.log(i);
}
//Write a nested for loop that prints the numbers 1 to 3, three times.

for (let i = 0; i < 3; i++){
    for (let j = 1; j <= 3; j++){
        console.log(j);
    }
}

//Use a nested for loop to print a 3x3 grid of stars (*).

let stars = "";

for (let i = 0; i < 3; i++){
    for (let j = 0; j < 3; j++){
        stars += "*";
    }
    if(i < 2) stars += "\n";
}

console.log(stars);

//Write a nested for loop to generate a multiplication table for numbers 1 to 3.

for (let i = 1; i < 4; i++){
    for (let j = 1; j < 4; j++) console.log(`${i} * ${j} = ${i * j}`);
}

//Use nested for loops to print a right-angled triangle of stars.

for (let i = 1; i < 6; i++) console.log("*".repeat(i));

//Use nested for loops to print a 4x4 grid of numbers. The numbers increase row-wise.

let gay = 0;
for (let i = 0; i < 4; i++){
    let list = "";
    for (let j = 0; j < 4; j++){
        gay++;
        list += gay + " ";
    }
    console.log(list)
}

//Use nested for loops to print a triangle of increasing numbers.

for(let i = 1; i < 5; i++){
    let list = "";
    for(let j = 0; j < i; j++) list += j+1;
    console.log(list);
}
//Use nested for loops to print stars (*) in a diagonal pattern for a 5x5 grid.

for(let i = 0; i < 5; i++){
    let list = "";
    for(j = 0; j < i; j++) list += " ";
    list += "*";
    console.log(list);
}
//Use nested for loops to print a right-aligned triangle of stars in reverse.

for(i = 4; i > 0; i--){
    let list = "";
    list += " ".repeat(4-i);
    for(j = 0; j < i; j++) list += "*";
    console.log(list);
}