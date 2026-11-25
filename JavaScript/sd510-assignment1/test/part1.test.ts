import { test } from 'node:test';
import assert from 'node:assert/strict';
import type { Book } from '../src/library-api.ts';
import { availableTitles, totalCopies, newestFirst, formatBook, shelfLabel, returnCopy } from '../src/part1-catalog.ts';
import { codeWithoutComments } from './source-check.ts';

const cleanCode: Book = { isbn: '978-0132350884', title: 'Clean Code', author: 'Robert C. Martin', genre: 'technology', year: 2008, copies: 2, location: { shelf: 'T-12', floor: 2 } };
const sapiens: Book = { isbn: '978-0062316097', title: 'Sapiens', author: 'Yuval Noah Harari', genre: 'history', year: 2015, copies: 3 };
const dune: Book = { isbn: '978-0441172719', title: 'Dune', author: 'Frank Herbert', genre: 'fiction', year: 1965, copies: 0, location: { shelf: 'F-07', floor: 1 } };
const books = (): Book[] => [cleanCode, dune, sapiens].map(b => structuredClone(b));

test('Part 1: this file uses array methods, not loops', () => {
  const code = codeWithoutComments('part1-catalog.ts');
  assert.doesNotMatch(code, /\bfor\b|\bwhile\b/, 'Use filter, map, reduce and toSorted in Part 1, not for or while loops.');
});
test('Part 1: availableTitles', () => {
  assert.deepEqual(availableTitles(books()), ['Clean Code', 'Sapiens']);
  assert.deepEqual(availableTitles([]), []);
});
test('Part 1: totalCopies', () => {
  assert.equal(totalCopies(books()), 5);
  assert.equal(totalCopies([]), 0);
});
test('Part 1: newestFirst sorts by year, newest first', () => {
  assert.deepEqual(newestFirst(books()).map(b => b.title), ['Sapiens', 'Clean Code', 'Dune']);
});
test('Part 1: newestFirst does not change the array passed in', () => {
  const input = books();
  newestFirst(input);
  assert.deepEqual(input.map(b => b.title), ['Clean Code', 'Dune', 'Sapiens'], 'The input array was reordered. Use toSorted(), not sort().');
});
test('Part 1: formatBook', () => {
  assert.equal(formatBook(cleanCode), 'Clean Code by Robert C. Martin (2008): 2 available');
  assert.equal(formatBook(dune), 'Dune by Frank Herbert (1965): checked out');
});
test('Part 1: shelfLabel', () => {
  assert.equal(shelfLabel(cleanCode), 'T-12');
  assert.equal(shelfLabel(sapiens), 'Not shelved');
});
test('Part 1: returnCopy returns a new object with one more copy', () => {
  const original = structuredClone(dune);
  const result = returnCopy(original);
  assert.deepEqual(result, { ...dune, copies: 1 });
  assert.notEqual(result, original, 'returnCopy must return a new object, not the one passed in.');
  assert.equal(original.copies, 0, 'returnCopy changed the book passed in.');
});
