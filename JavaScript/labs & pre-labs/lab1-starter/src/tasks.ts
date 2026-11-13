import type { ParseResult, Priority, SortDirection, Task } from './types.ts';

// Each function below currently throws "Not implemented".
// Replace the `throw` line with your implementation.
// Run `npm test` to check your work: the tests for each part are labelled with the part number.

// ---------------------------------------------------------------------------
// Part 2: Loading untrusted data  (Lesson 3: unknown, narrowing, type guards)
// ---------------------------------------------------------------------------

// Returns true if value is exactly 'low', 'medium', or 'high'.
// Any other value, including 'HIGH', '', null, or a number, returns false.
export function isPriority(value: unknown): value is Priority {
  throw new Error('Not implemented');
}

// Returns true if value is a valid Task:
//   - value is an object and not null
//   - id is a whole number                 (hint: Number.isInteger)
//   - title is a string that is not empty or only spaces
//   - priority passes isPriority()
//   - duration is a number greater than 0
//   - done is a boolean
//   - tags is either missing/undefined, or an array in which every element is a string
// Check each property with `'name' in value` before reading it (see the isUser example in Lesson 3).
export function isTask(value: unknown): value is Task {
  throw new Error('Not implemented');
}

// Parses a JSON string and keeps only the entries that are valid tasks.
//   - Parse with JSON.parse() and store the result in a variable of type unknown.
//   - Do NOT catch JSON syntax errors: let the SyntaxError reach the caller.
//   - If the parsed data is not an array, throw new Error('Task data must be a JSON array.')
//   - Return the valid tasks, and the number of entries that were not valid tasks.
export function parseTasks(json: string): ParseResult {
  throw new Error('Not implemented');
}

// ---------------------------------------------------------------------------
// Part 3: Processing tasks  (Lessons 1 and 2)
// None of these functions may change the array or the task objects passed in.
// ---------------------------------------------------------------------------

// Formats one task as a single line of text:
//   "[ ] Write report | HIGH | 45 min | #work #writing"   (incomplete task with tags)
//   "[x] Buy milk | LOW | 5 min | (no tags)"              (complete task, no tags)
// A task whose tags array is missing OR empty shows "(no tags)".
// Use destructuring, a ternary, and optional chaining.
export function formatTask(task: Task): string {
  throw new Error('Not implemented');
}

// Returns only the tasks with the given priority, in their original order.
export function getTasksByPriority(tasks: Task[], priority: Priority): Task[] {
  throw new Error('Not implemented');
}

// Returns the sum of all task durations. Returns 0 for an empty list (it must not throw).
export function getTotalDuration(tasks: Task[]): number {
  throw new Error('Not implemented');
}

// Returns the total duration for each priority, for example { low: 5, medium: 40, high: 165 }.
// All three priorities must appear, with 0 when no task has that priority.
// Use reduce() with { low: 0, medium: 0, high: 0 } as the initial value.
export function getDurationByPriority(tasks: Task[]): Record<Priority, number> {
  throw new Error('Not implemented');
}

// Returns a NEW array sorted by duration: shortest first for 'asc' (the default),
// longest first for 'desc'. The original array must keep its order.
export function sortByDuration(tasks: Task[], direction: SortDirection = 'asc'): Task[] {
  throw new Error('Not implemented');
}

// Returns a NEW array in which the task with the given id has done: true.
// Do not change the original task object: create a new one with the spread operator.
// Every other task stays exactly as it was.
export function completeTask(tasks: Task[], id: number): Task[] {
  throw new Error('Not implemented');
}

// Counts how many tasks use each tag, for example { work: 3, writing: 1, code: 2 }.
// Tasks without tags contribute nothing. Returns {} if no task has tags.
export function getTagCounts(tasks: Task[]): Record<string, number> {
  throw new Error('Not implemented');
}

// ---------------------------------------------------------------------------
// Part 4 (optional challenge)
// ---------------------------------------------------------------------------

// Returns the names of the n most-used tags, most-used first.
// Tags with the same count are ordered alphabetically.
// Example: getTopTags(tasks, 2) might return ['work', 'code'].
// Hint: Object.entries(getTagCounts(tasks)), then toSorted(), slice(), and map().
export function getTopTags(tasks: Task[], n: number): string[] {
  throw new Error('Not implemented');
}
