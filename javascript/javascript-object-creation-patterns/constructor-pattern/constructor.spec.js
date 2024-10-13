import { clone } from "./constructor"

describe('constructor', () => {
    describe('clone', () => {
        describe('first name', () => {
            test('will set first name to value given', () => {
                // Arrange
                const expected = 'Charles'

                const sut = new clone('Charles')
                // Act
                const result = sut.firstName
                // Assert
                expect(result).toEqual(expected)
            })

            for (const { gender, expected } of [
                { gender: 'Male', expected: 'John' },
                { gender: 'Female', expected: 'Jane' }
            ]) {
                test('will set default first name based on gender', () => {
                    // Arrange        
                    const sut = new clone(undefined, undefined, gender)
                    // Act
                    const result = sut.firstName
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        describe('last name', () => {
            test('will set last name to value given', () => {
                // Arrange
                const expected = 'Xavier'

                const sut = new clone(undefined, 'Xavier')
                // Act
                const result = sut.lastName
                // Assert
                expect(result).toEqual(expected)
            })

            for (const { gender, expected } of [
                { gender: 'Male', expected: 'Smith' },
                { gender: 'Female', expected: 'Doe' }
            ]) {
                test('will set default last name based on gender', () => {
                    // Arrange        
                    const sut = new clone(undefined, undefined, gender)
                    // Act
                    const result = sut.lastName
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        describe('gender', () => {
            test('will set gender to value given', () => {
                // Arrange
                const expected = 'Male'

                const sut = new clone(undefined, undefined, 'Male')
                // Act
                const result = sut.gender
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set gender to female if no gender is given', () => {
                // Arrange   
                const expected = 'Female'

                const sut = new clone()
                // Act
                const result = sut.gender
                // Assert
                expect(result).toEqual(expected)
            })
        })

        describe('hair color', () => {
            for (const { gender, expected } of [
                { gender: 'Male', expected: 'Black' },
                { gender: 'Female', expected: 'Blonde' }
            ]) {
                test('will set hair color based on gender', () => {
                    // Arrange        
                    const sut = new clone(undefined, undefined, gender)
                    // Act
                    const result = sut.hairColor
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        test('will set 10 fingers', () => {
            // Arrange   
            const expected = 10

            const sut = new clone()
            // Act
            const result = sut.numberOfFingers
            // Assert
            expect(result).toEqual(expected)
        })

        test('will set 2 eyes', () => {
            // Arrange   
            const expected = 2

            const sut = new clone()
            // Act
            const result = sut.numberOfEyes
            // Assert
            expect(result).toEqual(expected)
        })

        describe('greet', () => {
            test('should be a function', () => {
                // Arrange    
                const expected = 'function'

                const sut = new clone()
                // Act
                // Assert
                expect(typeof sut.greet).toEqual(expected)
            })

            test('should return greeting', () => {
                // Arrange    
                const expected = 'Hi there, my name is Charles Xavier, nice to meet you :)'

                const sut = new clone('Charles', 'Xavier')
                // Act
                const result = sut.greet()
                // Assert
                expect(result).toEqual(expected)
            })
        })
    })
})