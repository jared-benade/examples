import clone from "./prototype"

describe('prototype', () => {
    describe('clone', () => {
        describe('first name', () => {
            test('will have default value set for first name', () => {
                // Arrange
                const expected = 'Jane'

                const sut = new clone()
                // Act
                const result = sut.firstName
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set first name to value given', () => {
                // Arrange       
                const expected = 'Charles'
                
                const sut = new clone()
                sut.firstName = 'Charles'
                // Act
                const result = sut.firstName
                // Assert
                expect(result).toEqual(expected)
            })

            test('first name is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('firstName' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('firstName')).toBeFalsy()
            })
        })

        describe('last name', () => {
            test('will have default value set for last name', () => {
                // Arrange
                const expected = 'Doe'

                const sut = new clone()
                // Act
                const result = sut.lastName
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set last name to value given', () => {
                // Arrange       
                const expected = 'Xavier'
                
                const sut = new clone()
                sut.lastName = 'Xavier'
                // Act
                const result = sut.lastName
                // Assert
                expect(result).toEqual(expected)
            })

            test('last name is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('lastName' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('lastName')).toBeFalsy()
            })
        })

        describe('gender', () => {
            test('will have default value set for gender', () => {
                // Arrange
                const expected = 'Female'

                const sut = new clone()
                // Act
                const result = sut.gender
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set gender to value given', () => {
                // Arrange       
                const expected = 'Male'
                
                const sut = new clone()
                sut.gender = 'Male'
                // Act
                const result = sut.gender
                // Assert
                expect(result).toEqual(expected)
            })

            test('gender is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('gender' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('gender')).toBeFalsy()
            })
        })

        describe('hairColor', () => {
            test('will have default value set for hair color', () => {
                // Arrange
                const expected = 'Blonde'

                const sut = new clone()
                // Act
                const result = sut.hairColor
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set hair color to value given', () => {
                // Arrange       
                const expected = 'Black'
                
                const sut = new clone()
                sut.hairColor = 'Black'
                // Act
                const result = sut.hairColor
                // Assert
                expect(result).toEqual(expected)
            })

            test('hair color is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('hairColor' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('hairColor')).toBeFalsy()
            })
        })

        describe('numberOfFingers', () => {
            test('will have default value set for number of fingers', () => {
                // Arrange
                const expected = 10

                const sut = new clone()
                // Act
                const result = sut.numberOfFingers
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set number of fingers to value given', () => {
                // Arrange       
                const expected = 11
                
                const sut = new clone()
                sut.numberOfFingers = 11
                // Act
                const result = sut.numberOfFingers
                // Assert
                expect(result).toEqual(expected)
            })

            test('number of fingers is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('numberOfFingers' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('numberOfFingers')).toBeFalsy()
            })
        })

        describe('numberOfEyes', () => {
            test('will have default value set for number of eyes', () => {
                // Arrange
                const expected = 2

                const sut = new clone()
                // Act
                const result = sut.numberOfEyes
                // Assert
                expect(result).toEqual(expected)
            })

            test('will set number of eyes to value given', () => {
                // Arrange       
                const expected = 3
                
                const sut = new clone()
                sut.numberOfEyes = 3
                // Act
                const result = sut.numberOfEyes
                // Assert
                expect(result).toEqual(expected)
            })

            test('number of eyes is set on prototype and not on instance', () => {
                 // Arrange
                 const sut = new clone()
                 // Act
                 // Assert
                 expect('numberOfEyes' in sut).toBeTruthy()
                 expect(sut.hasOwnProperty('numberOfEyes')).toBeFalsy()
            })
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

                const sut = new clone()
                // Need to update the prototype object directly to update its usage within a function call                
                sut.__proto__.firstName = 'Charles'
                sut.__proto__.lastName = 'Xavier'
                // Act
                const result = sut.greet()
                // Assert
                expect(result).toEqual(expected)
            })

            test('greet function is set on prototype and not on instance', () => {
                // Arrange
                const sut = new clone()
                // Act
                // Assert
                expect('greet' in sut).toBeTruthy()
                expect(sut.hasOwnProperty('greet')).toBeFalsy()
           })
        })
    })
})