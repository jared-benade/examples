import { createClone } from "./factory"

describe('factory', () => {
    describe('createClone', () => {
        describe('first name', () => {
            test('will set first name to value given', () => {
                // Arrange
                const expected = 'Charles'

                const sut = createClone
                // Act
                const clone = sut('Charles')
                const result = clone.firstName
                // Assert
                expect(result).toEqual(expected)
            })

            for (const { gender, expected } of [
                { gender: 'Male', expected: 'John' },
                { gender: 'Female', expected: 'Jane' }
            ]) {
                test('will set default first name based on gender', () => {
                    // Arrange        
                    const sut = createClone
                    // Act
                    const clone = sut(undefined, undefined, gender)
                    const result = clone.firstName
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        describe('last name', () => {
            test('will set last name to value given', () => {
                // Arrange
                const expected = 'Xavier'

                const sut = createClone
                // Act
                const clone = sut(undefined, 'Xavier')
                const result = clone.lastName
                // Assert
                expect(result).toEqual(expected)
            })

            for (const { gender, expected } of [
                { gender: 'Male', expected: 'Smith' },
                { gender: 'Female', expected: 'Doe' }
            ]) {
                test('will set default last name based on gender', () => {
                    // Arrange        
                    const sut = createClone
                    // Act
                    const clone = sut(undefined, undefined, gender)
                    const result = clone.lastName
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        describe('gender', () => {
            test('will set gender to value given', () => {
                // Arrange
                const expected = 'Male'

                const sut = createClone
                // Act
                const clone = sut(undefined, undefined, 'Male')
                const result = clone.gender
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set gender to female if no gender is given', () => {
                // Arrange   
                const expected = 'Female'

                const sut = createClone
                // Act
                const clone = sut()
                const result = clone.gender
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
                    const sut = createClone
                    // Act
                    const clone = sut(undefined, undefined, gender)
                    const result = clone.hairColor
                    // Assert
                    expect(result).toEqual(expected)
                })
            }
        })

        test('will set 10 fingers', () => {
            // Arrange   
            const expected = 10

            const sut = createClone
            // Act
            const clone = sut()
            const result = clone.numberOfFingers
            // Assert
            expect(result).toEqual(expected)
        })

        test('will set 2 eyes', () => {
            // Arrange   
            const expected = 2

            const sut = createClone
            // Act
            const clone = sut()
            const result = clone.numberOfEyes
            // Assert
            expect(result).toEqual(expected)
        })

        describe('greet', () => {
            test('should be a function', () => {
                // Arrange    
                const expected = 'function'

                const sut = createClone
                const clone = sut()
                // Act
                // Assert
                expect(typeof clone.greet).toEqual(expected)
            })

            test('should return greeting', () => {
                // Arrange    
                const expected = 'Hi there, my name is Charles Xavier, nice to meet you :)'

                const sut = createClone
                const clone = sut('Charles', 'Xavier')
                // Act
                const result = clone.greet()
                // Assert
                expect(result).toEqual(expected)
            })
        })
    })
})