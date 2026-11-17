// Lesson 1, Cycle 5: Common mistakes with promises and await
// Each function below has one bug. The bug is in the code, not in the types:
// fix the code, and do not change any function's signature.
// Two of the bugs are reported by `npm run typecheck`. The tests catch the other two.

import { getUser, getOrders, type User } from './api.ts';

// Resolves with the number of orders the user has placed.
export async function countOrders(userId: number): Promise<number> {
  const orders = getOrders(userId);
  return orders.length;
}

// Resolves with the user's email.
export function getUserEmail(id: number): Promise<string> {
  return getUser(id).then(user => {
    user.email;
  });
}

// Resolves with the user, or null if getUser rejects.
export async function findUser(id: number): Promise<User | null> {
  try {
    return getUser(id);
  } catch {
    return null;
  }
}

// Extra (if you finish early):
// Resolves with the total of all orders placed by all of these users.
export async function getTotalForUsers(userIds: number[]): Promise<number> {
  let total = 0;
  userIds.forEach(async id => {
    const orders = await getOrders(id);
    total += orders.reduce((sum, order) => sum + order.total, 0);
  });
  return total;
}
