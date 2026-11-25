// Part 4: Creating promises with new Promise (Unit 2, Lesson 1)
// Use new Promise, .then() and .catch() in this file. Do not use async or await.

import { loadFinePolicy, type FinePolicy } from './library-api.ts';

// Resolves (with no value) after ms milliseconds. Use setTimeout.
// Example: wait(500) resolves half a second after it is called.
export function wait(ms: number): Promise<void> {
  throw new Error('Not implemented');
}

// Wraps the callback-based loadFinePolicy (in library-api.ts) in a promise.
// Resolves with the policy, or rejects with the Error that loadFinePolicy passes to its callback.
// Example: loadFinePolicyAsync('south') resolves with { dailyRate: 0.25, maxFine: 5 }.
export function loadFinePolicyAsync(branch: string): Promise<FinePolicy> {
  throw new Error('Not implemented');
}

// Resolves with the branch's daily rate, or with 0 if the branch has no fine policy.
// Use loadFinePolicyAsync with .then() and .catch().
// Examples: getDailyRate('downtown') resolves with 0.5; getDailyRate('online') resolves with 0.
export function getDailyRate(branch: string): Promise<number> {
  throw new Error('Not implemented');
}
