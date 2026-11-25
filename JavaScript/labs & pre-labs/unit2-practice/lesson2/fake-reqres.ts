// Used by the Lesson 2 tests only. You do not need to read or change this file.
//
// The tests replace fetch() with the fake below, so running the tests does not
// use any of your daily reqres.in requests. The fake answers with responses
// recorded from the real https://reqres.in/api on 16 November 2026:
//   - GET /api/users/1 to /api/users/12 answer with that user (status 200).
//   - Any other /api/users/<id> answers with status 404 and the body {}.
//   - GET /api/users?page=N answers with page N (6 users per page, 2 pages).
//   - GET /api/unknown/1 to /api/unknown/6 answer with a colour.
//   - The key 'wrong-key' answers with status 403, like any key reqres.in does not recognize.
//   - Any host other than reqres.in fails the same way as a network failure.

type FakeResponse = { status: number; body: unknown };

const support = {
  url: 'https://reqres.in/go/clerk',
  text: 'Your AI coding agent can add authentication and user management to your app with Clerk. Point it to clerk.com/SKILL.md and get building.',
  sponsored_by: 'Clerk',
};

const users = [
  [1, 'george.bluth', 'George', 'Bluth'],
  [2, 'janet.weaver', 'Janet', 'Weaver'],
  [3, 'emma.wong', 'Emma', 'Wong'],
  [4, 'eve.holt', 'Eve', 'Holt'],
  [5, 'charles.morris', 'Charles', 'Morris'],
  [6, 'tracey.ramos', 'Tracey', 'Ramos'],
  [7, 'michael.lawson', 'Michael', 'Lawson'],
  [8, 'lindsay.ferguson', 'Lindsay', 'Ferguson'],
  [9, 'tobias.funke', 'Tobias', 'Funke'],
  [10, 'byron.fields', 'Byron', 'Fields'],
  [11, 'george.edwards', 'George', 'Edwards'],
  [12, 'rachel.howell', 'Rachel', 'Howell'],
].map(([id, email, first, last]) => ({
  id: id as number,
  email: `${email}@reqres.in`,
  first_name: first as string,
  last_name: last as string,
  avatar: `https://reqres.in/img/faces/${id}-image.jpg`,
}));

const colours = [
  { id: 1, name: 'cerulean', year: 2000, color: '#98B2D1', pantone_value: '15-4020' },
  { id: 2, name: 'fuchsia rose', year: 2001, color: '#C74375', pantone_value: '17-2031' },
  { id: 3, name: 'true red', year: 2002, color: '#BF1932', pantone_value: '19-1664' },
  { id: 4, name: 'aqua sky', year: 2003, color: '#7BC4C4', pantone_value: '14-4811' },
  { id: 5, name: 'tigerlily', year: 2004, color: '#E2583E', pantone_value: '17-1456' },
  { id: 6, name: 'blue turquoise', year: 2005, color: '#53B0AE', pantone_value: '15-5217' },
];

const invalidKeyBody = {
  error: 'invalid_api_key',
  message: 'This API key is not recognized or has been revoked.',
  hint: 'Check that your API key is correct and not expired.',
};

function answer(url: URL): FakeResponse {
  const path = url.pathname;
  if (path === '/api/users') {
    const page = Number(url.searchParams.get('page') ?? '1');
    const data = users.slice((page - 1) * 6, page * 6);
    return { status: 200, body: { page, per_page: 6, total: 12, total_pages: 2, data, support } };
  }
  const userMatch = path.match(/^\/api\/users\/(\d+)$/);
  if (userMatch) {
    const user = users.find(u => u.id === Number(userMatch[1]));
    return user ? { status: 200, body: { data: user, support } } : { status: 404, body: {} };
  }
  const colourMatch = path.match(/^\/api\/unknown\/(\d+)$/);
  if (colourMatch) {
    const colour = colours.find(c => c.id === Number(colourMatch[1]));
    return colour ? { status: 200, body: { data: colour, support } } : { status: 404, body: {} };
  }
  return { status: 404, body: {} };
}

export type RecordedRequest = { url: string; method: string; apiKey: string | null };

export type FakeOptions = {
  // Answer every request as a network failure (fetch rejects).
  offline?: boolean;
  // Replace the answer for one path, for example { '/api/users/2': { status: 200, body: {...} } }.
  overrides?: Record<string, FakeResponse>;
};

export function installFakeFetch(options: FakeOptions = {}): RecordedRequest[] {
  const requests: RecordedRequest[] = [];
  globalThis.fetch = async (input: string | URL | Request, init?: RequestInit): Promise<Response> => {
    const url = new URL(input instanceof Request ? input.url : String(input));
    const headers = new Headers(init?.headers);
    requests.push({ url: url.href, method: init?.method ?? 'GET', apiKey: headers.get('x-api-key') });
    await new Promise(resolve => setTimeout(resolve, 5));
    if (options.offline || url.hostname !== 'reqres.in') {
      throw new TypeError('fetch failed');
    }
    let result = options.overrides?.[url.pathname] ?? answer(url);
    if (headers.get('x-api-key') === 'wrong-key') {
      result = { status: 403, body: invalidKeyBody };
    }
    return new Response(JSON.stringify(result.body), {
      status: result.status,
      headers: { 'content-type': 'application/json; charset=utf-8' },
    });
  };
  return requests;
}
