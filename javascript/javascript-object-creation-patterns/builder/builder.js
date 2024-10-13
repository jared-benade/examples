export const cloneBuilder = () => {
    const clone = {
        firstName: 'Jane',
        lastName: 'Doe',
        gender: 'Female',
        hairColor: 'Blonde',
        numberOfFingers: 10,
        numberOfEyes: 2,
        greet: () => {
            return `Hi there, my name is ${clone.firstName} ${clone.lastName}, nice to meet you :)`
        }
    }

    return {
        withFirstName(firstName) {
            clone.firstName = firstName
            return this
        },
        withLastName(lastName) {
            clone.lastName = lastName
            return this
        },
        isStandardMale() {
            clone.firstName = 'John'
            clone.lastName = 'Smith'
            clone.gender = 'Male'
            clone.hairColor = 'Black'
            return this
        },
        build() {
            return clone
        }
    }
}