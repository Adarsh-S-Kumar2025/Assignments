// var
var x = 5;
x = 10;      // allowed
var x = 15;  // allowed

// let
let y = 20;
y = 25;      // allowed
// let y = 30; // SyntaxError (redeclaration not allowed)

// const
const z = 50;
// z = 60;      // TypeError (reassignment not allowed)
// const z = 70; // SyntaxError (redeclaration not allowed)

console.log(x, y, z);
