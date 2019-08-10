import { Component, OnInit, OnDestroy } from '@angular/core';
import { TasksService } from '../shared/services/todo.service';
import { Task } from '../shared/models/todo';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../shared/services/authentication.service';
import { User } from '../shared/models/user';
import { Subscription } from 'rxjs';

@Component({
  templateUrl: './todo.component.html'
})

export class TodoComponent implements OnInit, OnDestroy {
  currentUser: User;
  currentUserSubscription: Subscription;
  tasks: Task[] = [];

  constructor(private toDoService: TasksService, private authenticationService: AuthenticationService) {
    this.currentUserSubscription = this.authenticationService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  ngOnInit() {
    this.loadAllTasks();
  }

  private loadAllTasks() {
    this.toDoService.getAll().pipe(first()).subscribe(todos => {
      this.tasks = todos;
    });
  }

  ngOnDestroy() {
    this.currentUserSubscription.unsubscribe();
  }

  onAdd(itemTitle) {
    if (itemTitle.value.length > 0) {
      this.toDoService.create(itemTitle.value)
        .subscribe((response: Task) => this.tasks.push(response));
      itemTitle.value = null;
    }
  }

  alterCheck(taskId, isChecked) {
    this.toDoService.update(taskId, !isChecked)
      .subscribe((updatedTask: Task) => {
        const index = this.tasks.findIndex(task => task.Id === taskId);

        this.tasks[index].Title = updatedTask.Title;
        this.tasks[index].IsComplete = updatedTask.IsComplete;
      });
  }

  onDelete(taskId) {
    this.toDoService.remove(taskId)
      .subscribe(_ => {
        const index = this.tasks.findIndex(task => task.Id === taskId);
        this.tasks.splice(index, 1);
      });
  }

}
