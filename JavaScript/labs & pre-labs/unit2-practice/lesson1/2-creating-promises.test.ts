import { test } from 'node:test';
import assert from 'node:assert/strict';
import { delay, loadSettingsAsync, getThemeOrDefault } from './2-creating-promises.ts';

test('delay waits for the given time, then resolves with no value', async () => {
  const result = delay(100);
  assert.ok(result instanceof Promise, 'delay must return a promise');
  const start = performance.now();
  assert.equal(await result, undefined);
  const elapsed = performance.now() - start;
  assert.ok(elapsed >= 90, `delay(100) resolved after only ${Math.round(elapsed)} ms`);
});
test('delay does not block: code after the call runs first', async () => {
  const events: string[] = [];
  const done = delay(30).then(() => events.push('resolved'));
  events.push('next line');
  await done;
  assert.deepEqual(events, ['next line', 'resolved']);
});
test('loadSettingsAsync resolves with the settings', async () => {
  const result = loadSettingsAsync('ana');
  assert.ok(result instanceof Promise, 'loadSettingsAsync must return a promise');
  assert.deepEqual(await result, { theme: 'dark', fontSize: 16 });
});
test('loadSettingsAsync rejects with the error from loadSettings', async () => {
  await assert.rejects(loadSettingsAsync('zoe'), { message: 'No settings saved for zoe' });
});
test('extra: getThemeOrDefault', async () => {
  assert.equal(await getThemeOrDefault('ana'), 'dark');
  assert.equal(await getThemeOrDefault('ben'), 'light');
  assert.equal(await getThemeOrDefault('zoe'), 'light');
});
