import { test, beforeEach } from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { installFakeFetch, type RecordedRequest } from './fake-reqres.ts';
import { assertKeySent } from './key-check.ts';
import { isUser, getCheckedUser, getCheckedUsers } from './3-checking-data.ts';

let requests: RecordedRequest[];
beforeEach(() => { requests = installFakeFetch(); });

const janet = { id: 2, email: 'janet.weaver@reqres.in', first_name: 'Janet', last_name: 'Weaver', avatar: 'x.jpg' };
const colour = { id: 2, name: 'fuchsia rose', year: 2001, color: '#C74375', pantone_value: '17-2031' };

test('isUser does not use "as"', () => {
  const code = readFileSync(new URL('./3-checking-data.ts', import.meta.url), 'utf8')
    .replace(/\/\/.*$/gm, '');
  const guard = code.slice(code.indexOf('function isUser'), code.indexOf('export async function getCheckedUser'));
  assert.doesNotMatch(guard, /\sas\s/, "Check each property with 'in' and typeof instead of using 'as'.");
});
test('isUser', () => {
  assert.equal(isUser(janet), true);
  assert.equal(isUser(colour), false);
  assert.equal(isUser(null), false);
  assert.equal(isUser('Janet'), false);
  assert.equal(isUser({ ...janet, id: '2' }), false, 'id must be a number');
  assert.equal(isUser({ ...janet, email: undefined }), false, 'email must be a string');
  assert.equal(isUser({ ...janet, first_name: 5 }), false, 'first_name must be a string');
  assert.equal(isUser({ ...janet, last_name: null }), false, 'last_name must be a string');
  const { avatar, ...noAvatar } = janet;
  assert.equal(isUser(noAvatar), false, 'avatar is required');
});
test('getCheckedUser', async () => {
  assert.equal((await getCheckedUser(2)).last_name, 'Weaver');
  assertKeySent(requests);
  await assert.rejects(getCheckedUser(23), { message: 'Request failed with status 404' });
  installFakeFetch({ overrides: { '/api/users/2': { status: 200, body: { data: colour } } } });
  await assert.rejects(getCheckedUser(2), { message: 'The response did not contain a user' });
});
test('extra: getCheckedUsers', async () => {
  assert.deepEqual((await getCheckedUsers(2)).map(user => user.first_name),
    ['Michael', 'Lindsay', 'Tobias', 'Byron', 'George', 'Rachel']);
  assertKeySent(requests);
  installFakeFetch({ overrides: { '/api/users': { status: 200, body: { data: [janet, colour] } } } });
  await assert.rejects(getCheckedUsers(1), { message: 'The response did not contain a list of users' });
  installFakeFetch({ overrides: { '/api/users': { status: 200, body: { data: janet } } } });
  await assert.rejects(getCheckedUsers(1), { message: 'The response did not contain a list of users' });
});
