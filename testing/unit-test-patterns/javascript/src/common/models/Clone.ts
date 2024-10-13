import { IClone } from '../interfaces/Clone.interface'
import { Gender } from './gender'

export class Clone implements IClone {
  constructor(
    firstName: string,
    lastName: string,
    gender: Gender,
    hairColor: string,
    numberOfEyes: number
  ) {
    this.firstName = firstName
    this.lastName = lastName
    this.gender = gender
    this.hairColor = hairColor
    this.numberOfEyes = numberOfEyes
  }

  firstName: string
  lastName: string
  gender: Gender
  hairColor: string
  numberOfEyes: number
}
