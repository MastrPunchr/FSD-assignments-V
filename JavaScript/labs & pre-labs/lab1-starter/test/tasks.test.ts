// Self-check tests for Lab 1. Run them with:  npm test
// This file is PROVIDED. You do not need to change it.
// A failing test is marked with a cross and shows the expected and actual values below it.

import { describe, test } from 'node:test';
import assert from 'node:assert/strict';
import {
  completeTask,
  formatTask,
  getDurationByPriority,
  getTagCounts,
  getTasksByPriority,
  getTopTags,
  getTotalDuration,
  isPriority,
  isTask,
  parseTasks,
  sortByDuration,
} from '../src/tasks.ts';
import type { Task } from '../src/types.ts';

// A fresh copy of the sample data for every test, so one test cannot affect another.
function sampleTasks(): Task[] {
  return [
    { id: 1, title: 'Write report', priority: 'high', duration: 45, done: false, tags: ['work', 'writing'] },
    { id: 2, title: 'Buy milk', priority: 'low', duration: 5, done: true },
    { id: 3, title: 'Fix bug', priority: 'high', duration: 120, done: false, tags: ['work', 'code'] },
    { id: 4, title: 'Call dentist', priority: 'medium', duration: 10, done: false, tags: [] },
    { id: 5, title: 'Review code', priority: 'medium', duration: 30, done: false, tags: ['code', 'work'] },
  ];
}

// ---------------------------------------------------------------------------
// Part 2: Loading untrusted data
// ---------------------------------------------------------------------------
describe('Part 2: isPriority', () => {
  test('accepts low, medium, and high', () => {
    assert.equal(isPriority('low'), true);
    assert.equal(isPriority('medium'), true);
    assert.equal(isPriority('high'), true);
  });
  test('rejects other values', () => {
    assert.equal(isPriority('urgent'), false);
    assert.equal(isPriority('HIGH'), false);
    assert.equal(isPriority(''), false);
    assert.equal(isPriority(1), false);
    assert.equal(isPriority(null), false);
    assert.equal(isPriority(undefined), false);
  });
});

describe('Part 2: isTask', () => {
  const valid = { id: 1, title: 'Write report', priority: 'high', duration: 45, done: false, tags: ['work'] };

  test('accepts a valid task', () => {
    assert.equal(isTask(valid), true);
  });
  test('accepts a valid task without tags', () => {
    const { tags, ...withoutTags } = valid;
    assert.equal(isTask(withoutTags), true);
  });
  test('rejects null and non-objects', () => {
    assert.equal(isTask(null), false);
    assert.equal(isTask(undefined), false);
    assert.equal(isTask('task'), false);
    assert.equal(isTask(42), false);
  });
  test('rejects a missing or wrongly typed id', () => {
    assert.equal(isTask({ ...valid, id: undefined }), false);
    assert.equal(isTask({ ...valid, id: '1' }), false);
    assert.equal(isTask({ ...valid, id: 1.5 }), false);
  });
  test('rejects a missing or empty title', () => {
    assert.equal(isTask({ ...valid, title: undefined }), false);
    assert.equal(isTask({ ...valid, title: '' }), false);
    assert.equal(isTask({ ...valid, title: '   ' }), false);
  });
  test('rejects an invalid priority', () => {
    assert.equal(isTask({ ...valid, priority: 'urgent' }), false);
  });
  test('rejects a duration that is missing, not a number, zero, or negative', () => {
    assert.equal(isTask({ ...valid, duration: undefined }), false);
    assert.equal(isTask({ ...valid, duration: '45' }), false);
    assert.equal(isTask({ ...valid, duration: 0 }), false);
    assert.equal(isTask({ ...valid, duration: -10 }), false);
    assert.equal(isTask({ ...valid, duration: Number.NaN }), false);
  });
  test('rejects a done value that is not a boolean', () => {
    assert.equal(isTask({ ...valid, done: 'no' }), false);
    assert.equal(isTask({ ...valid, done: 0 }), false);
  });
  test('rejects tags that are not an array of strings', () => {
    assert.equal(isTask({ ...valid, tags: 'work' }), false);
    assert.equal(isTask({ ...valid, tags: ['work', 3] }), false);
  });
});

describe('Part 2: parseTasks', () => {
  test('keeps valid entries and counts invalid ones', () => {
    const json = JSON.stringify([
      { id: 1, title: 'A', priority: 'low', duration: 5, done: false },
      { id: 2, title: 'B', priority: 'urgent', duration: 5, done: false },
      null,
      { id: 3, title: 'C', priority: 'high', duration: 10, done: true, tags: ['x'] },
    ]);
    const result = parseTasks(json);
    assert.deepEqual(result.tasks.map(t => t.id), [1, 3]);
    assert.equal(result.invalidCount, 2);
  });
  test('returns no tasks for an empty array', () => {
    assert.deepEqual(parseTasks('[]'), { tasks: [], invalidCount: 0 });
  });
  test('throws an Error when the JSON is not an array', () => {
    assert.throws(() => parseTasks('{"id": 1}'), { message: 'Task data must be a JSON array.' });
  });
  test('lets a JSON syntax error through as a SyntaxError', () => {
    assert.throws(() => parseTasks('[{bad json'), SyntaxError);
  });
});

// ---------------------------------------------------------------------------
// Part 3: Processing tasks
// ---------------------------------------------------------------------------
describe('Part 3: formatTask', () => {
  test('formats an incomplete task with tags', () => {
    assert.equal(formatTask(sampleTasks()[0]), '[ ] Write report | HIGH | 45 min | #work #writing');
  });
  test('formats a complete task without tags', () => {
    assert.equal(formatTask(sampleTasks()[1]), '[x] Buy milk | LOW | 5 min | (no tags)');
  });
  test('treats an empty tags array the same as no tags', () => {
    assert.equal(formatTask(sampleTasks()[3]), '[ ] Call dentist | MEDIUM | 10 min | (no tags)');
  });
});

describe('Part 3: getTasksByPriority', () => {
  test('returns only tasks with the given priority, in their original order', () => {
    assert.deepEqual(getTasksByPriority(sampleTasks(), 'high').map(t => t.id), [1, 3]);
    assert.deepEqual(getTasksByPriority(sampleTasks(), 'low').map(t => t.id), [2]);
  });
  test('returns an empty array when nothing matches', () => {
    assert.deepEqual(getTasksByPriority([], 'medium'), []);
  });
});

describe('Part 3: getTotalDuration', () => {
  test('adds up all durations', () => {
    assert.equal(getTotalDuration(sampleTasks()), 210);
  });
  test('returns 0 for an empty list instead of throwing', () => {
    assert.equal(getTotalDuration([]), 0);
  });
});

describe('Part 3: getDurationByPriority', () => {
  test('totals the duration for each priority', () => {
    assert.deepEqual(getDurationByPriority(sampleTasks()), { low: 5, medium: 40, high: 165 });
  });
  test('includes every priority, even with no tasks', () => {
    assert.deepEqual(getDurationByPriority([]), { low: 0, medium: 0, high: 0 });
  });
});

describe('Part 3: sortByDuration', () => {
  test('sorts ascending by default', () => {
    assert.deepEqual(sortByDuration(sampleTasks()).map(t => t.duration), [5, 10, 30, 45, 120]);
  });
  test('sorts descending', () => {
    assert.deepEqual(sortByDuration(sampleTasks(), 'desc').map(t => t.duration), [120, 45, 30, 10, 5]);
  });
  test('does not change the original array', () => {
    const tasks = sampleTasks();
    sortByDuration(tasks, 'desc');
    assert.deepEqual(tasks.map(t => t.id), [1, 2, 3, 4, 5]);
  });
});

describe('Part 3: completeTask', () => {
  test('returns a new array with the task marked as done', () => {
    const result = completeTask(sampleTasks(), 3);
    assert.equal(result.find(t => t.id === 3)?.done, true);
    assert.equal(result.length, 5);
  });
  test('does not change the original array or the original task object', () => {
    const tasks = sampleTasks();
    const original = tasks[2];
    const result = completeTask(tasks, 3);
    assert.notEqual(result, tasks);
    assert.equal(original.done, false);
    assert.equal(tasks[2].done, false);
  });
  test('leaves the other tasks unchanged', () => {
    const tasks = sampleTasks();
    const result = completeTask(tasks, 3);
    assert.deepEqual(result.filter(t => t.id !== 3), tasks.filter(t => t.id !== 3));
  });
});

describe('Part 3: getTagCounts', () => {
  test('counts how many tasks use each tag', () => {
    assert.deepEqual(getTagCounts(sampleTasks()), { work: 3, writing: 1, code: 2 });
  });
  test('returns an empty object when no task has tags', () => {
    assert.deepEqual(getTagCounts([{ id: 1, title: 'A', priority: 'low', duration: 5, done: false }]), {});
  });
});

// ---------------------------------------------------------------------------
// Part 4: Optional challenge
// ---------------------------------------------------------------------------
describe('Part 4 (optional): getTopTags', () => {
  test('returns the most-used tags first', () => {
    assert.deepEqual(getTopTags(sampleTasks(), 2), ['work', 'code']);
  });
  test('orders tags with the same count alphabetically', () => {
    const tasks: Task[] = [
      { id: 1, title: 'A', priority: 'low', duration: 5, done: false, tags: ['zeta', 'alpha'] },
      { id: 2, title: 'B', priority: 'low', duration: 5, done: false, tags: ['mid'] },
    ];
    assert.deepEqual(getTopTags(tasks, 3), ['alpha', 'mid', 'zeta']);
  });
  test('returns all tags when n is larger than the number of tags', () => {
    assert.deepEqual(getTopTags(sampleTasks(), 10), ['work', 'code', 'writing']);
  });
});
