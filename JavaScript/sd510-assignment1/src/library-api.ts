// A simulated library web API for Assignment 1. Do not change this file.
//
// It works the same way as lesson1/api.ts from Unit 2, Lesson 1: each function waits a
// short time before answering, like a request to a real server. Read this whole file
// before you start; every part of the assignment uses it.

// ---------- Types ----------

export type Genre = 'fiction' | 'science' | 'history' | 'technology';

export interface Location {
  shelf: string;
  floor: number;
}

export interface Book {
  isbn: string;
  title: string;
  author: string;
  genre: Genre;
  year: number;
  copies: number; // copies on the shelf right now (0 means every copy is checked out)
  location?: Location; // missing if the book has not been given a shelf yet
}

export type Branch = 'south' | 'downtown' | 'online';

export interface Member {
  id: number;
  name: string;
  email: string;
  branch: Branch; // the member's home branch
}

export interface Loan {
  id: number;
  memberId: number;
  isbn: string;
  daysOverdue: number; // 0 if the loan is not overdue
  returned: boolean; // true once the book has been brought back
}

export interface FinePolicy {
  dailyRate: number; // dollars charged per day overdue
  maxFine: number; // the most that one loan can be charged, in dollars
}

// ---------- Data stored on the "server" ----------

const books: Book[] = [
  { isbn: '978-0132350884', title: 'Clean Code', author: 'Robert C. Martin', genre: 'technology', year: 2008, copies: 2, location: { shelf: 'T-12', floor: 2 } },
  { isbn: '978-0137081073', title: 'The Clean Coder', author: 'Robert C. Martin', genre: 'technology', year: 2011, copies: 1, location: { shelf: 'T-12', floor: 2 } },
  { isbn: '978-1593279509', title: 'Eloquent JavaScript', author: 'Marijn Haverbeke', genre: 'technology', year: 2018, copies: 0, location: { shelf: 'T-14', floor: 2 } },
  { isbn: '978-0553380163', title: 'A Brief History of Time', author: 'Stephen Hawking', genre: 'science', year: 1988, copies: 1, location: { shelf: 'S-03', floor: 1 } },
  { isbn: '978-0062316097', title: 'Sapiens', author: 'Yuval Noah Harari', genre: 'history', year: 2015, copies: 3 },
  { isbn: '978-0441172719', title: 'Dune', author: 'Frank Herbert', genre: 'fiction', year: 1965, copies: 0, location: { shelf: 'F-07', floor: 1 } },
];

const members: Member[] = [
  { id: 1, name: 'Ana Silva', email: 'ana@example.com', branch: 'south' },
  { id: 2, name: 'Ben Okafor', email: 'ben@mitt.ca', branch: 'downtown' },
  { id: 3, name: 'Chen Wei', email: 'chen@example.com', branch: 'online' },
  { id: 4, name: 'Dana Kaur', email: 'dana@mitt.ca', branch: 'south' },
];

const loans: Loan[] = [
  { id: 501, memberId: 1, isbn: '978-0132350884', daysOverdue: 0, returned: false },
  { id: 502, memberId: 1, isbn: '978-0441172719', daysOverdue: 4, returned: false },
  { id: 503, memberId: 1, isbn: '978-0062316097', daysOverdue: 0, returned: true },
  { id: 504, memberId: 2, isbn: '978-1593279509', daysOverdue: 30, returned: false },
  { id: 505, memberId: 4, isbn: '978-0553380163', daysOverdue: 2, returned: false },
  { id: 506, memberId: 4, isbn: '978-1593279509', daysOverdue: 0, returned: true },
];

const finePolicies: Record<string, FinePolicy> = {
  south: { dailyRate: 0.25, maxFine: 5 },
  downtown: { dailyRate: 0.5, maxFine: 10 },
};

// Records exported from the library's old catalog system. Some of them are damaged.
const importedRecords: unknown[] = [
  { isbn: '978-0596517748', title: 'JavaScript: The Good Parts', author: 'Douglas Crockford', genre: 'technology', year: 2008, copies: 1, location: { shelf: 'T-13', floor: 2 } },
  { isbn: '978-0062316097', title: 'Sapiens', author: 'Yuval Noah Harari', genre: 'history', year: 2015, copies: 3 },
  { isbn: '978-0441013593', title: 'Dune Messiah', genre: 'fiction', year: 1969, copies: 2 },
  { isbn: '978-0307474278', title: 'The Road', author: 'Cormac McCarthy', genre: 'poetry', year: 2006, copies: 1 },
  { isbn: '978-0553380163', title: 'A Brief History of Time', author: 'Stephen Hawking', genre: 'science', year: 1988, copies: 1, location: { shelf: 'S-03', floor: 1 } },
  null,
  { isbn: '978-0143127550', title: 'Everything I Never Told You', author: 'Celeste Ng', genre: 'fiction', year: '2014', copies: 2 },
  'Clean Code, Robert C. Martin, 2008',
  { isbn: '978-0441172719', title: 'Dune', author: 'Frank Herbert', genre: 'fiction', year: 1965, copies: 0, location: { shelf: 'F-07' } },
  { isbn: '978-1491904244', title: "You Don't Know JS Yet", author: 'Kyle Simpson', genre: 'technology', year: 2020, copies: 0 },
];

const RESPONSE_TIME_MS = 20;

// ---------- API functions ----------

// Resolves with the member who has this id.
// Rejects with an Error if no member has this id. Example message: 'Member 999 not found'
export function getMember(id: number): Promise<Member> {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const member = members.find(m => m.id === id);
      if (member) {
        resolve({ ...member });
      } else {
        reject(new Error(`Member ${id} not found`));
      }
    }, RESPONSE_TIME_MS);
  });
}

// Resolves with the book that has this ISBN.
// Rejects with an Error if no book has this ISBN. Example message: 'Book 000 not found'
export function getBook(isbn: string): Promise<Book> {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const book = books.find(b => b.isbn === isbn);
      if (book) {
        resolve(structuredClone(book));
      } else {
        reject(new Error(`Book ${isbn} not found`));
      }
    }, RESPONSE_TIME_MS);
  });
}

// Resolves with every loan for this member id, returned and not returned, oldest first.
// Resolves with [] if the member has no loans. It never rejects, even for an unknown id.
export function getLoans(memberId: number): Promise<Loan[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(loans.filter(l => l.memberId === memberId).map(l => ({ ...l })));
    }, RESPONSE_TIME_MS);
  });
}

// Resolves with the records from the old catalog system. Each record has the type unknown,
// because nothing checked them: some are valid books and some are damaged.
export function getImportedRecords(): Promise<unknown[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(structuredClone(importedRecords));
    }, RESPONSE_TIME_MS);
  });
}

// An older, callback-based function. It does not return a promise.
// It calls callback(null, policy) on success, or callback(error) if the branch has no fine policy.
// Example error message: 'No fine policy for branch online'
export function loadFinePolicy(
  branch: string,
  callback: (error: Error | null, policy?: FinePolicy) => void,
): void {
  setTimeout(() => {
    const policy = finePolicies[branch];
    if (policy) {
      callback(null, { ...policy });
    } else {
      callback(new Error(`No fine policy for branch ${branch}`));
    }
  }, RESPONSE_TIME_MS);
}
