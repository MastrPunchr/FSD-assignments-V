# SD 510 Assignment 1: Asynchronous Programming Fundamentals

You will finish the functions behind a small library system: process its catalog data,
check records that came from an old system, and load members, books, loans and fine
policies from a simulated web API with promises and `async`/`await`.

Full instructions and the grading scheme are on the Assignment 1 page in D2L.

## Setup (once)

```bash
node --version   # must be v24.12.0 or newer
npm install
```

Turn on **File > Auto Save** in VS Code. The tests and the compiler read files from disk,
so unsaved changes are invisible to them.

## Commands

| Command | What it does | What you see before you start |
| ------- | ------------ | ----------------------------- |
| `npm test` | Runs every self-check test in `test/`. | 5 passing, 32 failing |
| `node --test test/part1.test.ts` | Runs the tests for one part (change the number). | |
| `npm run typecheck` | Runs the TypeScript compiler. No output means no type errors. | 2 errors, both in `part6-fix-the-bugs.ts` |
| `npm start` | Runs the Library Report app, which calls your functions. | "not working yet" for each section |

## Files

| File | What to do |
| ---- | ---------- |
| `src/library-api.ts` | **Read it, do not change it.** The types and the simulated API. |
| `src/part1-catalog.ts` | Part 1: array methods and operators (Unit 1, Lessons 1 and 2) |
| `src/part2-validation.ts` | Part 2: `unknown` and type guards (Unit 1, Lesson 3) |
| `src/part3-then-catch.ts` | Part 3: `.then()`, `.catch()` and chaining (Unit 2, Lesson 1) |
| `src/part4-creating-promises.ts` | Part 4: `new Promise` (Unit 2, Lesson 1) |
| `src/part5-async-await.ts` | Part 5: `async`, `await`, `try`/`catch` (Unit 2, Lesson 1) |
| `src/part6-fix-the-bugs.ts` | Part 6: fix four bugs and explain each one |
| `src/main.ts` | The Library Report app. You do not need to change it. |
| `test/` | Self-check tests. **Do not change these files.** |

Each function's comment is its specification. Replace `throw new Error('Not implemented');`
with your code. Do not change any function's name, parameters or return type.

## Rules

- Do not change `src/library-api.ts`, `src/main.ts`, or anything in `test/`.
- Do not use `any`, type assertions (`as`), `@ts-ignore` or `@ts-expect-error` anywhere in `src/`.
- `npm run typecheck` must report no errors when you submit.
- Each part's first test checks the syntax that part requires (for example, no `async` in Part 3).

The self-check tests are not the full grading tests. Your instructor also runs tests with
other data, so write each function to follow its comment, not only to match the examples.

## Submitting

1. Delete the `node_modules` folder (it is large and is recreated by `npm install`).
2. Zip the whole project folder.
3. Upload the zip to the Assignment 1 submission folder in D2L.
