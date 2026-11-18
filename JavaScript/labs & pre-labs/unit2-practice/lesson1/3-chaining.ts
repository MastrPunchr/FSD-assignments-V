// Lesson 1, Cycle 3: Chaining promises
// Use .then() and .catch() in this file. Do not use async or await yet.
// Write one flat chain: return the next promise from inside .then(), do not nest .then() calls.

import { getUser, getOrders } from './api.ts';

// Resolves with the number of orders placed by the user with this id.
// First get the user (so an unknown id rejects), then get that user's orders.
// Example: getOrderCount(1) resolves with 2. getOrderCount(999) rejects.
export function getOrderCount(id: number): Promise<number> {
  return getUser(id)
    .then(user => getOrders(user.id))
    .then(orders => orders.length);
}

// Like getOrderCount, but resolves with 0 if any step fails.
// Use a single .catch() at the end of the chain.
export function getOrderCountOrZero(id: number): Promise<number> {
  return getOrderCount(id).catch(() => 0);
}

// Extra (if you finish early):
// Resolves with the sum of the user's order totals.
// Example: getTotalSpent(1) resolves with 65.
export function getTotalSpent(id: number): Promise<number> {
  return getUser(id)
    .then(user => getOrders(user.id))
    .then(orders => orders.reduce((sum, order) => sum + order.total, 0));
}
