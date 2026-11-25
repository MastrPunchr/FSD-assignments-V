import { test } from 'node:test';
import assert from 'node:assert/strict';
import { getMemberEmail, getTitleInCapitals, findBook, countOverdueLoans } from '../src/part6-fix-the-bugs.ts';

test('Part 6: getMemberEmail', async () => {
  assert.equal(await getMemberEmail(1), 'ana@example.com');
});
test('Part 6: getTitleInCapitals', async () => {
  assert.equal(await getTitleInCapitals('978-0441172719'), 'DUNE');
});
test('Part 6: findBook', async () => {
  assert.equal((await findBook('978-0132350884'))?.title, 'Clean Code');
  assert.equal(await findBook('000'), null);
});
test('Part 6: countOverdueLoans', async () => {
  assert.equal(await countOverdueLoans([1, 2]), 2);
  assert.equal(await countOverdueLoans([3]), 0);
  assert.equal(await countOverdueLoans([]), 0);
});
