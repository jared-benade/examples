import { IUniqueCloneValidationRulesRepository } from '../../common/interfaces/UniqueCloneValidationRulesRepository.interface'
import { Gender } from '../../common/models/gender'

export class FakeUniqueCloneValidationRulesRepository
  implements IUniqueCloneValidationRulesRepository
{
  private readonly _validMaleFirstNames = ['John', 'Jimmy', 'Albert', 'Tony']
  private readonly _validFemaleFirstNames = [
    'Jane',
    'Rebecca',
    'Ashley',
    'Emma',
  ]
  private readonly _validLastFirstNames = ['Smith', 'Anderson', 'Doe', 'Jones']
  private readonly _maxNumberOfEyes = 2

  getValidFirstNames(gender: Gender) {
    return gender === Gender.male
      ? this._validMaleFirstNames
      : this._validFemaleFirstNames
  }

  getValidLastNames() {
    return this._validLastFirstNames
  }

  getMaximumNumberOfEyes() {
    return Promise.resolve(this._maxNumberOfEyes)
  }
}
