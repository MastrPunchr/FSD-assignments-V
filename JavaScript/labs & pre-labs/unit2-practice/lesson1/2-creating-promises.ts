// Lesson 1, Cycle 2: Creating promises with new Promise

import { loadSettings, type Settings } from './api.ts';

// Resolves (with no value) after ms milliseconds. Use setTimeout.
// Example: await delay(500) waits half a second.
export function delay(ms: number): Promise<void> {
  return new Promise (resolve => {
    setTimeout(resolve, ms);
  });
}

// Wraps the callback-based loadSettings (in api.ts) in a promise.
// Resolves with the settings, or rejects with the error loadSettings passes to its callback.
export function loadSettingsAsync(username: string): Promise<Settings> {
  return new Promise((resolve, reject) => {
    loadSettings(username, (error, settings) => {
      if(error || settings === undefined){
        reject(error);
      } else {
        resolve(settings);
      }
    });
  });
}

// Extra (if you finish early):
// Resolves with the user's theme, or 'light' if they have no saved settings.
// Use loadSettingsAsync with .then() and .catch().
export function getThemeOrDefault(username: string): Promise<'light' | 'dark'> {
  return loadSettingsAsync(username)
    .then(settings => settings.theme)
    .catch(() => 'light');
}
