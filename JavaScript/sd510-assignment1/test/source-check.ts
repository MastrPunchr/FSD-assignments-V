// Helper used by the tests. Do not change this file.
// Reads a file in src/ and removes its comments, so the tests can check which syntax it uses.
import { readFileSync } from 'node:fs';

export function codeWithoutComments(fileName: string): string {
  const source = readFileSync(new URL(`../src/${fileName}`, import.meta.url), 'utf8');
  return source.replace(/\/\*[\s\S]*?\*\//g, '').replace(/\/\/.*$/gm, '');
}
