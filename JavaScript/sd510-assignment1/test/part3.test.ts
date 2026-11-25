import { test } from 'node:test';
import assert from 'node:assert/strict';
import { getMemberName, getMemberNameOrDefault, countActiveLoans, isBookAvailable } from '../src/part3-then-catch.ts';
import { codeWithoutComments } from './source-check.ts';

test('Part 3: this file uses .then() and .catch(), not async or await', () => {
  const code = codeWithoutComments('part3-then-catch.ts');
  assert.doesNotMatch(code, /\bawait\b|\basync\b/, 'Remove async and await. Part 3 is practice with .then() and .catch().');
});
test('Part 3: getMemberName', async () => {
  const result = getMemberName(2);
  assert.ok(result instanceof Promise, 'getMemberName must return a promise');
  assert.equal(await result, 'Ben Okafor');
  await assert.rejects(getMemberName(999), { message: 'Member 999 not found' });
});
test('Part 3: getMemberNameOrDefault', async () => {
  assert.equal(await getMemberNameOrDefault(1), 'Ana Silva');
  assert.equal(await getMemberNameOrDefault(999), 'Unknown member');
});
test('Part 3: countActiveLoans', async () => {
  assert.equal(await countActiveLoans(1), 2);
  assert.equal(await countActiveLoans(3), 0);
  await assert.rejects(countActiveLoans(999), { message: 'Member 999 not found' });
});
test('Part 3: isBookAvailable', async () => {
  assert.equal(await isBookAvailable('978-0132350884'), true);
  assert.equal(await isBookAvailable('978-0441172719'), false);
  assert.equal(await isBookAvailable('000'), false);
});
