export const clone = function(firstName, lastName, gender = 'Female') {
    const isMale = gender === 'Male'

    this.firstName = firstName || (isMale ? 'John' : 'Jane')
    this.lastName = lastName || (isMale ? 'Smith' : 'Doe')
    this.gender = gender
    this.hairColor = isMale ? 'Black' : 'Blonde'
    this.numberOfFingers = 10
    this.numberOfEyes = 2

    if (typeof this.greet !== 'function') {
        clone.prototype.greet = function() {
            return `Hi there, my name is ${this.firstName} ${this.lastName}, nice to meet you :)`
        }
    }
}