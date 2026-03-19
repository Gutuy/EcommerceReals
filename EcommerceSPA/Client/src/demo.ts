import { find } from "rxjs";

let message="Hello";
let isCompleted=false;

type todo={
    id:number,
    title:string,
    completed:boolean
}
let todos:todo[]=[];

function addTodo(title:string):todo{
    const newTod:todo={
        id:todos.length +1,
        title,
        completed:false,
    }
    todos.push(newTod);
    return newTod;
}

function toggletodo(id:number):void{
    const todo=todos.find(todo=>todo.id===id);
    if(todo){
        todo.completed=!todo.completed;
    }
}
addTodo("Build Api");
addTodo("Publish App");
toggletodo(1);
console.log(todos);