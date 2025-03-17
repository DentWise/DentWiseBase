//using DotNetBase.Business.Identity.Interfaces;
//using DotNetBase.EFCore.UnitOfWork;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Identity;
//using DotNetBase.Infrastructure.Common.Helpers;

//namespace DotNetBase.Business.Identity.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public UserService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
//        {
//            //Validasyon
//            if (string.IsNullOrWhiteSpace(createUserDto.EMail))
//            {
//                throw new ArgumentException("Email cannot be empty.", nameof(createUserDto.EMail));
//            }
//            if (string.IsNullOrWhiteSpace(createUserDto.Password))
//            {
//                throw new ArgumentException("Password cannot be empty.", nameof(createUserDto.Password));
//            }
//            // E-posta benzersiz mi kontrol et
//            var existingUser = await _unitOfWork.UserRepository.FindOneAsync(u => u.EMail == createUserDto.EMail && !u.IsDeleted);
//            if (existingUser != null)
//            {
//                throw new InvalidOperationException("A user with this email already exists.");
//            }


//            // Şifreyi hash'le (bcrypt kullanarak)
//            string hashedPassword = HashHelper.HashPassword(createUserDto.Password);

//            var newUser = new User
//            {
//                EMail = createUserDto.EMail,
//                HashedPassword = hashedPassword,
//                RoleId = createUserDto.RoleId,
//                PhoneNumber = createUserDto.PhoneNumber,
//                CompanyId = createUserDto.CompanyId,
//                IsDeleted = false, //Yeni kullanıcı soft delete false
//                CreatedAt = DateTime.UtcNow,
//            };

//            await _unitOfWork.UserRepository.AddAsync(newUser);
//            await _unitOfWork.CompleteAsync();


//            return new UserDto
//            {
//                Id = newUser.Id,
//                EMail = newUser.EMail,
//                RoleId = newUser.RoleId,
//                PhoneNumber = newUser.PhoneNumber,
//                RoleName = newUser.Role?.Name,  // Role null olabilir.
//                CreatedAt = newUser.CreatedAt,
//                UpdatedAt = newUser.UpdatedAt
//            };
//        }

//        public async Task DeleteUserAsync(int id)
//        {
//            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
//            if (user == null || user.IsDeleted)
//            {
//                throw new Exception("User Not Found!"); //NotFoundException() fırlatılabilir.
//            }

//            user.IsDeleted = true;
//            user.DeletedAt = DateTime.UtcNow;
//            //_unitOfWork.Users.Remove(user);  // *Fiziksel* silme.  YAPMAYIN!
//            _unitOfWork.UserRepository.Update(user); // Soft delete için Update kullanıyoruz.

//            //var dentist = await _unitOfWork.DentistRepository.FindOneAsync(x => x.UserId == id);
//            //if (dentist != null)
//            //{
//            //    dentist.IsDeleted = true;
//            //    dentist.DeletedAt = DateTime.UtcNow;
//            //    _unitOfWork.DentistRepository.Update(dentist);
//            //}

//            await _unitOfWork.CompleteAsync();
//        }

//        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
//        {
//            var users = await _unitOfWork.UserRepository.FindManyAsync(u => !u.IsDeleted); // Sadece silinmemiş kullanıcılar

//            return users.Select(user => new UserDto
//            {
//                Id = user.Id,
//                EMail = user.EMail,
//                RoleId = user.RoleId,
//                PhoneNumber = user.PhoneNumber,
//                RoleName = user.Role?.Name, // ?.  Role'ün null olup olmadığını kontrol eder.
//                CreatedAt = user.CreatedAt,
//                UpdatedAt = user.UpdatedAt
//            }).ToList();
//        }

//        public async Task<UserDto> GetUserByIdAsync(int id)
//        {
//            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
//            if (user == null || user.IsDeleted)
//            {
//                return null; // Veya exception fırlat.
//            }

//            return new UserDto
//            {
//                Id = user.Id,
//                EMail = user.EMail,
//                RoleId = user.RoleId,
//                PhoneNumber = user.PhoneNumber,
//                RoleName = user.Role?.Name,
//                CreatedAt = user.CreatedAt,
//                UpdatedAt = user.UpdatedAt
//            };
//        }

//        public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto)
//        {
//            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
//            if (user == null || user.IsDeleted)
//            {
//                throw new Exception("User Not Found");
//            }

//            // E-posta benzersiz mi kontrol et (eğer değiştirildiyse)
//            if (!string.IsNullOrEmpty(updateUserDto.EMail) && updateUserDto.EMail != user.EMail)
//            {
//                var existingUser = await _unitOfWork.UserRepository.FindOneAsync(u => u.EMail == updateUserDto.EMail && u.Id != id && !u.IsDeleted);
//                if (existingUser != null)
//                {
//                    throw new InvalidOperationException("A user with this email already exists.");
//                }
//            }
//            // Null olmayan alanları güncelle
//            if (updateUserDto.EMail != null)
//            {
//                user.EMail = updateUserDto.EMail;
//            }
//            if (updateUserDto.Password != null)
//            {
//                user.HashedPassword = HashHelper.HashPassword(updateUserDto.Password); // Yeni şifreyi hash'le
//            }
//            if (updateUserDto.RoleId != null)
//            {
//                user.RoleId = updateUserDto.RoleId.Value;
//            }
//            if (updateUserDto.PhoneNumber != null)
//            {
//                user.PhoneNumber = updateUserDto.PhoneNumber;
//            }

//            user.UpdatedAt = DateTime.UtcNow;
//            _unitOfWork.UserRepository.Update(user);
//            await _unitOfWork.CompleteAsync();
//        }

//        public async Task<UserDto> GetUserByEmailAsync(string email)
//        {
//            var user = await _unitOfWork.UserRepository.FindOneAsync(u => u.EMail == email && !u.IsDeleted);

//            if (user == null)
//            {
//                return null;
//            }

//            return new UserDto
//            {
//                Id = user.Id,
//                EMail = user.EMail,
//                RoleId = user.RoleId,
//                PhoneNumber = user.PhoneNumber,
//                RoleName = user.Role?.Name,
//                CreatedAt = user.CreatedAt,
//                UpdatedAt = user.UpdatedAt
//            };
//        }

//        public async Task<bool> CheckPasswordAsync(int userId, string password)
//        {
//            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
//            if (user == null || user.IsDeleted)
//            {
//                return false;
//            }
//            //Bcrypt Kullanımı
//            return HashHelper.VerifyPassword(password, user.HashedPassword);
//        }

//        public async Task SendVerificationCodeEmailAsync(string email)
//        {
//            var code = GenerateVerificationCode();
//            var expirationDate = DateTime.UtcNow.AddMinutes(15);

//            var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.EMail == email);
//            if (user == null)
//            {
//                throw new Exception("User not found!");
//            }

//            var verificationCode = new VerificationCode
//            {
//                UserId = user.Id,
//                Code = code,
//                CodeType = Entities.Enum.VerificationCodeTypeEnum.Email,
//                ExpirationDate = expirationDate,
//                CreatedAt = DateTime.UtcNow,
//                isUsed = false
//            };
//            await _unitOfWork.VerificationCodeRepository.AddAsync(verificationCode);
//            await _unitOfWork.CompleteAsync();

//            //TODO: email servis.
//        }

//        public async Task<bool> VerifyCodeAsync(int userId, string code)
//        {
//            var verificationCode = await _unitOfWork.VerificationCodeRepository
//                    .FindOneAsync(x => x.UserId == userId && x.Code == code && x.ExpirationDate > DateTime.UtcNow && !x.isUsed);
//            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

//            if (verificationCode == null)
//                throw new Exception("Invalid or expired verification code.");

//            verificationCode.isUsed = true;
//            _unitOfWork.VerificationCodeRepository.Update(verificationCode);

//            _unitOfWork.UserRepository.Update(user);

//            await _unitOfWork.CompleteAsync();

//            return true;
//        }

//        private string GenerateVerificationCode()
//        {
//            var random = new Random();
//            return random.Next(100000, 999999).ToString();
//        }
//    }
//}
