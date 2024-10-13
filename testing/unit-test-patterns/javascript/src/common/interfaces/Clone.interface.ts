import { Gender } from '../models/gender'

export interface IClone {
  firstName: string
  lastName: string
  gender: Gender
  hairColor: string
  numberOfEyes: number
}
