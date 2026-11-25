import { test } from 'node:test';
import assert from 'node:assert/strict';
import { isGenre, isLocation, isBook, validBooks, errorMessage } from '../src/part2-validation.ts';
import { codeWithoutComments } from './source-check.ts';

const valid = { isbn: '978-0132350884', title: 'Clean Code', author: 'Robert C. Martin', genre: 'technology', year: 2008, copies: 2, location: { shelf: 'T-12', floor: 2 } };
const noLocation = { isbn: '978-0062316097', title: 'Sapiens', author: 'Yuval Noah Harari', genre: 'history', year: 2015, copies: 3 };

test('Part 2: this file does not use any or type assertions', () => {
  const code = codeWithoutComments('part2-validation.ts');
  assert.doesNotMatch(code, /\bany\b/, 'Do not use any in Part 2.');
  assert.doesNotMatch(code, /\bas\s+[A-Za-z{[]/, 'Do not use type assertions (as) in Part 2. Check the value instead.');
});
test('Part 2: isGenre', () => {
  for (const genre of ['fiction', 'science', 'history', 'technology']) {
    assert.equal(isGenre(genre), true, `isGenre('${genre}') should be true`);
  }
  assert.equal(isGenre('poetry'), false);
  assert.equal(isGenre(42), false);
  assert.equal(isGenre(undefined), false);
});
test('Part 2: isLocation', () => {
  assert.equal(isLocation({ shelf: 'T-12', floor: 2 }), true);
  assert.equal(isLocation({ shelf: 'T-12' }), false);
  assert.equal(isLocation({ shelf: 12, floor: 2 }), false);
  assert.equal(isLocation(null), false);
});
test('Part 2: isBook accepts valid books, with or without a location', () => {
  assert.equal(isBook(valid), true);
  assert.equal(isBook(noLocation), true);
});
test('Part 2: isBook rejects damaged records', () => {
  const { author, ...missingAuthor } = valid;
  assert.equal(isBook(missingAuthor), false, 'a record with no author');
  assert.equal(isBook({ ...valid, genre: 'poetry' }), false, 'a record with an unknown genre');
  assert.equal(isBook({ ...valid, year: '2008' }), false, 'a record whose year is a string');
  assert.equal(isBook({ ...valid, location: { shelf: 'T-12' } }), false, 'a record whose location has no floor');
  assert.equal(isBook(null), false, 'null');
  assert.equal(isBook('Clean Code'), false, 'a string');
});
test('Part 2: validBooks keeps only the valid books, in order', () => {
  const records: unknown[] = [valid, null, { ...valid, copies: 'two' }, noLocation, 'Dune'];
  assert.deepEqual(validBooks(records), [valid, noLocation]);
  assert.deepEqual(validBooks([]), []);
});
test('Part 2: errorMessage', () => {
  assert.equal(errorMessage(new Error('Member 999 not found')), 'Member 999 not found');
  assert.equal(errorMessage('Server is down'), 'Server is down');
  assert.equal(errorMessage(404), 'Unknown error');
  assert.equal(errorMessage(undefined), 'Unknown error');
});
