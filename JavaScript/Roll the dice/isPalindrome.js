function isPalindrome(stringInput) {
    let reversedList = stringInput.toLowerCase().split(''); //first casts to lowercase, then splits to later be reversed and joined back together since apparently I'm not allowed to have ANY prior knowledge in this course and use built in functions instead of rewriting them in a way that is less efficient.
    let reversed = "";
    for(let i = reversedList.length; i > 0; i--){ //adds characters to the string going backwards since .join() was just too easy (YES I'm salty about this and YES I am going to stay mad)
        reversed += reversedList[i-1];
    }
    return (reversed == stringInput.toLowerCase() && reversed != "") ? true : false;// checks if it is a palindrome or not and if it is not an empty string
}

// Test cases
const testStrings = [
    "radar", 
    "apple", 
    "Racecar", 
    "java", 
    ""
];

// Expected outputs for the test cases
const expectedOutputs = [
    true,       // radar is a palindrome
    false,      // apple is not a palindrome
    true,       // Racecar is a palindrome NOTICE HOW 'R' AND 'r' ARE THE SAME
    false,      // Java is not a palindrome
    false       // Empty Strings are not palindromes
];

// Running the tests
testStrings.forEach((el, index) => {
    const result = isPalindrome(el);
    console.log(`Test ${index + 1}:`,el);
    console.log(`Expected Output: "${expectedOutputs[index]}"`);
    console.log(`Actual Output: "${result}"`);
    console.log(result === expectedOutputs[index] ? "Test Passed" : "Test Failed", '\n');
});
