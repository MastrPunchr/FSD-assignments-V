// Task Manager: a menu-driven console app.
// This file is PROVIDED. You do not need to change it.
// It calls the functions you write in tasks.ts.

import { readFile } from 'node:fs/promises';
import * as readline from 'node:readline/promises';
import process, { stdin as input, stdout as output } from 'node:process';
import {
  completeTask,
  formatTask,
  getDurationByPriority,
  getTagCounts,
  getTasksByPriority,
  getTopTags,
  getTotalDuration,
  isPriority,
  parseTasks,
  sortByDuration,
} from './tasks.ts';
import type { Task } from './types.ts';

const rl = readline.createInterface({ input, output });

// Asks a question and returns the answer. Exits cleanly if input is closed (Ctrl+D or Ctrl+C).
async function ask(prompt: string): Promise<string> {
  try {
    return await rl.question(prompt);
  } catch {
    console.log('\nInput closed. Goodbye.');
    process.exit(0);
  }
}

// Runs one menu action and reports any error instead of crashing the app.
function run(action: () => void): void {
  try {
    action();
  } catch (error) {
    if (error instanceof Error && error.message === 'Not implemented') {
      console.log('This feature is not implemented yet.');
    } else if (error instanceof Error) {
      console.log(`Error: ${error.message}`);
    } else {
      console.log('An unknown error occurred.');
    }
  }
}

function printTasks(list: Task[]): void {
  if (list.length === 0) {
    console.log('No tasks to display.');
    return;
  }
  list.forEach(task => console.log(`${String(task.id).padStart(3)}  ${formatTask(task)}`));
}

// ---------------------------------------------------------------------------
// Load the task data from data/tasks.json
// ---------------------------------------------------------------------------
async function loadTasks(): Promise<Task[]> {
  const json = await readFile(new URL('../data/tasks.json', import.meta.url), 'utf8');
  try {
    const { tasks, invalidCount } = parseTasks(json);
    console.log(`Loaded ${tasks.length} tasks. Skipped ${invalidCount} invalid entries.`);
    return tasks;
  } catch (error) {
    if (error instanceof Error && error.message === 'Not implemented') {
      console.log('WARNING: parseTasks() is not implemented yet.');
      console.log('Loading the data WITHOUT validation. Some entries are invalid; watch what happens.');
      // `as Task[]` is a claim, not a check (Lesson 3). Part 2 replaces this with real validation.
      return JSON.parse(json) as Task[];
    }
    throw error;
  }
}

let tasks: Task[] = await loadTasks();

// ---------------------------------------------------------------------------
// Menu actions
// ---------------------------------------------------------------------------
async function filterByPriority(): Promise<void> {
  const answer = (await ask('Priority (low, medium, high): ')).trim().toLowerCase();
  run(() => {
    if (!isPriority(answer)) {
      console.log('Invalid priority.');
      return;
    }
    printTasks(getTasksByPriority(tasks, answer));
  });
}

function showDurations(): void {
  run(() => {
    const remaining = tasks.filter(task => !task.done);
    console.log(`Total duration (all tasks):       ${getTotalDuration(tasks)} min`);
    console.log(`Total duration (incomplete only): ${getTotalDuration(remaining)} min`);
  });
  run(() => {
    const byPriority = getDurationByPriority(tasks);
    console.log('Duration by priority:');
    for (const [priority, minutes] of Object.entries(byPriority)) {
      console.log(`  ${priority.padEnd(6)} ${minutes} min`);
    }
  });
}

async function sortTasks(): Promise<void> {
  const answer = (await ask('Direction (asc, desc) [asc]: ')).trim().toLowerCase();
  run(() => {
    const direction = answer === 'desc' ? 'desc' : 'asc';
    printTasks(sortByDuration(tasks, direction));
  });
}

async function markComplete(): Promise<void> {
  const id = Number(await ask('Task id: '));
  run(() => {
    if (!tasks.some(task => task.id === id)) {
      console.log(`No task with id ${id}.`);
      return;
    }
    tasks = completeTask(tasks, id);
    console.log('Task marked as complete.');
  });
}

function showTags(): void {
  run(() => {
    const counts = getTagCounts(tasks);
    console.log('Tag counts:');
    for (const [tag, count] of Object.entries(counts)) {
      console.log(`  #${tag}: ${count}`);
    }
  });
  run(() => {
    console.log(`Top 3 tags: ${getTopTags(tasks, 3).map(tag => `#${tag}`).join(' ')}`);
  });
}

async function addTask(): Promise<void> {
  const title = (await ask('Title: ')).trim();
  const priority = (await ask('Priority (low, medium, high): ')).trim().toLowerCase();
  const duration = Number(await ask('Duration in minutes: '));
  const tagInput = (await ask('Tags, separated by commas (optional): ')).trim();

  if (title === '' || !isPriority(priority) || !(duration > 0)) {
    console.log('Invalid task. Title is required, priority must be low, medium, or high, and duration must be a positive number.');
    return;
  }
  const nextId = tasks.reduce((max, task) => Math.max(max, task.id), 0) + 1;
  const tags = tagInput === '' ? undefined : tagInput.split(',').map(tag => tag.trim()).filter(tag => tag !== '');
  const newTask: Task = { id: nextId, title, priority, duration, done: false, tags };
  tasks = [...tasks, newTask];
  console.log(`Added task ${nextId}.`);
}

// ---------------------------------------------------------------------------
// Main loop
// ---------------------------------------------------------------------------
const MENU = `
Task Manager
  1. List all tasks
  2. List tasks by priority
  3. Show durations
  4. Sort tasks by duration
  5. Mark a task as complete
  6. Show tag counts
  7. Add a task
  0. Exit`;

let running = true;
while (running) {
  console.log(MENU);
  const choice = (await ask('Choose an option: ')).trim();
  switch (choice) {
    case '1':
      run(() => printTasks(tasks));
      break;
    case '2':
      await filterByPriority();
      break;
    case '3':
      showDurations();
      break;
    case '4':
      await sortTasks();
      break;
    case '5':
      await markComplete();
      break;
    case '6':
      showTags();
      break;
    case '7':
      await addTask();
      break;
    case '0':
      running = false;
      break;
    default:
      console.log('Invalid option, please try again.');
  }
}
rl.close();
console.log('Goodbye.');
