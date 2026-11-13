export type Priority = 'low' | 'medium' | 'high';

export type SortDirection = 'asc' | 'desc';

export interface Task {
  id: number;
  title: string;
  priority: Priority;
  duration: number;
  done: boolean;
  tags?: string[];
}

export interface ParseResult {
  tasks: Task[];
  invalidCount: number;
}
