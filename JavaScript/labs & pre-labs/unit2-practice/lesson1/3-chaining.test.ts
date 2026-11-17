import { test } from 'node:test';
import assert from 'node:assert/strict';
import { getOrderCount, getOrderCountOrZero, getTotalSpent } from './3-chaining.ts';
import { codeWithoutComments } from './source-check.ts';

test('this file uses .then() and .catch(), not async or await', () => {
  const code = codeWithoutComments('./3-chaining.ts');
  assert.doesNotMatch(code, /\bawait\b|\basync\b/, 'Remove async and await. Practise chaining .then() in this file.');
});
test('getOrderCount', async () => {
  assert.equal(await getOrderCount(1), 2);
  assert.equal(await getOrderCount(2), 1);
  assert.equal(await getOrderCount(3), 0);
  await assert.rejects(getOrderCount(999), { message: 'User 999 not found' });
});
test('getOrderCountOrZero', async () => {
  assert.equal(await getOrderCountOrZero(1), 2);
  assert.equal(await getOrderCountOrZero(999), 0);
});
test('extra: getTotalSpent', async () => {
  assert.equal(await getTotalSpent(1), 65);
  assert.equal(await getTotalSpent(3), 0);
  await assert.rejects(getTotalSpent(999), { message: 'User 999 not found' });
});
