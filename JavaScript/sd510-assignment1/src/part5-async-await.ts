// Part 5: async and await (Unit 2, Lesson 1)
// Use async, await, and try/catch in this file. Do not use .then() or .catch().
// You may call your own functions from Parts 2 and 4; the imports are already here.

import { getMember, getBook, getLoans, getImportedRecords, type Book, type Member } from './library-api.ts';
import { errorMessage, validBooks } from './part2-validation.ts';
import { loadFinePolicyAsync } from './part4-creating-promises.ts';

// Resolves with a sentence about the member and the number of loans they have not returned.
// Use 'loan' when the number is 1 and 'loans' otherwise.
// Examples: 'Ana Silva has 2 active loans', 'Ben Okafor has 1 active loan', 'Chen Wei has 0 active loans'
// An unknown id rejects with getMember's error (do not catch it here).
export async function describeMember(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Resolves with the member, or with null if getMember rejects.
export async function findMember(id: number): Promise<Member | null> {
  throw new Error('Not implemented');
}

// Resolves with the titles of the books this member has not returned yet, in loan order.
// Get each book with getBook, one after another, using a for...of loop with await inside it.
// Example: getBorrowedTitles(1) resolves with ['Clean Code', 'Dune'].
// Resolves with [] if the member has no active loans.
export async function getBorrowedTitles(memberId: number): Promise<string[]> {
  throw new Error('Not implemented');
}

// Resolves with the member's total fine, in dollars.
//   1. Get the member, then the fine policy for the member's home branch (loadFinePolicyAsync).
//   2. Get the member's loans. Only loans that are not returned are charged.
//   3. Each loan is charged daysOverdue * dailyRate, but never more than maxFine.
//      (Math.min(a, b) returns the smaller of two numbers.)
//   4. The total fine is the sum of those charges.
// Examples: calculateFine(1) resolves with 1, calculateFine(2) resolves with 10.
// Rejects if the member does not exist or the branch has no fine policy (do not catch errors here).
export async function calculateFine(memberId: number): Promise<number> {
  throw new Error('Not implemented');
}

// Resolves with a one-line report for the member. Use describeMember's wording for the loans,
// calculateFine for the fine, and toFixed(2) to show the fine with two decimals:
//   'Ana Silva has 2 active loans and owes $1.00'
// If anything fails, resolves (does not reject) with 'Error: ' followed by errorMessage(error),
// for example 'Error: Member 999 not found' or 'Error: No fine policy for branch online'.
export async function memberReport(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Resolves with the valid books from the old catalog system (getImportedRecords),
// using validBooks from Part 2.
export async function loadImportedCatalog(): Promise<Book[]> {
  throw new Error('Not implemented');
}
