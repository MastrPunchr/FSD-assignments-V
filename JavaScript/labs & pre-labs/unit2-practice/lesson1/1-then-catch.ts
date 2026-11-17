// Lesson 1, Cycle 1: Reading a promise's result with .then() and .catch()
// Use .then() and .catch() in this file. Do not use async or await yet.
// Each function returns the promise that .then() or .catch() gives back.

import { getUser } from './api.ts';

// Resolves with the name of the user with this id.
// Example: getUserName(1) resolves with 'Ana Silva'.
export function getUserName(id: number): Promise<string> {
  return getUser(id).then(user => user.name);
}

// Like getUserName, but resolves with 'Unknown user' if getUser rejects.
export function getUserNameOrDefault(id: number): Promise<string> {
  return getUser(id).then(user => user.name).catch(() => 'Unknown user');
}

// Extra (if you finish early):
// Resolves with the part of the user's email after the @.
// Example: getEmailDomain(2) resolves with 'mitt.ca'.
export function getEmailDomain(id: number): Promise<string> {
  return getUser(id).then(user => user.email.slice(user.email.indexOf("@"+1)));
}
