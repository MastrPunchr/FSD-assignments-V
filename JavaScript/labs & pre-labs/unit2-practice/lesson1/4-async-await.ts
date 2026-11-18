// Lesson 1, Cycle 4: async and await
// Use async and await in this file, with try/catch for errors. Do not use .then() or .catch().

import { getUser, getOrders, type User } from './api.ts';

// Resolves with a sentence describing the user and their order count.
// Example: describeUser(1) resolves with 'Ana Silva has 2 orders'.
// An unknown id rejects (do not catch the error here).
export async function describeUser(id: number): Promise<string> {
  const user = await getUser(id);
  const orders = await getOrders(id);
  return `${user.name} has ${orders.length} orders`;
}

// Resolves with the user, or with null if getUser rejects.
export async function getUserOrNull(id: number): Promise<User | null> {
  try{
    return await getUser(id);
  }
  catch {
    return null;
  }
}

// Resolves with 'Ana Silva spent $65' for user 1.
// If anything fails, resolves with 'Error: ' followed by the error's message,
// for example 'Error: User 999 not found'. The caught value is unknown: check it is an Error first.
export async function getSpendingReport(id: number): Promise<string> {
  try {
    const user = await getUser(id);
    const orders = await getOrders(user.id);
    const total = orders.reduce((sum, order) => sum + order.total, 0);
    return `${user.name} spent $${total}`;
  } 
  catch (error){
    const message = error instanceof Error ? error.message : 'Unknown error';
    return `Error: ${message}`;
  }
}

// Extra (if you finish early):
// Tries each id in order and resolves with the first user that exists, or null if none do.
// Use a for...of loop with await inside it.
export async function getFirstExistingUser(ids: number[]): Promise<User | null> {
  for(const id of ids){
    const user = await getUserOrNull(id);
    if (user){
      return user;
    }
  }
  return null;
}
