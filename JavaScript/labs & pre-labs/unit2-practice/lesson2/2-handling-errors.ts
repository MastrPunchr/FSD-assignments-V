// Lesson 2, Exercise 2: Handling failed requests
// Use async and await. Send your API key in the x-api-key header with every request.
// Lesson 2, Part 3 shows every step you need.

import { API_KEY } from '../config.ts';

type User = {
  id: number;
  email: string;
  first_name: string;
  last_name: string;
  avatar: string;
};

const BASE_URL = 'https://reqres.in/api';

// Resolves with the user who has this id.
// If the response status is not OK, rejects with an Error whose message is
// 'Request failed with status <status>'.
// Example: getUser(23) rejects with 'Request failed with status 404'.
export async function getUser(id: number): Promise<User> {
  throw new Error('Not implemented');
}

// Resolves with the user who has this id, or with null if the request fails for any reason:
// a status that is not OK, or a network failure.
// Use getUser and try/catch.
// Example: getUserOrNull(23) resolves with null.
export async function getUserOrNull(id: number): Promise<User | null> {
  throw new Error('Not implemented');
}

// Extra (if you finish early):
// Resolves with '<first name> <last name> (<email>)' if the request succeeds,
// or with 'Could not load user <id>: <error message>' if it fails.
// Examples: describeUser(2) resolves with 'Janet Weaver (janet.weaver@reqres.in)'.
//           describeUser(23) resolves with 'Could not load user 23: Request failed with status 404'.
export async function describeUser(id: number): Promise<string> {
  throw new Error('Not implemented');
}
