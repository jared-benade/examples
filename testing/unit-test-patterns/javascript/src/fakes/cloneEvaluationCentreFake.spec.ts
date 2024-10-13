import { CloneEvaluationCentre } from '../common/CloneEvaluationCentre'
import { IClone } from '../common/interfaces/Clone.interface'
import { IUniqueCloneValidationRulesRepository } from '../common/interfaces/UniqueCloneValidationRulesRepository.interface'
import { Gender } from '../common/models/gender'
import { FakeUniqueCloneValidationRulesRepository } from './fake-implementation/FakeUniqueCloneValidationRulesRepository'

describe('cloneEvaluationCentreFake', () => {
  describe('isCloneValid', () => {
    describe('clone is unique', () => {
      it('should return invalid validation response given clone has invalid first name', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Bob' })
        const validationRulesRepo =
          new FakeUniqueCloneValidationRulesRepository()

        const sut = createSut(validationRulesRepo)
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid first name for their gender', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Ashley', gender: Gender.male })
        const validationRulesRepo =
          new FakeUniqueCloneValidationRulesRepository()

        const sut = createSut(validationRulesRepo)
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid last name', async () => {
        // Arrange
        const clone = createClone({ lastName: 'Stark' })
        const validationRulesRepo =
          new FakeUniqueCloneValidationRulesRepository()

        const sut = createSut(validationRulesRepo)
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid last name')
      })

      it('should return invalid validation response given clone has too many eyes', async () => {
        // Arrange
        const clone = createClone({ numberOfEyes: 3 })
        const validationRulesRepo =
          new FakeUniqueCloneValidationRulesRepository()

        const sut = createSut(validationRulesRepo)
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has too many eyes')
      })

      it('should return valid validation response given clone has valid first name, last name and number of eyes', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Jimmy', lastName: 'Jones', gender: Gender.male, numberOfEyes: 2 })
        const validationRulesRepo =
          new FakeUniqueCloneValidationRulesRepository()

        const sut = createSut(validationRulesRepo)
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeTruthy()
      })
    })
  })

  function createClone(cloneProps?: Partial<IClone>): IClone {
    return {
      firstName: 'John',
      lastName: 'Smith',
      gender: Gender.male,
      numberOfEyes: 2,
      hairColor: 'Black',
      ...cloneProps,
    }
  }

  function createSut(
    validationRulesRepo: IUniqueCloneValidationRulesRepository
  ) {
    return new CloneEvaluationCentre(validationRulesRepo)
  }
})
