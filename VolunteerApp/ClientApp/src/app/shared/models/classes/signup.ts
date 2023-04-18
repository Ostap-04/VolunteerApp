import { Login } from "./login";

export class SignupData extends Login {
  constructor(
    NickName:string,
    public Surname: string,
    public Name: string,
    public MidName: string,
    public Phone_Number: string,
    Email: string,
    Password: string,
    public Role: string,
    public Verification: File)
  {
    super(NickName, Email, Password);
  }
}