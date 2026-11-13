// step 1:
// const end = Date.now() + 5000;
// while (Date.now() < end){
//     console.log(Date.now()); // in milliseconds
//     console.log(typeof(Date.now()));
// }


// step 2: setTimeout runs a func l8r
console.log('1');
setTimeout(() => console.log('3'), 2000);
console.log('2');

// step 3: can't return a value from code that runs l8r
// function getNumber(){
//     setTimeout(() => { return 42; }, 1000);
// }
//
// console.log(getNumber());

// step 4: pass function to recieve value
function doubleNum(num: number){
    return num * 2;
}

function getNumber(apple: (n: number) => void){ //a callback function, need to say what it takes and what it returns
    setTimeout(() => apple(42), 1000);
}
getNumber(n => console.log(n));

// step 5: creating a promise and reading its value
const p = new Promise(resolve =>{
    resolve('{id: 1, name: nicholas}');
});
console.log(p);

//step 6: reading the value of Promise
p.then(value => console.log(value)); // .then() gets a function that would do whatever if the promise resolves. (what???)

// step 7: a promise that gets its value l8r.
const later = new Promise(resolve => {
    setTimeout(() =>  resolve(10), 1000);
});

console.log(later);
later.then(value => console.log(`The response was: ${value}`));
console.log('end of file');

// step 8: what happens when promise fails. .then()
const failed = new Promise((resolve, reject) => {
    setTimeout(() => reject(new Error('smth happun')), 1000);
});

failed
    .then(value => console.log(value))
    .catch(error => console.log(error));



// 1. Create a promise that resolves with 'Done!' after 2 seconds, and print the value with    .then()
const sugma = new Promise(resolve => {
    setTimeout(() => resolve("done!"), 2000);
});

// 2. Set const num = 7;. Create a promise that resolves with num if it is even and rejects with the error '7 is odd' if it is odd. With .then(), print '<num> is even'; with .catch(), print the error message. Test it with 7 and with 8.
const num = 7;
const p2 = new Promise((resolve, reject) =>{
    if(num%2===0)
        resolve(num);
    else
        reject(new Error(`${num} is odd`));
});

// 3. Dice roll. After 1 second, pick a random number from 1 to 6. Resolve with the number if it is 4 or higher; otherwise reject with 'You rolled <n>. You lose.'. Print 'Rolling...' immediately, and on success print 'You rolled <n>. You win!'.
// Hint: Math.floor(Math.random() * 6) + 1

const dice = new Promise((resolve, reject) => {
    console.log("Rolling...") ;
    let n = setTimeout (() => Math.floor(Math.random() * 6) + 1, 1000);
    if(n >= 4)
        resolve(`You rolled ${n}. You win!`);
    else
        reject(`You rolled ${n}, You lose.`);
});

// 4. Write a function checkAge(age: number): Promise<string>. After 1 second, it resolves with 'Access granted' if age >= 18, and otherwise rejects with 'Access denied: must be 18 or older'. Call it with 25 and with 15.

function checkAge(age: number) : Promise<string> {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if(age >= 18)
                resolve('Access granted');
            else
                reject(new Error('Access denied: must be 18 or older'));
        }, 1000)
    })
}

// 5. (challenge). Write orderPizza(topping: string): Promise<string>. The available toppings are ['cheese', 'pepperoni', 'mushroom']. After 2 seconds, resolve with 'Your <topping> pizza is ready' if the topping is available, and otherwise reject with 'Sorry, we have no <topping>'. Then:
// Print 'Order placed'.
// Order pepperoni and pineapple.
// Print 'Waiting for pizza...'.