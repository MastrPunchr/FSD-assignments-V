//Q1
const greetings = {
    english: 'Welcome',
    czech: 'Vitejte',
    danish: 'Velkomst',
    dutch: 'Welkom',
    estonian: 'Tere tulemast',
    finnish: 'Tervetuloa',
    flemish: 'Welgekomen',
    french: 'Bienvenue',
    german: 'Willkommen',
    irish: 'Failte',
    italian: 'Benvenuto',
    latvian: 'Gaidits',
    lithuanian: 'Laukiamas',
    polish: 'Witamy',
    spanish: 'Bienvenido',
    swedish: 'Valkommen',
    welsh: 'Croeso'
}

function welcome(language){
    if(language in greetings){
        console.log(greetings[language]);
    } else {
        console.log(greetings.english);
    }
}

//Q2
const userData = [{
    username: 'David',
    status: 'online',
    lastActivity: 10
    }, {
    username: 'Lucy', 
    status: 'offline',
    lastActivity: 22
    }, {
    username: 'Bob', 
    status: 'online',
    lastActivity: 104
}];

const userActivity = {
    online: [],
    offline: [],
    away: []
}

function isOnline(){
    for(let i = 0; i < userData.length; i++){
        if(userData[i].status == "online"){
            if(userData[i].lastActivity > 10){
                userActivity.away.push(userData[i].username);
                continue;
            }
            userActivity.online.push(userData[i].username);
            continue;
        }
        userActivity.offline.push(userData[i].username);
    }
    console.log(userActivity);
}

//Q3
const firstName = {A: 'Alpha', B: 'Beta', C: 'Cache', L: "Logic"};
const surname = {A: 'Analogue', B: 'Bomb', C: 'Catalyst'};

function aliasGen(first, last){
    if(first[0] in firstName && last[0] in surname){
        console.log(`${firstName[first[0]]} ${surname[last[0]]}`);
    } else {
        console.log("Your name must start with a letter from A - Z.")
    }
}

//Q4
const library = [
    {title: "The Hobbit", author: "J.R.R. Tolkien", alreadyRead: true},
    {title: "The Lord of the Rings", author: "J.R.R. Tolkien", alreadyRead: false}
];

library.forEach((book) => {
    if(book.alreadyRead){
        console.log(`You have already read ${book.title} by ${book.author}`);
    } else {
        console.log(`You have not read ${book.title} by ${book.author}`);
    }
});

//Q5
const order = [[1, 'hamburger'], [4, 'hotdog'], [2, 'coke'], [4, 'milk']];
const data = {cost: {hamburger: 1.25, hotdog: 1, coke: 0.5, milk: 0.4}};

function orderCost(order){
    let total = 0;
    order.forEach((itemPair) => {
        if(itemPair[1] in data.cost){
            total += data.cost[itemPair[1]] * itemPair[0];
        }
    });
    console.log(total);
}

orderCost(order);

//The actual lab (most questions were nothing burgers lol)
//Q3
let savingsAccount = {
  balance: 1000,
  interestRatePercent: 1,
  deposit: function addMoney(amount) {
    if (amount > 0) {
      savingsAccount.balance += amount;
    }
  },
  withdraw: function removeMoney(amount) {
    let verifyBalance = savingsAccount.balance - amount;
    if (amount > 0 && verifyBalance >= 0) {
      savingsAccount.balance -= amount;
    }
  },
  getStatement: function printAccountSummary(){
    console.log("Welcome!");
    console.log(`Your balance is currently $${balance} and your interest rate is ${interestRatePercent}%`);
  }
};

//Q4
let donuts = [
  { type: 'Jelly', cost: 1.22 },
  { type: 'Chocolate', cost: 2.45 },
  { type: 'Cider', cost: 1.59 },
  { type: 'Boston Cream', cost: 5.99 },
];

donuts.forEach((donut) => console.log(`${donut.type} donuts cost $${donut.cost} each`));

//Arrays advanced prelab!
//Q1
function findSecondLargest(list){
    if(Array.isArray(list)){
        list.sort((a, b) => a - b);
        console.log(list.at(-2));
    }
}

//Q2
function threeLetters(list){
    if(Array.isArray(list)){
        const debloated = list.filter((word) => word.length < 4);
        console.log(debloated);
    }
}

//Q3
function dividePlayers(people){
    if(Array.isArray(people)){
        function myCallback(person){
            return people.indexOf(person) % 2 == 0 ? "teamOne" : "teamTwo";
        }
        const teams = Object.groupBy(people, myCallback);
        console.log(teams);
    }
}

//Q4
function matrixSum(matrix){
    if(Array.isArray(matrix)){
        const sum = matrix.flat(Infinity).reduce((acc, total) => acc + total, 0,);
        console.log(sum);
    }
}

matrixSum([[2, 3, 4], [3, 4, 5], [4, 5, [6, 7]]]);