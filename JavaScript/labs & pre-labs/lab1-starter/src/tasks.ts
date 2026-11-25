import type { ParseResult, Priority, SortDirection, Task } from "./types.ts";

// Each function below currently throws "Not implemented".
// Replace the `throw` line with your implementation.
// Run `npm test` to check your work: the tests for each part are labelled with the part number.

// ---------------------------------------------------------------------------
// Part 2: Loading untrusted data  (Lesson 3: unknown, narrowing, type guards)
// ---------------------------------------------------------------------------

// Returns true if value is exactly 'low', 'medium', or 'high'.
// Any other value, including 'HIGH', '', null, or a number, returns false.
export function isPriority(value: unknown): value is Priority {
  return value === "low" || value === "medium" || value === "high";
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
  if (
    typeof value !== "object" ||
    value === null ||
    !("id" in value) ||
    typeof value.id !== "number" ||
    !Number.isInteger(value.id) ||
    !("title" in value) ||
    typeof value.title !== "string" ||
    value.title.trim() === "" ||
    !("priority" in value) ||
    !isPriority(value.priority) ||
    !("duration" in value) ||
    typeof value.duration !== "number" ||
    !(value.duration > 0) ||
    !("done" in value) ||
    typeof value.done !== "boolean" ||
    ("tags" in value &&
      value.tags !== undefined &&
      (!Array.isArray(value.tags) ||
        !value.tags.every((tag) => typeof tag === "string")))
  ) {
    return false;
  }
  return true;
}

// Parses a JSON string and keeps only the entries that are valid tasks.
//   - Parse with JSON.parse() and store the result in a variable of type unknown.
//   - Do NOT catch JSON syntax errors: let the SyntaxError reach the caller.
//   - If the parsed data is not an array, throw new Error('Task data must be a JSON array.')
//   - Return the valid tasks, and the number of entries that were not valid tasks.
export function parseTasks(json: string): ParseResult {
  const data: unknown = JSON.parse(json);
  if (!Array.isArray(data)) {
    throw new Error("Task data must be a JSON array.");
  }
  const tasks = data.filter(isTask);
  return { tasks, invalidCount: data.length - tasks.length };
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
  const { title, priority, duration, done, tags } = task;
  const x = done? "x" : " ";
  const formattedTags = tags?.length? tags.map(tag => `#${tag}`).join(' '): "(no tags)";
  return `[${x}] ${title} | ${priority.toUpperCase()} | ${duration} min | ${formattedTags}`;
}

// Returns only the tasks with the given priority, in their original order.
export function getTasksByPriority(tasks: Task[], priority: Priority): Task[] {
  return tasks.filter((t) => t.priority === priority);
}

// Returns the sum of all task durations. Returns 0 for an empty list (it must not throw).
export function getTotalDuration(tasks: Task[]): number {
  let acc = 0;
  tasks.forEach(task => acc += task.duration);
  return acc;
}

// Returns the total duration for each priority, for example { low: 5, medium: 40, high: 165 }.
// All three priorities must appear, with 0 when no task has that priority.
// Use reduce() with { low: 0, medium: 0, high: 0 } as the initial value.
export function getDurationByPriority(tasks: Task[]): Record<Priority, number> {
  return tasks.reduce<Record<Priority, number>>( //this was a difficult function for me so I'm writing an explanation for my own sake. The <Record<Priority, number>> is telling reduce what type it is returning, and record is like a tuple but instead of just being x values it's an object of key value pairs. The lambda acts as the callback function and the {low: 0} line is just setting initial values for each key so that the kvps actually exist. This one took me WAY too long and I am kind of really embarrased by it.
    (totals, curr) => {
      totals[curr.priority] += curr.duration;
      return totals;
    }, {low: 0, medium: 0, high: 0}
  );
}

// Returns a NEW array sorted by duration: shortest first for 'asc' (the default),
// longest first for 'desc'. The original array must keep its order.
export function sortByDuration(
  tasks: Task[],
  direction: SortDirection = "asc",
): Task[] {
  return tasks.toSorted((a, b) => direction === "asc"? a.duration - b.duration : b.duration - a.duration);
}

// Returns a NEW array in which the task with the given id has done: true.
// Do not change the original task object: create a new one with the spread operator.
// Every other task stays exactly as it was.
export function completeTask(tasks: Task[], id: number): Task[] {
  return tasks.map(task => task.id === id? {...task, done: true} : task);
}

// Counts how many tasks use each tag, for example { work: 3, writing: 1, code: 2 }.
// Tasks without tags contribute nothing. Returns {} if no task has tags.
export function getTagCounts(tasks: Task[]): Record<string, number> {
  return tasks.reduce<Record<string, number>>((counts, task) => {
    for(const tag of task.tags ?? []){
      counts[tag] = (counts[tag] ?? 0) + 1;
    }
    return counts;
  } ,{});
}

// ---------------------------------------------------------------------------
// Part 4 (optional challenge)
// ---------------------------------------------------------------------------

// Returns the names of the n most-used tags, most-used first.
// Tags with the same count are ordered alphabetically.
// Example: getTopTags(tasks, 2) might return ['work', 'code'].
// Hint: Object.entries(getTagCounts(tasks)), then toSorted(), slice(), and map().
export function getTopTags(tasks: Task[], n: number): string[] {
  return Object.entries(getTagCounts(tasks)).toSorted((a, b) => b[1] - a[1] || a[0].localeCompare(b[0])).slice(0, n).map(arr => `${arr[0]}`);
}
