// Helper used by the tests. Do not change this file.
// Reads an exercise file and removes its comments, so the tests can check which syntax it uses.
import { readFileSync } from 'node:fs';

export function codeWithoutComments(fileName: string): string {
  const source = readFileSync(new URL(fileName, import.meta.url), 'utf8');
  return source.replace(/\/\*[\s\S]*?\*\//g, '').replace(/\/\/.*$/gm, '');
}
