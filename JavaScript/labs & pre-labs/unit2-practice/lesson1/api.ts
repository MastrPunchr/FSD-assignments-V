// A simulated web API for the Lesson 1 exercises. Do not change this file.
//
// Each function waits a short time before answering, like a request to a real server.
// Unit 2, Lessons 2 to 4 replace this file with real requests made with fetch().

export interface User {
  id: number;
  name: string;
  email: string;
}

export interface Order {
  id: number;
  userId: number;
  total: number;
}

export interface Settings {
  theme: 'light' | 'dark';
  fontSize: number;
}

const users: User[] = [
  { id: 1, name: 'Ana Silva', email: 'ana@example.com' },
  { id: 2, name: 'Ben Okafor', email: 'ben@mitt.ca' },
  { id: 3, name: 'Chen Wei', email: 'chen@example.com' },
];

const orders: Order[] = [
  { id: 101, userId: 1, total: 25 },
  { id: 102, userId: 1, total: 40 },
  { id: 103, userId: 2, total: 15 },
];

const savedSettings: Record<string, Settings> = {
  ana: { theme: 'dark', fontSize: 16 },
  ben: { theme: 'light', fontSize: 14 },
};

const RESPONSE_TIME_MS = 20;

// Resolves with the user who has this id.
// Rejects with an Error if no user has this id.
export function getUser(id: number): Promise<User> {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const user = users.find(u => u.id === id);
      if (user) {
        resolve({ ...user });
      } else {
        reject(new Error(`User ${id} not found`));
      }
    }, RESPONSE_TIME_MS);
  });
}

// Resolves with every order placed by this user ([] if the user has none).
export function getOrders(userId: number): Promise<Order[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(orders.filter(o => o.userId === userId).map(o => ({ ...o })));
    }, RESPONSE_TIME_MS);
  });
}

// An older, callback-based function, the style used before promises existed.
// It calls callback(null, settings) on success, or callback(error) on failure.
// It does not return a promise.
export function loadSettings(
  username: string,
  callback: (error: Error | null, settings?: Settings) => void,
): void {
  setTimeout(() => {
    const settings = savedSettings[username];
    if (settings) {
      callback(null, { ...settings });
    } else {
      callback(new Error(`No settings saved for ${username}`));
    }
  }, RESPONSE_TIME_MS);
}
