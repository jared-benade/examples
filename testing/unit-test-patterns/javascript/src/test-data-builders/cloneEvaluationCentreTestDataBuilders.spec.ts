import { CloneTestDataBuilder } from './builders/cloneTestDataBuilder'
import { SutTestDataBuilder } from './builders/sutTestDataBuilder'

describe('cloneEvaluationCentreTestDataBuilder', () => {
  describe('isCloneValid', () => {
    describe('clone is unique', () => {
      it('should return invalid validation response given clone has invalid first name', async () => {
        // Arrange
        const clone = new CloneTestDataBuilder()
          .withGenericMaleBase()
          .withFirstName('Bob')
          .build()

        const sut = new SutTestDataBuilder(clone)
          .cloneHasInvalidFirstName()
          .build()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid first name for their gender', async () => {
        // Arrange
        const clone = new CloneTestDataBuilder()
          .withGenericMaleBase()
          .withFirstName('Ashley')
          .build()

        const sut = new SutTestDataBuilder(clone)
          .cloneHasInvalidMaleFirstName()
          .build()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid last name', async () => {
        // Arrange
        const clone = new CloneTestDataBuilder()
          .withGenericMaleBase()
          .withLastName('Stark')
          .build()

        const sut = new SutTestDataBuilder(clone)
          .cloneHasValidFirstName()
          .cloneHasInvalidLastName()
          .build()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid last name')
      })

      it('should return invalid validation response given clone has too many eyes', async () => {
        // Arrange
        const clone = new CloneTestDataBuilder()
          .withGenericMaleBase()
          .withNumberOfEyes(3)
          .build()

        const sut = new SutTestDataBuilder(clone)
          .cloneHasValidFirstName()
          .cloneHasValidLastName()
          .cloneHasTooManyEyes()
          .build()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has too many eyes')
      })

      it('should return valid validation response given clone has valid first name, last name and number of eyes', async () => {
        // Arrange
        const clone = new CloneTestDataBuilder()
          .withFirstName('Jimmy')
          .withLastName('Jones')
          .withNumberOfEyes(2)
          .build()

        const sut = new SutTestDataBuilder(clone)
          .cloneHasValidFirstName()
          .cloneHasValidLastName()
          .cloneHasValidNumberOfEyes()
          .build()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeTruthy()
      })
    })
  })
})
