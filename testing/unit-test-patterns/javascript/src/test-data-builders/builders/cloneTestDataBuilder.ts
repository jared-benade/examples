import { IClone } from "../../common/interfaces/Clone.interface";
import { Gender } from "../../common/models/gender";

export class CloneTestDataBuilder {  
  private firstName: string
  private lastName: string
  private gender: Gender
  private numberOfEyes: number
  private hairColor: string

  constructor() {
    this.firstName = ''
    this.lastName = ''
    this.gender = Gender.male
    this.numberOfEyes = 0
    this.hairColor = ''
  }

  withGenericMaleBase() {
    this.firstName = 'John'
    this.lastName = 'Smith'
    this.gender = Gender.male
    this.numberOfEyes = 2
    this.hairColor = 'Black'

    return this
  }

  withFirstName(firstName: string) {
    this.firstName = firstName
    return this
  }

  withLastName(lastName: string) {
    this.lastName = lastName
    return this
  }

  withNumberOfEyes(numberOfEyes: number) {
    this.numberOfEyes = numberOfEyes
    return this
  }

  build(): IClone {
    return {
      firstName: this.firstName,
      lastName: this.lastName,
      gender: this.gender,
      numberOfEyes: this.numberOfEyes,
      hairColor: this.hairColor,
    }
  }
}