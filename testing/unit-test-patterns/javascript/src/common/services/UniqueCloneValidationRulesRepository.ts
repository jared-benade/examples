import { IUniqueCloneValidationRulesRepository } from '../interfaces/UniqueCloneValidationRulesRepository.interface'
import { Gender } from '../models/gender'

export class UniqueCloneValidationRulesRepository
  implements IUniqueCloneValidationRulesRepository
{
  getValidFirstNames(gender: Gender): string[] {
    // Make call to database and get list
    return []
  }
  getValidLastNames(): string[] {
    // Make call to database and get list
    return []
  }
  getMaximumNumberOfEyes(): Promise<number> {
    // Make call to database and get value
    return Promise.resolve(0)
  }
}
