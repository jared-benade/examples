export class ValidationResult {
  private constructor(isValid: boolean, message = '') {
    this.isValid = isValid
    this.message = message
  }

  isValid: boolean
  message: string

  static isValidResult(): ValidationResult {
    return new ValidationResult(true)
  }

  static isInvalidResult(message: string): ValidationResult {
    return new ValidationResult(false, message)
  }
}
