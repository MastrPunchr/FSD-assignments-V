function isPalindrome(stringInput) {
    let reversed = stringInput.toLowerCase().split('').reverse().join(''); //first casts to lowercase, then splits, reverses, and rejoins them to get a palindrome
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
