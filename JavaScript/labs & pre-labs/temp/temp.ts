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

// DIFFERENT THING

