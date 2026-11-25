// Used by the Lesson 2 tests only.
import assert from 'node:assert/strict';
import type { RecordedRequest } from './fake-reqres.ts';

// Fails with a clear message if any request was sent without the x-api-key header.
export function assertKeySent(requests: RecordedRequest[]): void {
  assert.ok(requests.length > 0, 'No request was sent. Call fetch() in this function.');
  for (const request of requests) {
    assert.ok(
      request.apiKey,
      `The request to ${request.url} was sent without your API key. Add headers: { 'x-api-key': API_KEY } to fetch().`,
    );
  }
}
