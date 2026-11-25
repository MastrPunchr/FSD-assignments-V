import { test } from 'node:test';
import assert from 'node:assert/strict';
import { wait, loadFinePolicyAsync, getDailyRate } from '../src/part4-creating-promises.ts';
import { codeWithoutComments } from './source-check.ts';

test('Part 4: this file does not use async or await', () => {
  const code = codeWithoutComments('part4-creating-promises.ts');
  assert.doesNotMatch(code, /\bawait\b|\basync\b/, 'Remove async and await. Part 4 is practice with new Promise, .then() and .catch().');
});
test('Part 4: wait waits for the given time, then resolves with no value', async () => {
  const result = wait(100);
  assert.ok(result instanceof Promise, 'wait must return a promise');
  const start = performance.now();
  assert.equal(await result, undefined);
  const elapsed = performance.now() - start;
  assert.ok(elapsed >= 90, `wait(100) resolved after only ${Math.round(elapsed)} ms`);
});
test('Part 4: wait does not block: code after the call runs first', async () => {
  const events: string[] = [];
  const done = wait(30).then(() => events.push('resolved'));
  events.push('next line');
  await done;
  assert.deepEqual(events, ['next line', 'resolved']);
});
test('Part 4: loadFinePolicyAsync resolves with the policy', async () => {
  const result = loadFinePolicyAsync('south');
  assert.ok(result instanceof Promise, 'loadFinePolicyAsync must return a promise');
  assert.deepEqual(await result, { dailyRate: 0.25, maxFine: 5 });
});
test('Part 4: loadFinePolicyAsync rejects with the error from loadFinePolicy', async () => {
  await assert.rejects(loadFinePolicyAsync('online'), { message: 'No fine policy for branch online' });
});
test('Part 4: getDailyRate', async () => {
  assert.equal(await getDailyRate('downtown'), 0.5);
  assert.equal(await getDailyRate('online'), 0);
});
