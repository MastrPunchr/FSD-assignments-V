function add(a, b){
    return a+b;
}

function subtract(a, b){
    return a-b;
}

function divide(a, b){
    return a/b;
}

function multiply(a, b){
    return a*b;
}

function calculate(a, b, callback){
    let result = callback(a, b);
    console.log(result);
}

calculate(2, 3, subtract);