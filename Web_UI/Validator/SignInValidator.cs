using FluentValidation;
using Web_UI.Models;

namespace Web_UI.Validator
{
    public class SignInValidator:AbstractValidator<LoginResultModel>
    {
        public SignInValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre Boş Bırakılamaz");
        }
    }
}
