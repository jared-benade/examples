export const createClone = (firstName, lastName, gender = 'Female') => {
    const isMale = gender === 'Male'
    const computedFirstName = firstName || (isMale ? 'John' : 'Jane')
    const computedLastName = lastName || (isMale ? 'Smith' : 'Doe')

    return {
        firstName: computedFirstName,
        lastName: computedLastName,
        gender,
        hairColor: isMale ? 'Black' : 'Blonde',
        numberOfFingers: 10,
        numberOfEyes: 2,
        greet: () => {
            return `Hi there, my name is ${computedFirstName} ${computedLastName}, nice to meet you :)`
        }
    }
}