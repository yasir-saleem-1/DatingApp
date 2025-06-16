export interface User {
    username: string;
    token: string;
}

let data : number | string = 42;

data = "Hello, World!";

export interface Car {
    color: string;
    make: string;
    model: string;
    year: number;
    topSpeed?: number; 
}

const car1: Car = {
    color : "black",
    make: "Toyota",
    model: "Corolla",
    year: 2020
};
const car2: Car = { 
    color : "black", 
    make: "Honda",
    model: "Civic",
    topSpeed: 200,
    year: 2021
};

const multiply = (x : number , y: number)=> {
    return x * y;
}