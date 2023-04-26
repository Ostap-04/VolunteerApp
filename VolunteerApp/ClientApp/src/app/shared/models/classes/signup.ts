
export class SignupData{
  constructor(
    public NickName:string,
    public Surname: string,
    public Name: string,
    public MidName: string,
    public Phone_Number: string,
    public Email: string,
    public Password: string,
    public Role: string,
    public Verification: File) { }
}
