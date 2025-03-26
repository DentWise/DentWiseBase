using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using DotNetBase.Infrastructure.Common.Helpers;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUserAsync(CreateUser createUser)
        {
            //Validasyon
            if (string.IsNullOrWhiteSpace(createUser.Email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(createUser.Email));
            }
            if (string.IsNullOrWhiteSpace(createUser.Password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(createUser.Password));
            }
            // E-posta benzersiz mi kontrol et
            var existingUser = await _unitOfWork.UserRepository.FindOneAsync(u => u.Email == createUser.Email && !u.IsDeleted);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }


            // Şifreyi hash'le (bcrypt kullanarak)
            string hashedPassword = HashHelper.HashPassword(createUser.Password);

            var newUser = new User
            {
                CompanyId = createUser.CompanyId,
                ContactId = createUser.ContactId,
                CreatedAt = DateTime.UtcNow,
                Email = createUser.Email,
                PhoneNumber = createUser.PhoneNumber,
                PasswordHash = hashedPassword,
                RoleId = createUser.RoleId,
                Username = createUser.Username
            };

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.CompleteAsync();


            return newUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                throw new Exception("User Not Found!"); //NotFoundException() fırlatılabilir.
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            //_unitOfWork.Users.Remove(user);  // *Fiziksel* silme.  YAPMAYIN!
            _unitOfWork.UserRepository.Update(user); // Soft delete için Update kullanıyoruz.

            //var dentist = await _unitOfWork.DentistRepository.FindOneAsync(x => x.UserId == id);
            //if (dentist != null)
            //{
            //    dentist.IsDeleted = true;
            //    dentist.DeletedAt = DateTime.UtcNow;
            //    _unitOfWork.DentistRepository.Update(dentist);
            //}

            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.FindManyAsync(u => !u.IsDeleted); // Sadece silinmemiş kullanıcılar
            if (users == null)
                throw new Exception("Users dont have any item!");

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null || user.IsDeleted)
                throw new Exception("Object not found!");

            return user;
        }

        public async Task UpdateUserAsync(int id, UpdateUser updateUser)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                throw new Exception("User Not Found");
            }

            // E-posta benzersiz mi kontrol et (eğer değiştirildiyse)
            if (!string.IsNullOrEmpty(updateUser.Email) && updateUser.Email != user.Email)
            {
                var existingUser = await _unitOfWork.UserRepository.FindOneAsync(u => u.Email == updateUser.Email && u.Id != id && !u.IsDeleted);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("A user with this email already exists.");
                }
            }
            // Null olmayan alanları güncelle
            if (updateUser.Email != null)
                user.Email = updateUser.Email;
            if (updateUser.PhoneNumber != null)
                user.PhoneNumber = updateUser.PhoneNumber;
            if (updateUser.RoleId != null)
                user.RoleId = updateUser.RoleId.Value;

            user.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.FindOneAsync(u => u.Email == email && !u.IsDeleted);

            if (user == null)
                throw new Exception("Object not found!");

            return user;
        }

        //public async Task<bool> CheckPasswordAsync(int userId, string password)
        //{
        //    var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
        //    if (user == null || user.IsDeleted)
        //    {
        //        return false;
        //    }
        //    //Bcrypt Kullanımı
        //    return HashHelper.VerifyPassword(password, user.HashedPassword);
        //}

        //public async Task SendVerificationCodeEmailAsync(string email)
        //{
        //    var code = GenerateVerificationCode();
        //    var expirationDate = DateTime.UtcNow.AddMinutes(15);

        //    var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.EMail == email);
        //    if (user == null)
        //    {
        //        throw new Exception("User not found!");
        //    }

        //    var verificationCode = new VerificationCode
        //    {
        //        UserId = user.Id,
        //        Code = code,
        //        CodeType = Entities.Enum.VerificationCodeTypeEnum.Email,
        //        ExpirationDate = expirationDate,
        //        CreatedAt = DateTime.UtcNow,
        //        isUsed = false
        //    };
        //    await _unitOfWork.VerificationCodeRepository.AddAsync(verificationCode);
        //    await _unitOfWork.CompleteAsync();

        //    //TODO: email servis.
        //}

        //public async Task<bool> VerifyCodeAsync(int userId, string code)
        //{
        //    var verificationCode = await _unitOfWork.VerificationCodeRepository
        //            .FindOneAsync(x => x.UserId == userId && x.Code == code && x.ExpirationDate > DateTime.UtcNow && !x.isUsed);
        //    var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

        //    if (verificationCode == null)
        //        throw new Exception("Invalid or expired verification code.");

        //    verificationCode.isUsed = true;
        //    _unitOfWork.VerificationCodeRepository.Update(verificationCode);

        //    _unitOfWork.UserRepository.Update(user);

        //    await _unitOfWork.CompleteAsync();

        //    return true;
        //}

        //private string GenerateVerificationCode()
        //{
        //    var random = new Random();
        //    return random.Next(100000, 999999).ToString();
        //}
    }
}
