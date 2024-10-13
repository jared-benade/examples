import { IClone } from './interfaces/Clone.interface'
import { IUniqueCloneValidationRulesRepository } from './interfaces/UniqueCloneValidationRulesRepository.interface'
import { Gender } from './models/gender'
import { ValidationResult } from './models/ValidationResult'

export class CloneEvaluationCentre {
  constructor(
    private readonly uniqueCloneValidationRulesRepository: IUniqueCloneValidationRulesRepository
  ) {}

  async isCloneValid(clone: IClone): Promise<ValidationResult> {
    if (this.isGenericMale(clone) || this.isGenericFemale(clone)) {
      return ValidationResult.isValidResult()
    }

    const validFirstNames =
      this.uniqueCloneValidationRulesRepository.getValidFirstNames(clone.gender)
    const hasValidFirstName = validFirstNames.some(
      (x) => x.toLowerCase() === clone.firstName.toLowerCase()
    )
    if (!hasValidFirstName) {
      return ValidationResult.isInvalidResult('Clone has invalid first name')
    }

    const validLastNames =
      this.uniqueCloneValidationRulesRepository.getValidLastNames()
    const hasValidLastName = validLastNames.some(
      (x) => x.toLowerCase() === clone.lastName.toLowerCase()
    )
    if (!hasValidLastName) {
      return ValidationResult.isInvalidResult('Clone has invalid last name')
    }

    const maxNumberOfEyes =
      await this.uniqueCloneValidationRulesRepository.getMaximumNumberOfEyes()
    const hasValidNumberOfEyes = clone.numberOfEyes <= maxNumberOfEyes
    if (!hasValidNumberOfEyes) {
      return ValidationResult.isInvalidResult('Clone has too many eyes')
    }

    return ValidationResult.isValidResult()
  }

  private isGenericMale(clone: IClone): boolean {
    return (
      clone.firstName === 'John' &&
      clone.lastName === 'Smith' &&
      clone.gender === Gender.male &&
      clone.hairColor === 'Black' &&
      this.hasStandardNumberOfEyes(clone)
    )
  }

  private isGenericFemale(clone: IClone): boolean {
    return (
      clone.firstName === 'Jane' &&
      clone.lastName === 'Doe' &&
      clone.gender === Gender.female &&
      clone.hairColor === 'Blonde' &&
      this.hasStandardNumberOfEyes(clone)
    )
  }

  private hasStandardNumberOfEyes(clone: IClone): boolean {
    return clone.numberOfEyes === 2
  }
}
