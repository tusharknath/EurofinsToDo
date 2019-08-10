import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { Task } from '../models/todo';

@Injectable({ providedIn: 'root' })
export class TasksService {

  constructor(
    private http: HttpClient) { }

  getAll() {
    return this.http.get<Task[]>(`${environment.apiUrl}/api/usertask`);
  }

  create(content) {
    return this.http.post(`${environment.apiUrl}/api/usertask`, { Title: content });
  }

  remove(taskId) {
    return this.http.delete(`${environment.apiUrl}/api/usertask/${taskId}`);
  }

  update(taskId: number, change: boolean) {
    return this.http.put(`${environment.apiUrl}/api/usertask/${taskId}`, { IsComplete: change });
  }
}
