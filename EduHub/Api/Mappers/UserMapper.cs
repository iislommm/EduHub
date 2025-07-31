//namespace Application.Mappers;

//public static class UserMapper
//{
    
//        public static User ToUserEntity(UserCreateDto dto)
//        {
//            return new User
//            {
//                FirstName = dto.FirstName,
//                SecondName = dto.SecondName,
//                UserName = dto.UserName,
//                PhoneNumber = dto.PhoneNumber,
//                Email = dto.Email,
//                PasswordHash =dto.PasswordHash,
//                PasswordSalt = dto.PasswordSalt,
//                Age = dto.Age,
//                RoleId = dto.RoleId,
//                InstructorId = dto.InstructorId,
//            };
//        }

//    public static UserDto ToUserDto(User user)
//    {
//        return new UserDto
//        {
//            Id = user.Id,
//            FirstName = user.FirstName,
//            SecondName = user.SecondName,
//            UserName = user.UserName,
//            PhoneNumber = user.PhoneNumber,
//            Email = user.Email,
//            Age = user.Age,
//            RoleId = user.RoleId,
//            InstructorId = user.InstructorId
//        };
//    }

//    public static void UpdateEntity(User user, UserUpdateDto dto)
//    {
//        user.FirstName = dto.FirstName;
//        user.SecondName = dto.SecondName;
//        user.UserName = dto.UserName;
//        user.PhoneNumber = dto.PhoneNumber;
//        user.Age = dto.Age;
//        // Email, PasswordHash, RoleId, ChannelId o‘zgartirilmaydi odatda
//    }
//}
