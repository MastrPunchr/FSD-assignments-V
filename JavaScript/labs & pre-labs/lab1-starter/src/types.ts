// Part 1: Types used throughout the lab.
// Until you finish Part 1, `npm run typecheck` reports errors in index.ts and the
// test file, because they use properties that the Task interface does not have yet.

// TODO (Part 1, step 1): Replace `string` with a union of the three literal types
// 'low', 'medium', and 'high'.
export type Priority = string;

// TODO (Part 1, step 2): Replace `string` with a union of the literal types 'asc' and 'desc'.
export type SortDirection = string;

// TODO (Part 1, step 3): Add the six properties of a task, as listed in the lab instructions.
export interface Task {}

// The result of parseTasks(): the valid tasks, and how many entries were rejected.
// (Provided: you do not need to change this.)
export interface ParseResult {
  tasks: Task[];
  invalidCount: number;
}
