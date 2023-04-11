import { Login } from "./login";

export class SignupData extends Login {
  constructor(
    username:string,
    public surName: string,
    public name: string,
    public fatherName: string,
    public phone: string,
    public email: string,
    public password: string,
    public verification: File)
  {
    super(username, email, password);
  }
}