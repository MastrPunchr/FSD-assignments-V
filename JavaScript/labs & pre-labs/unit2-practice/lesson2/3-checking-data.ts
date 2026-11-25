// Lesson 2, Exercise 3: Checking the data the server sends
// Lesson 2, Part 4 shows every step you need.

import { API_KEY } from '../config.ts';

export type User = {
  id: number;
  email: string;
  first_name: string;
  last_name: string;
  avatar: string;
};

const BASE_URL = 'https://reqres.in/api';

// Returns true only if value is an object with all five User properties, each with the right type.
// Do not use 'as'. Check each property with 'in' and typeof.
// Examples: isUser({ id: 2, email: 'a@b.c', first_name: 'A', last_name: 'B', avatar: 'x.jpg' }) returns true.
//           isUser({ id: 2, name: 'fuchsia rose' }) returns false. isUser(null) returns false.
export function isUser(value: unknown): value is User {
  throw new Error('Not implemented');
}

// Resolves with the user who has this id.
// Rejects with 'Request failed with status <status>' if the status is not OK.
// Rejects with 'The response did not contain a user' if body.data is not a User (use isUser).
export async function getCheckedUser(id: number): Promise<User> {
  throw new Error('Not implemented');
}

// Extra (if you finish early):
// Resolves with the users on this page.
// Rejects with 'Request failed with status <status>' if the status is not OK.
// Rejects with 'The response did not contain a list of users' if body.data is not an array
// or if any element is not a User.
export async function getCheckedUsers(page: number): Promise<User[]> {
  throw new Error('Not implemented');
}
