const students = [
    { "FirstName": "John", "LastName": "Doe", "Age": 20, "Department": "Computer Science" },
    { "FirstName": "Jane", "LastName": "Smith", "Age": 22, "Department": "Physics" },
    { "FirstName": "Michael", "LastName": "Johnson", "Age": 21, "Department": "Mathematics" },
    { "FirstName": "Sarah", "LastName": "Williams", "Age": 19, "Department": "Computer Science" },
    { "FirstName": "Robert", "LastName": "Brown", "Age": 23, "Department": "Mathematics" },
    { "FirstName": "Emily", "LastName": "Davis", "Age": 20, "Department": "Computer Science" }
  ];
  
  // 1. List the students whose department is computer science.
  const csStudents = students.filter(s => s.Department === "Computer Science");
  console.log("Computer Science Students:", csStudents);
  
  // 2. List the first name of students whose age is greater than  21
  const above21 = students
    .filter(s => s.Age > 21)
    .map(s => s.FirstName);
  console.log("Students age > 21:", above21);
  
  // 3. Check whether a student having a first name as Robert is present in the Computer Science Department. The result should be in boolean type
  const isRobertInCS = students.some(s => s.FirstName === "Robert" && s.Department === "Computer Science");
  console.log("Is Robert in CS?", isRobertInCS);
  
  // 4. Check whether there is any student whose age is greater than 23 is studying in the Maths department.The result should be in boolean type
  const mathsAbove23 = students.some(s => s.Age > 23 && s.Department === "Mathematics");
  console.log("Any student age > 23 in Maths?", mathsAbove23);
  
  //    5. Check whether all the students are above an age group of 18.The result should be in boolean type.
  const allAbove18 = students.every(s => s.Age > 18);
  console.log("All students above 18?", allAbove18);
  
  // 6. Assuming that there is only one student having a first name as John, Print his department name.
  const johnDepartment = students.find(s => s.FirstName === "John")?.Department;
  console.log("John's Department:", johnDepartment);
  