import { test, beforeEach } from 'node:test';
import assert from 'node:assert/strict';
import { installFakeFetch, type RecordedRequest } from './fake-reqres.ts';
import { assertKeySent } from './key-check.ts';
import { getUser, getUserOrNull, describeUser } from './2-handling-errors.ts';

let requests: RecordedRequest[];
beforeEach(() => { requests = installFakeFetch(); });

test('getUser resolves with the user', async () => {
  const user = await getUser(2);
  assert.equal(user.first_name, 'Janet');
  assert.equal(user.email, 'janet.weaver@reqres.in');
  assertKeySent(requests);
});
test('getUser rejects when the status is not OK', async () => {
  await assert.rejects(getUser(23), { message: 'Request failed with status 404' });
});
test('getUserOrNull', async () => {
  assert.equal((await getUserOrNull(3))?.first_name, 'Emma');
  assert.equal(await getUserOrNull(23), null);
  installFakeFetch({ offline: true });
  assert.equal(await getUserOrNull(3), null, 'A network failure should also resolve with null.');
});
test('extra: describeUser', async () => {
  assert.equal(await describeUser(2), 'Janet Weaver (janet.weaver@reqres.in)');
  assert.equal(await describeUser(23), 'Could not load user 23: Request failed with status 404');
  installFakeFetch({ offline: true });
  assert.equal(await describeUser(2), 'Could not load user 2: fetch failed');
});
