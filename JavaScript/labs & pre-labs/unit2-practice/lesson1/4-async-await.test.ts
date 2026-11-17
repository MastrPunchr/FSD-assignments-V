import { test } from 'node:test';
import assert from 'node:assert/strict';
import { describeUser, getUserOrNull, getSpendingReport, getFirstExistingUser } from './4-async-await.ts';
import { codeWithoutComments } from './source-check.ts';

test('this file uses await, not .then() or .catch()', () => {
  const code = codeWithoutComments('./4-async-await.ts');
  assert.doesNotMatch(code, /\.then\(|\.catch\(/, 'Use await and try/catch in this file instead of .then() and .catch().');
});
test('describeUser', async () => {
  assert.equal(await describeUser(1), 'Ana Silva has 2 orders');
  assert.equal(await describeUser(3), 'Chen Wei has 0 orders');
  await assert.rejects(describeUser(999), { message: 'User 999 not found' });
});
test('getUserOrNull', async () => {
  assert.deepEqual(await getUserOrNull(2), { id: 2, name: 'Ben Okafor', email: 'ben@mitt.ca' });
  assert.equal(await getUserOrNull(999), null);
});
test('getSpendingReport', async () => {
  assert.equal(await getSpendingReport(1), 'Ana Silva spent $65');
  assert.equal(await getSpendingReport(3), 'Chen Wei spent $0');
  assert.equal(await getSpendingReport(999), 'Error: User 999 not found');
});
test('extra: getFirstExistingUser', async () => {
  assert.equal((await getFirstExistingUser([998, 999, 3, 1]))?.name, 'Chen Wei');
  assert.equal(await getFirstExistingUser([998, 999]), null);
  assert.equal(await getFirstExistingUser([]), null);
});
