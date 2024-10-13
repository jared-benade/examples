const clone = function() {}
clone.prototype.firstName = 'Jane'
clone.prototype.lastName = 'Doe'
clone.prototype.gender = 'Female'
clone.prototype.hairColor = 'Blonde'
clone.prototype.numberOfFingers = 10
clone.prototype.numberOfEyes = 2
clone.prototype.greet = () => {
    return `Hi there, my name is ${clone.prototype.firstName} ${clone.prototype.lastName}, nice to meet you :)`
}

export default clone