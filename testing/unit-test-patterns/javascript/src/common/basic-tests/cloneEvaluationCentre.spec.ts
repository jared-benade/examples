import { CloneEvaluationCentre } from "../CloneEvaluationCentre";
import { IClone } from "../interfaces/Clone.interface";
import { Gender } from "../models/gender";
import { UniqueCloneValidationRulesRepository } from "../services/UniqueCloneValidationRulesRepository";

describe('cloneEvaluationCentre', () => {
  describe('isCloneValid', () => {
    describe('clone is generic`', () => {
      it('should return valid validation response given clone is generic male', async () => {
        // Arrange
        const clone = createGenericMaleClone()

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeTruthy()
      });

      it('should return valid validation response given clone is generic female', async () => {
        // Arrange
        const clone = createGenericFemaleClone()

        const sut = createSut()
        // Act
        const result = await sut.isCloneValid(clone)
        // Assert
        expect(result.isValid).toBeTruthy()
      });
    });
  });

  function createGenericMaleClone(): IClone {
    return {
      firstName: 'John',
      lastName: 'Smith',
      gender: Gender.male,
      numberOfEyes: 2,
      hairColor: 'Black'
    }
  }

  function createGenericFemaleClone(): IClone {
    return {
      firstName: 'Jane',
      lastName: 'Doe',
      gender: Gender.female,
      numberOfEyes: 2,
      hairColor: 'Blonde'
    }
  }

  function createSut() {
    return new CloneEvaluationCentre(new UniqueCloneValidationRulesRepository())
  }
});