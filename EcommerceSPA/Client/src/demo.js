"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var message = "Hello";
var isCompleted = false;
var todos = [];
function addTodo(title) {
    var newTod = {
        id: todos.length + 1,
        title: title,
        completed: false,
    };
    todos.push(newTod);
    return newTod;
}
function toggletodo(id) {
    var todo = todos.find(function (todo) { return todo.id === id; });
    if (todo) {
        todo.completed = !todo.completed;
    }
}
addTodo("Build Api");
addTodo("Publish App");
toggletodo(1);
console.log(todos);
