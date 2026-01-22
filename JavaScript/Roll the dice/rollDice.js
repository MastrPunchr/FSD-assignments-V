var prompt = require('prompt-sync')();

function askSides(){
    let sides = 0;
    while (true){
        let sidesPrompt = prompt("Please enter how many sides you would like the dice to have (must be greater than 2): ");
        if(sidesPrompt < 3){
            console.log("Sorry, that's not a valid size value. Please choose a positive number.");
            continue;
        }
        sides = sidesPrompt;
        break;
    }
    return sides;
}

function rollDice(sides){
    let rolls = 0;
    let doubles = 0;
    let firstAvg = 1;
    let secondAvg = 1;
    let counter = 1;
    while(true){
        let dice1 = Math.floor(Math.random() * sides) + 1;
        let dice2 = Math.floor(Math.random() * sides) + 1;
        console.log(`${counter}.\n Die 1: ${dice1}\n Die 2: ${dice2}`);
        rolls++;
        counter++;
        if(dice1 == 1 && dice2 == 1){
            firstAvg /= (rolls-1);
            secondAvg /= (rolls-1);
            break;
        }
        firstAvg += dice1;
        secondAvg += dice2;
        if(dice1 == dice2) doubles++;
    }
    return [rolls, doubles, firstAvg, secondAvg];
}

function main(){
    let sides = askSides();
    let diceValues = rollDice(sides);
    console.log(`You got snake eyes on roll ${diceValues[0]}!`);
    console.log(`Along the way, you rolled doubles ${diceValues[1]} times.`);
    console.log(`The average roll was ${diceValues[2].toFixed(2)} on die 1, and ${diceValues[3].toFixed(2)} on die 2.`);
}

main();