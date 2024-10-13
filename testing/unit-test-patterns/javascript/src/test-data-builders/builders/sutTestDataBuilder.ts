import { CloneEvaluationCentre } from '../../common/CloneEvaluationCentre'
import { IClone } from '../../common/interfaces/Clone.interface'
import { Gender } from '../../common/models/gender'
import { UniqueCloneValidationRulesRepository } from '../../common/services/UniqueCloneValidationRulesRepository'

export class SutTestDataBuilder {
  private validationRepo = new UniqueCloneValidationRulesRepository()
  private cloneToValidate: IClone

  constructor(cloneToValidate: IClone) {
    this.cloneToValidate = cloneToValidate
  }

  cloneHasInvalidFirstName() {
    this.validationRepo.getValidFirstNames = jest.fn(() => {
      return [`Not ${this.cloneToValidate.firstName}`]
    })

    return this
  }

  cloneHasInvalidMaleFirstName() {
    this.validationRepo.getValidFirstNames = jest.fn(() => {
      return this.cloneToValidate.gender === Gender.male
        ? [`Not ${this.cloneToValidate.firstName}`]
        : [this.cloneToValidate.firstName]
    })

    return this
  }

  cloneHasInvalidLastName() {
    this.validationRepo.getValidLastNames = jest.fn(() => {
      return [`Not ${this.cloneToValidate.lastName}`]
    })

    return this
  }

  cloneHasValidFirstName() {
    this.validationRepo.getValidFirstNames = jest.fn(() => {
      return [this.cloneToValidate.firstName]
    })

    return this
  }

  cloneHasValidLastName() {
    this.validationRepo.getValidLastNames = jest.fn(() => {
      return [this.cloneToValidate.lastName]
    })

    return this
  }

  cloneHasTooManyEyes() {
    this.validationRepo.getMaximumNumberOfEyes = jest.fn(() => {
      return Promise.resolve(this.cloneToValidate.numberOfEyes - 1)
    })

    return this
  }

  cloneHasValidNumberOfEyes() {
    this.validationRepo.getMaximumNumberOfEyes = jest.fn(() => {
      return Promise.resolve(this.cloneToValidate.numberOfEyes)
    })

    return this
  }

  build() {
    return new CloneEvaluationCentre(this.validationRepo)
  }
}
