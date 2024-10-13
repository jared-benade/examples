import { CloneEvaluationCentre } from '../common/CloneEvaluationCentre'
import { IClone } from '../common/interfaces/Clone.interface'
import { Gender } from '../common/models/gender'
import { UniqueCloneValidationRulesRepository } from '../common/services/UniqueCloneValidationRulesRepository'

describe('cloneEvaluationCentreSpy', () => {
  describe('isCloneValid', () => {
    describe('clone is unique', () => {
      beforeEach(() => {
        jest.restoreAllMocks()
        jest.resetAllMocks()
      })

      it('should return invalid validation response given clone has invalid first name', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Bob' })

        const getValidFirstNamesSpy = jest.spyOn(
          UniqueCloneValidationRulesRepository.prototype,
          'getValidFirstNames'
        )
        getValidFirstNamesSpy.mockReturnValue(['Not Bob'])

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(getValidFirstNamesSpy).toHaveBeenCalledTimes(1)
        expect(getValidFirstNamesSpy).toHaveBeenCalledWith(clone.gender)
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid first name for their gender', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Ashley', gender: Gender.male })

        const getValidFirstNamesSpy = jest.spyOn(
          UniqueCloneValidationRulesRepository.prototype,
          'getValidFirstNames'
        )
        getValidFirstNamesSpy.mockImplementation((gender) => {
          return gender === Gender.male ? ['Not Ashley'] : ['Ashley']
        })

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(getValidFirstNamesSpy).toHaveBeenCalledTimes(1)
        expect(getValidFirstNamesSpy).toHaveBeenCalledWith(clone.gender)
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid last name', async () => {
        // Arrange
        const clone = createClone({ lastName: 'Stark' })

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidFirstNames'
          )
          .mockReturnValue([clone.firstName])

        const getValidLastNamesSpy = jest.spyOn(
          UniqueCloneValidationRulesRepository.prototype,
          'getValidLastNames'
        )
        getValidLastNamesSpy.mockReturnValue(['Not Stark'])

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(getValidLastNamesSpy).toHaveBeenCalledTimes(1)
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid last name')
      })

      it('should return invalid validation response given clone has too many eyes', async () => {
        // Arrange
        const clone = createClone({ numberOfEyes: 3 })

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidFirstNames'
          )
          .mockReturnValue([clone.firstName])

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidLastNames'
          )
          .mockReturnValue([clone.lastName])

        const getMaximumNumberOfEyesSpy = jest.spyOn(
          UniqueCloneValidationRulesRepository.prototype,
          'getMaximumNumberOfEyes'
        )
        getMaximumNumberOfEyesSpy.mockResolvedValue(2)

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(getMaximumNumberOfEyesSpy).toHaveBeenCalledTimes(1)
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has too many eyes')
      })

      it('should return valid validation response given clone has valid first name, last name and number of eyes', async () => {
        // Arrange
        const clone = createClone({
          firstName: 'Jimmy',
          lastName: 'Jones',
          gender: Gender.male,
          numberOfEyes: 2,
        })

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidFirstNames'
          )
          .mockReturnValue([clone.firstName])

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidLastNames'
          )
          .mockReturnValue([clone.lastName])

        jest
          .spyOn(
            UniqueCloneValidationRulesRepository.prototype,
            'getMaximumNumberOfEyes'
          )
          .mockResolvedValue(clone.numberOfEyes)

        const sut = createSut()
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

  function createSut() {
    return new CloneEvaluationCentre(new UniqueCloneValidationRulesRepository())
  }
})
