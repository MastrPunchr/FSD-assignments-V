// Part 2: Checking data you did not create (Unit 1, Lesson 3)
// Do not use any, and do not use type assertions (as). Check the values with typeof,
// in, and the type guards you write.

import type { Book, Genre, Location } from './library-api.ts';

// Returns true if value is one of the four genres: 'fiction', 'science', 'history', 'technology'.
export function isGenre(value: unknown): value is Genre {
  throw new Error('Not implemented');
}

// Returns true if value is an object (not null) with a string shelf and a number floor.
export function isLocation(value: unknown): value is Location {
  throw new Error('Not implemented');
}

// Returns true if value has every property of a Book with the right type:
//   isbn, title and author are strings; genre is a Genre; year and copies are numbers.
// location is optional: the record is valid if it has no location property,
// or if its location passes isLocation. (A location of null is not valid.)
export function isBook(value: unknown): value is Book {
  throw new Error('Not implemented');
}

// Returns only the records that are valid books, in the same order.
export function validBooks(records: unknown[]): Book[] {
  throw new Error('Not implemented');
}

// Returns a message for a value caught by catch (error), which has the type unknown:
//   an Error            -> its message
//   a string            -> the string itself
//   anything else       -> 'Unknown error'
export function errorMessage(error: unknown): string {
  throw new Error('Not implemented');
}
