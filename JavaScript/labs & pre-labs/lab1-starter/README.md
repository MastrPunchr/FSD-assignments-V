# SD 510 Lab 1: Advanced JavaScript and TypeScript

The full instructions are on the Lab 1 page in Brightspace. This file is a quick reference.

## Requirements

- Node.js 24.12 or newer (`node --version`)
- Visual Studio Code

## Setup

```bash
npm install
```

## Commands

| Command             | What it does                                                   |
| ------------------- | -------------------------------------------------------------- |
| `npm run typecheck` | Runs the TypeScript compiler. No output means no type errors. |
| `npm test`          | Runs the self-check tests in `test/tasks.test.ts`.             |
| `npm start`         | Runs the Task Manager menu app.                                |

## Files

| File                  | Who edits it | Purpose                                              |
| --------------------- | ------------ | ---------------------------------------------------- |
| `src/types.ts`        | You (Part 1) | The `Priority`, `SortDirection`, and `Task` types    |
| `src/tasks.ts`        | You (Parts 2 to 4) | The functions you implement                    |
| `src/index.ts`        | Provided     | The menu app that calls your functions               |
| `test/tasks.test.ts`  | Provided     | Self-check tests                                     |
| `data/tasks.json`     | Provided     | Task data, including some invalid entries on purpose |

Do not change the provided files. If a test fails, fix your code, not the test.
