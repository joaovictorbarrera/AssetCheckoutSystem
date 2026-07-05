const emailRegex = /\w+@\w+/

export function isValidEmail(emailAddress: string): boolean {
  return emailRegex.test(emailAddress)
}
