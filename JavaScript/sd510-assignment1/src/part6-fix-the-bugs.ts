// Part 6: Find and fix the bugs (Unit 2, Lesson 1)
// Each function below has exactly one bug. The bug is in the code, not in the types:
// fix the code, and do not change any function's signature (its name, parameters, or return type).
// Two of the bugs are reported by `npm run typecheck`. The tests catch the other two.
//
// Above each function, replace the two TODO lines with:
//   // Bug: what was wrong, and what it made the function do, in one or two sentences
//   // Found by: typecheck   or   // Found by: tests

import { getMember, getBook, getLoans, type Book } from './library-api.ts';

// TODO Bug:
// TODO Found by:
// Resolves with the member's email address.
export async function getMemberEmail(id: number): Promise<string> {
  const member = getMember(id);
  return member.email;
}

// TODO Bug:
// TODO Found by:
// Resolves with the book's title in capital letters.
export function getTitleInCapitals(isbn: string): Promise<string> {
  return getBook(isbn).then(book => {
    book.title.toUpperCase();
  });
}

// TODO Bug:
// TODO Found by:
// Resolves with the book, or null if there is no book with this ISBN.
export async function findBook(isbn: string): Promise<Book | null> {
  try {
    return getBook(isbn);
  } catch {
    return null;
  }
}

// TODO Bug:
// TODO Found by:
// Resolves with the number of overdue loans (not returned, daysOverdue greater than 0)
// across all of these members.
export async function countOverdueLoans(memberIds: number[]): Promise<number> {
  let count = 0;
  memberIds.forEach(async id => {
    const loans = await getLoans(id);
    count += loans.filter(loan => !loan.returned && loan.daysOverdue > 0).length;
  });
  return count;
}
