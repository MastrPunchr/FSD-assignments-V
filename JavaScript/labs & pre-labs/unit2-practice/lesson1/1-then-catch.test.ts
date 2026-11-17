import { test } from 'node:test';
import assert from 'node:assert/strict';
import { getUserName, getUserNameOrDefault, getEmailDomain } from './1-then-catch.ts';
import { codeWithoutComments } from './source-check.ts';

test('this file uses .then() and .catch(), not async or await', () => {
  const code = codeWithoutComments('./1-then-catch.ts');
  assert.doesNotMatch(code, /\bawait\b|\basync\b/, 'Remove async and await. Practise .then() and .catch() in this file.');
});
test('getUserName', async () => {
  const result = getUserName(1);
  assert.ok(result instanceof Promise, 'getUserName must return a promise');
  assert.equal(await result, 'Ana Silva');
  assert.equal(await getUserName(3), 'Chen Wei');
  await assert.rejects(getUserName(999), { message: 'User 999 not found' });
});
test('getUserNameOrDefault', async () => {
  assert.equal(await getUserNameOrDefault(2), 'Ben Okafor');
  assert.equal(await getUserNameOrDefault(999), 'Unknown user');
});
test('extra: getEmailDomain', async () => {
  assert.equal(await getEmailDomain(2), 'mitt.ca');
  assert.equal(await getEmailDomain(1), 'example.com');
});
