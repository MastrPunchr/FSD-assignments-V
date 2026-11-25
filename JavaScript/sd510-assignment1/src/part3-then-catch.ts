// Part 3: Promises with .then() and .catch() (Unit 2, Lesson 1)
// Use .then() and .catch() in this file. Do not use async or await.
// Each function returns the promise that its chain gives back. Keep every chain flat:
// return the next promise from inside .then(), do not nest .then() calls.

import { getMember, getBook, getLoans } from './library-api.ts';

// Resolves with the name of the member with this id.
// Rejects (with getMember's error) if there is no such member.
// Example: getMemberName(2) resolves with 'Ben Okafor'.
export function getMemberName(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Like getMemberName, but resolves with 'Unknown member' if getMember rejects.
export function getMemberNameOrDefault(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Resolves with the number of loans this member has not returned yet.
// First get the member, so that an unknown id rejects with 'Member <id> not found'
// (getLoans alone never rejects), then get that member's loans.
// Example: countActiveLoans(1) resolves with 2.
export function countActiveLoans(id: number): Promise<number> {
  throw new Error('Not implemented');
}

// Resolves with true if the book has at least one copy on the shelf, otherwise false.
// Resolves with false (does not reject) if there is no book with this ISBN.
export function isBookAvailable(isbn: string): Promise<boolean> {
  throw new Error('Not implemented');
}
