import * as sinon from 'sinon'

import { CloneEvaluationCentre } from '../common/CloneEvaluationCentre'
import { IClone } from '../common/interfaces/Clone.interface'
import { Gender } from '../common/models/gender'
import { UniqueCloneValidationRulesRepository } from '../common/services/UniqueCloneValidationRulesRepository'

describe('cloneEvaluationCentreMock', () => {
  describe('isCloneValid', () => {
    describe('clone is unique', () => {
      beforeEach(() => {
        sinon.restore()
      })

      it('should return invalid validation response given clone has invalid first name', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Bob' })

        const mock = sinon.mock(UniqueCloneValidationRulesRepository.prototype)
        mock
          .expects('getValidFirstNames')
          .withExactArgs(clone.gender)
          .once()
          .returns(['Not Bob'])

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        mock.verify()
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid first name for their gender', async () => {
        // Arrange
        const clone = createClone({ firstName: 'Ashley', gender: Gender.male })

        const mock = sinon.mock(UniqueCloneValidationRulesRepository.prototype)
        mock
          .expects('getValidFirstNames')
          .withExactArgs(clone.gender)
          .once()
          .returns(['Not Ashley'])

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        mock.verify()
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid first name')
      })

      it('should return invalid validation response given clone has invalid last name', async () => {
        // Arrange
        const clone = createClone({ lastName: 'Stark' })

        sinon
          .stub(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidFirstNames'
          )
          .returns([clone.firstName])
        const mock = sinon.mock(UniqueCloneValidationRulesRepository.prototype)
        mock
          .expects('getValidLastNames')
          .withExactArgs()
          .once()
          .returns(['Not Stark'])

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        mock.verify()
        expect(result.isValid).toBeFalsy()
        expect(result.message).toBe('Clone has invalid last name')
      })

      it('should return invalid validation response given clone has too many eyes', async () => {
        // Arrange
        const clone = createClone({ numberOfEyes: 3 })

        sinon
          .stub(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidFirstNames'
          )
          .returns([clone.firstName])
        sinon
          .stub(
            UniqueCloneValidationRulesRepository.prototype,
            'getValidLastNames'
          )
          .returns([clone.lastName])
        const mock = sinon.mock(UniqueCloneValidationRulesRepository.prototype)
        mock.expects('getMaximumNumberOfEyes').withExactArgs().once().returns(2)

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        mock.verify()
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

        const mock = sinon.mock(UniqueCloneValidationRulesRepository.prototype)
        mock
          .expects('getValidFirstNames')
          .withExactArgs(clone.gender)
          .once()
          .returns([clone.firstName])
        mock
          .expects('getValidLastNames')
          .withExactArgs()
          .once()
          .returns([clone.lastName])
        mock
          .expects('getMaximumNumberOfEyes')
          .withExactArgs()
          .once()
          .returns(clone.numberOfEyes)

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        mock.verify()
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
