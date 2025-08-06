export interface SignUpDto {
  firstName: string;
  secondName: string;
  username: string;
  phoneNumber: string;
  email: string;
  password: string;
  age: number;
}

export interface UserLoginDto {
  userName: string;
  password: string;
}

export interface UserGetDto {
  id: number;
  firstName: string;
  secondName: string;
  username: string;
  phoneNumber: string;
  email: string;
  age: number;
  role: string;
}

export interface LoginResponseDto {
  token: string;
  refreshToken: string;
  user: UserGetDto;
}

export interface TokenDto {
  token: string;
  refreshToken: string;
}