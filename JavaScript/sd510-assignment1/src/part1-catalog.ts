// Part 1: Processing catalog data (Unit 1, Lessons 1 and 2)
// Use array methods (filter, map, reduce, toSorted) in this file. Do not use loops (for, while).
// None of these functions may change the array or the objects passed to them.

import type { Book } from './library-api.ts';

// Returns the titles of the books that have at least one copy on the shelf, in the same order.
// Example: for [Clean Code (2 copies), Dune (0 copies)] it returns ['Clean Code'].
export function availableTitles(books: Book[]): string[] {
  throw new Error('Not implemented');
}

// Returns the total number of copies on the shelf across all the books.
// Returns 0 for an empty array.
export function totalCopies(books: Book[]): number {
  throw new Error('Not implemented');
}

// Returns a new array with the books sorted by year, newest first.
// The array passed in must keep its original order.
export function newestFirst(books: Book[]): Book[] {
  throw new Error('Not implemented');
}

// Returns one line describing the book. Use destructuring to read the properties you need,
// and the ternary operator to choose the ending.
// Examples:
//   'Clean Code by Robert C. Martin (2008): 2 available'
//   'Dune by Frank Herbert (1965): checked out'          (when copies is 0)
export function formatBook(book: Book): string {
  throw new Error('Not implemented');
}

// Returns the book's shelf, or 'Not shelved' if the book has no location.
// Use optional chaining (?.) and the nullish coalescing operator (??). Do not use if or the ternary operator.
// Examples: 'T-12' for Clean Code, 'Not shelved' for Sapiens.
export function shelfLabel(book: Book): string {
  throw new Error('Not implemented');
}

// Returns a new Book object with one more copy on the shelf (a copy was returned).
// Use the spread operator. The book passed in must not change.
export function returnCopy(book: Book): Book {
  throw new Error('Not implemented');
}
