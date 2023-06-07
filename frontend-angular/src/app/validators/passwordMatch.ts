import { AbstractControl, FormGroup } from "@angular/forms";

export function passwordMatch(password: string, confirmPassword: string) {
  return function (control: AbstractControl) {
    const formGroup = control as FormGroup;
    const passwordValue = formGroup.get(password)?.value;
    const confirmPasswordValue = formGroup.get(confirmPassword)?.value;
    if (passwordValue === confirmPasswordValue) {
      return null;
    }
    return { passwordMismatchError: true };
  };
}
