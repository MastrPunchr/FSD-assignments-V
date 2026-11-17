# SD 510 Unit 2: In-Class Practice

Short exercises you complete during the Unit 2 lessons, one file per exercise block.
Each file has tests. An exercise is finished when its tests pass **and** `npm run typecheck`
reports no errors for its file.

All Unit 2 exercises are written in TypeScript.

## Setup (once)

```bash
node --version   # must be v24.12.0 or newer
npm install
```

Turn on **File > Auto Save** in VS Code. The tests and the compiler read files from disk,
so unsaved changes are invisible to them.

## Running the tests

Run the tests for the file you are working on:

```bash
node --test lesson1/1-then-catch.test.ts
```

Or run a whole lesson:

```bash
npm run test:lesson1
```

Then check the types:

```bash
npm run typecheck
```

A passing test is marked with a check mark; a failing test is marked with a cross and shows
the expected and actual values. Each test takes a moment to run, because the functions in
`lesson1/api.ts` wait a short time before answering, like a request to a real server.

## Exercise files

| Lesson | File | Topic |
| ------ | ---- | ----- |
| 1 | `lesson1/1-then-catch.ts` | Reading a promise's result with `.then()` and `.catch()` |
| 1 | `lesson1/2-creating-promises.ts` | `new Promise`, wrapping `setTimeout` and a callback function |
| 1 | `lesson1/3-chaining.ts` | Chaining `.then()` calls, one `.catch()` at the end |
| 1 | `lesson1/4-async-await.ts` | `async`, `await`, and `try`/`catch` |
| 1 | `lesson1/5-fix-the-bugs.ts` | Finding and fixing common promise and `await` mistakes |

Functions marked **Extra** are for when you finish early. They are not required.

Do not change the test files, `lesson1/api.ts`, or `lesson1/source-check.ts`.

Folders for later Unit 2 lessons are posted with those lessons. Unzip each one into this
project folder, next to `lesson1`.
