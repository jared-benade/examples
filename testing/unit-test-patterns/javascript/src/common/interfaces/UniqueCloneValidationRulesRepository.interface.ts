import { Gender } from '../models/gender'

export interface IUniqueCloneValidationRulesRepository {
  getValidFirstNames(gender: Gender): string[]
  getValidLastNames(): string[]
  getMaximumNumberOfEyes(): Promise<number>
}
