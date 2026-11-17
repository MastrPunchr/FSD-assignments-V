import { test } from 'node:test';
import assert from 'node:assert/strict';
import { countOrders, getUserEmail, findUser, getTotalForUsers } from './5-fix-the-bugs.ts';

test('countOrders', async () => {
  assert.equal(await countOrders(1), 2);
  assert.equal(await countOrders(3), 0);
});
test('getUserEmail', async () => {
  assert.equal(await getUserEmail(1), 'ana@example.com');
});
test('findUser', async () => {
  assert.equal((await findUser(3))?.name, 'Chen Wei');
  assert.equal(await findUser(999), null);
});
test('extra: getTotalForUsers', async () => {
  assert.equal(await getTotalForUsers([1, 2]), 80);
  assert.equal(await getTotalForUsers([3]), 0);
  assert.equal(await getTotalForUsers([]), 0);
});
