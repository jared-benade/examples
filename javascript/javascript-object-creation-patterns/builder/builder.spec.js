import { cloneBuilder } from "./builder"

describe('builder', () => {
    describe('cloneBuilder', () => {
        describe('build', () => {
            test('will return a default clone if no override functions called', () => {
                // Arrange
                const defaultClone = {
                    firstName: 'Jane',
                    lastName: 'Doe',
                    gender: 'Female',
                    hairColor: 'Blonde',
                    numberOfFingers: 10,
                    numberOfEyes: 2,
                    greet: () => {
                        return 'Hi there, my name is Jane Doe, nice to meet you :)'
                    }
                }
                // Act
                const clone = cloneBuilder().build()
                // Assert
                // Check that their serialized strings match since they aren't the exact same object but they have the same property values
                expect(JSON.stringify(clone)).toEqual(JSON.stringify(defaultClone))
                expect(clone.greet()).toEqual(defaultClone.greet())
            })

            describe('withFirstName', () => {
                test('will return clone with first name set to provided value', () => {
                    // Arrange
                    const expected = 'Charles'
                    // Act
                    const clone = cloneBuilder()
                        .withFirstName('Charles')
                        .build()
                    // Assert
                    expect(clone.firstName).toEqual(expected)
                })
            })

            describe('withLastName', () => {
                test('will return clone with last name set to provided value', () => {
                    // Arrange
                    const expected = 'Xavier'
                    // Act
                    const clone = cloneBuilder()
                        .withLastName('Xavier')
                        .build()
                    // Assert
                    expect(clone.lastName).toEqual(expected)
                })
            })

            describe('isStandardMale', () => {
                test('will return standard male clone', () => {
                    // Arrange
                    const standardMaleClone = {
                        firstName: 'John',
                        lastName: 'Smith',
                        gender: 'Male',
                        hairColor: 'Black',
                        numberOfFingers: 10,
                        numberOfEyes: 2,
                        greet: () => {
                            return 'Hi there, nice to meet you :)'
                        }
                    }
                    // Act
                    const clone = cloneBuilder()
                        .isStandardMale()
                        .build()
                    // Assert
                    expect(JSON.stringify(clone)).toEqual(JSON.stringify(standardMaleClone))
                })
            })

            describe('greet', () => {
                test('should be a function', () => {
                    // Arrange    
                    const expected = 'function'

                    // Act
                    const clone = cloneBuilder().build()
                    // Assert
                    expect(typeof clone.greet).toEqual(expected)
                })

                test('should return greeting using provided first name and last name', () => {
                    // Arrange    
                    const expected = 'Hi there, my name is Charles Xavier, nice to meet you :)'

                    const clone = cloneBuilder()
                        .withFirstName('Charles')
                        .withLastName('Xavier')
                        .build()
                    // Act
                    const result = clone.greet()
                    // Assert
                    expect(result).toEqual(expected)
                })
            })
        })
    })
})