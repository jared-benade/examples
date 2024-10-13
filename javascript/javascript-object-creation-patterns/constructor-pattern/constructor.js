// Need to use older function declaration instead of arrow function so that a new local instance of `this` can
// be created for the variable to be assigned to
export const clone = function(firstName, lastName, gender = 'Female') {
    const isMale = gender === 'Male'

    this.firstName = firstName || (isMale ? 'John' : 'Jane')
    this.lastName = lastName || (isMale ? 'Smith' : 'Doe')
    this.gender = gender
    this.hairColor = isMale ? 'Black' : 'Blonde'
    this.numberOfFingers = 10
    this.numberOfEyes = 2
    this.greet = () => {
        return `Hi there, my name is ${this.firstName} ${this.lastName}, nice to meet you :)`
    }
}