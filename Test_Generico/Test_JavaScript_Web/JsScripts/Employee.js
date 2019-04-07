
//Prototype class for employee
class Employee {

    //Constructor to initialize  the employee  
    constructor(name, lastName, salary) {
        // invokes the setter
        this._name = name;
        this._lastName = lastName;
        this._salary =  salary;
    }

    //Prop Name
    name() {
        return this._name;
    }

    //Prop lastName
    lastName() {
        return this._lastName;
    }

    //Prop Salary
    salary() {
        return this._salary;
    }

    //Method to increase salary
    increaseSalary() {
      return  this._salary += 1000;


    }

    //Get employee info
    employeeInfo() {

        return "Name: " + this._name + " Last Name: " + this._lastName + " salary: " + this._salary;
    }




}
