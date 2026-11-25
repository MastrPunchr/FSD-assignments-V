// The Library Report app. Run it with: npm start
// It calls your functions from every part, so it shows more output as you finish each part.
// You do not need to change this file.

import { availableTitles, totalCopies, newestFirst, formatBook, shelfLabel } from './part1-catalog.ts';
import { getMemberNameOrDefault, isBookAvailable } from './part3-then-catch.ts';
import { wait } from './part4-creating-promises.ts';
import { memberReport, getBorrowedTitles, loadImportedCatalog } from './part5-async-await.ts';
import { errorMessage } from './part2-validation.ts';

// Runs one section of the report and prints its error instead of stopping the whole app.
async function section(title: string, run: () => Promise<void>): Promise<void> {
  console.log(`\n=== ${title} ===`);
  try {
    await run();
  } catch (error) {
    // errorMessage is from Part 2; until Part 2 is finished it throws too, so fall back to String().
    let message: string;
    try {
      message = errorMessage(error);
    } catch {
      message = String(error);
    }
    console.log(`(not working yet: ${message})`);
  }
}

console.log('MITT Library Report');

await section('Imported catalog (Parts 1, 2, 5)', async () => {
  const catalog = await loadImportedCatalog();
  console.log(`${catalog.length} valid records, ${totalCopies(catalog)} copies on the shelf`);
  for (const book of newestFirst(catalog)) {
    console.log(`  ${formatBook(book)} [${shelfLabel(book)}]`);
  }
  console.log(`Available now: ${availableTitles(catalog).join(', ')}`);
});

await section('Member reports (Parts 2, 4, 5)', async () => {
  for (const id of [1, 2, 3, 4, 999]) {
    console.log(`  ${await memberReport(id)}`);
  }
});

await section('Borrowed books (Parts 3, 5)', async () => {
  for (const id of [1, 2, 4]) {
    const name = await getMemberNameOrDefault(id);
    console.log(`  ${name}: ${(await getBorrowedTitles(id)).join(', ')}`);
  }
});

await section('Shelf check (Parts 3, 4)', async () => {
  console.log('  Checking Dune...');
  await wait(500);
  const available = await isBookAvailable('978-0441172719');
  console.log(`  Dune is ${available ? 'available' : 'checked out'}`);
});
