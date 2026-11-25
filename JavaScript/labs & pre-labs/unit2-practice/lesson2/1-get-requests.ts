// Lesson 2, Exercise 1: Sending GET requests with fetch
// Use async and await. Send your API key in the x-api-key header with every request.
// Lesson 2, Part 2 shows every step you need.

import { API_KEY } from '../config.ts';

type User = {
  id: number;
  email: string;
  first_name: string;
  last_name: string;
  avatar: string;
};

const BASE_URL = 'https://reqres.in/api';

// Resolves with the email address of the user with this id.
// Example: getUserEmail(2) resolves with 'janet.weaver@reqres.in'.
export async function getUserEmail(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Resolves with the user's first and last name, separated by a space.
// Example: getFullName(7) resolves with 'Michael Lawson'.
export async function getFullName(id: number): Promise<string> {
  throw new Error('Not implemented');
}

// Resolves with the first names of every user on this page, in order.
// Request the URL ${BASE_URL}/users?page=<page>.
// Example: getFirstNamesOnPage(1) resolves with ['George', 'Janet', 'Emma', 'Eve', 'Charles', 'Tracey'].
export async function getFirstNamesOnPage(page: number): Promise<string[]> {
  throw new Error('Not implemented');
}

// Extra (if you finish early):
// Resolves with the total number of users the API has. The list response has a property for it.
// Example: getTotalUsers() resolves with 12.
export async function getTotalUsers(): Promise<number> {
  throw new Error('Not implemented');
}
