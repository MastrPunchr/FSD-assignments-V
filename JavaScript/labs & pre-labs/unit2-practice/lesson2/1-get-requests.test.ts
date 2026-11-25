import { test, beforeEach } from 'node:test';
import assert from 'node:assert/strict';
import { installFakeFetch, type RecordedRequest } from './fake-reqres.ts';
import { assertKeySent } from './key-check.ts';
import { getUserEmail, getFullName, getFirstNamesOnPage, getTotalUsers } from './1-get-requests.ts';

let requests: RecordedRequest[];
beforeEach(() => { requests = installFakeFetch(); });

test('getUserEmail', async () => {
  assert.equal(await getUserEmail(2), 'janet.weaver@reqres.in');
  assert.equal(await getUserEmail(11), 'george.edwards@reqres.in');
  assertKeySent(requests);
});
test('getFullName', async () => {
  assert.equal(await getFullName(7), 'Michael Lawson');
  assert.equal(await getFullName(1), 'George Bluth');
  assertKeySent(requests);
});
test('getFirstNamesOnPage', async () => {
  assert.deepEqual(await getFirstNamesOnPage(1), ['George', 'Janet', 'Emma', 'Eve', 'Charles', 'Tracey']);
  assert.deepEqual(await getFirstNamesOnPage(2), ['Michael', 'Lindsay', 'Tobias', 'Byron', 'George', 'Rachel']);
  assert.deepEqual(await getFirstNamesOnPage(3), []);
  assertKeySent(requests);
});
test('extra: getTotalUsers', async () => {
  assert.equal(await getTotalUsers(), 12);
  assertKeySent(requests);
});
