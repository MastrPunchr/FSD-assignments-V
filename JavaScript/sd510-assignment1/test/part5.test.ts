import { test } from 'node:test';
import assert from 'node:assert/strict';
import { describeMember, findMember, getBorrowedTitles, calculateFine, memberReport, loadImportedCatalog } from '../src/part5-async-await.ts';
import { codeWithoutComments } from './source-check.ts';

test('Part 5: this file uses await, not .then() or .catch()', () => {
  const code = codeWithoutComments('part5-async-await.ts');
  assert.doesNotMatch(code, /\.then\(|\.catch\(/, 'Use await and try/catch in Part 5 instead of .then() and .catch().');
});
test('Part 5: describeMember', async () => {
  assert.equal(await describeMember(1), 'Ana Silva has 2 active loans');
  assert.equal(await describeMember(2), 'Ben Okafor has 1 active loan');
  assert.equal(await describeMember(3), 'Chen Wei has 0 active loans');
  await assert.rejects(describeMember(999), { message: 'Member 999 not found' });
});
test('Part 5: findMember', async () => {
  assert.deepEqual(await findMember(2), { id: 2, name: 'Ben Okafor', email: 'ben@mitt.ca', branch: 'downtown' });
  assert.equal(await findMember(999), null);
});
test('Part 5: getBorrowedTitles', async () => {
  assert.deepEqual(await getBorrowedTitles(1), ['Clean Code', 'Dune']);
  assert.deepEqual(await getBorrowedTitles(3), []);
});
test('Part 5: calculateFine', async () => {
  assert.equal(await calculateFine(1), 1);
  assert.equal(await calculateFine(2), 10, 'Ben is 30 days overdue at $0.50 a day, so his fine is capped at maxFine ($10).');
  await assert.rejects(calculateFine(3), { message: 'No fine policy for branch online' });
  await assert.rejects(calculateFine(999), { message: 'Member 999 not found' });
});
test('Part 5: memberReport', async () => {
  assert.equal(await memberReport(1), 'Ana Silva has 2 active loans and owes $1.00');
  assert.equal(await memberReport(2), 'Ben Okafor has 1 active loan and owes $10.00');
  assert.equal(await memberReport(3), 'Error: No fine policy for branch online');
  assert.equal(await memberReport(999), 'Error: Member 999 not found');
});
test('Part 5: loadImportedCatalog', async () => {
  const catalog = await loadImportedCatalog();
  assert.deepEqual(catalog.map(b => b.title), ['JavaScript: The Good Parts', 'Sapiens', 'A Brief History of Time', "You Don't Know JS Yet"]);
});
