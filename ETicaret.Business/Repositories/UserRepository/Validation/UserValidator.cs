using ETicaret.Entities.Concrete;
using FluentValidation;

namespace ETicaret.Business.Repositories.UserRepository.Validation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir mail adresi yazın");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Kullanıcı resmi boş olamaz");
        }
    }
}
