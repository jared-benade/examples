import { maleClone, femaleClone } from "./objectLiteral"

describe('objectLiteral', () => {
    describe('maleClone', () => {
        test('should have first name', () => {
            // Arrange
            const expected = 'John'

            const sut = maleClone
            // Act
            const result = sut.firstName
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have last name', () => {
            // Arrange
            const expected = 'Smith'

            const sut = maleClone
            // Act
            const result = sut.lastName
            // Assert
            expect(result).toEqual(expected)
        })

        test('should be male', () => {
            // Arrange
            const expected = 'Male'

            const sut = maleClone
            // Act
            const result = sut.gender
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have black hair', () => {
            // Arrange
            const expected = 'Black'

            const sut = maleClone
            // Act
            const result = sut.hairColor
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have 10 fingers', () => {
            // Arrange
            const expected = 10

            const sut = maleClone
            // Act
            const result = sut.numberOfFingers
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have 2 eyes', () => {
            // Arrange
            const expected = 2

            const sut = maleClone
            // Act
            const result = sut.numberOfEyes
            // Assert
            expect(result).toEqual(expected)
        })

        describe('greet', () => {
            test('should be a function', () => {
                // Arrange    
                const expected = 'function'

                const sut = maleClone
                // Act
                // Assert
                expect(typeof sut.greet).toEqual(expected)
            })

            test('should return greeting', () => {
                // Arrange    
                const expected = 'Hi there, my name is John Smith, nice to meet you :)'

                const sut = maleClone
                // Act
                const result = sut.greet()
                // Assert
                expect(result).toEqual(expected)
            })
        })        
    })

    describe('femaleClone', () => {
        test('should have first name', () => {
            // Arrange
            const expected = 'Jane'

            const sut = femaleClone
            // Act
            const result = sut.firstName
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have last name', () => {
            // Arrange
            const expected = 'Doe'

            const sut = femaleClone
            // Act
            const result = sut.lastName
            // Assert
            expect(result).toEqual(expected)
        })

        test('should be female', () => {
            // Arrange
            const expected = 'Female'

            const sut = femaleClone
            // Act
            const result = sut.gender
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have blonde hair', () => {
            // Arrange
            const expected = 'Blonde'

            const sut = femaleClone
            // Act
            const result = sut.hairColor
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have 10 fingers', () => {
            // Arrange
            const expected = 10

            const sut = femaleClone
            // Act
            const result = sut.numberOfFingers
            // Assert
            expect(result).toEqual(expected)
        })

        test('should have 2 eyes', () => {
            // Arrange
            const expected = 2

            const sut = femaleClone
            // Act
            const result = sut.numberOfEyes
            // Assert
            expect(result).toEqual(expected)
        })

        describe('greet', () => {
            test('should be function', () => {
                // Arrange    
                const expected = 'function'

                const sut = femaleClone
                // Act
                // Assert
                expect(typeof sut.greet).toEqual(expected)
            })

            test('should return greeting', () => {
                // Arrange    
                const expected = 'Hi there, my name is Jane Doe, nice to meet you :)'

                const sut = femaleClone
                // Act
                const result = sut.greet()
                // Assert
                expect(result).toEqual(expected)
            })
        })        
    })
})