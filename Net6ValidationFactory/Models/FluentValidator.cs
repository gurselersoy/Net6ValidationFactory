using System;
using System.Text.RegularExpressions;
using FluentValidation;
using Net6ValidationFactory.Models.Entities;

namespace Net6ValidationFactory.Models
{
    public class FluentValidator : AbstractValidator<User>
    {
        public FluentValidator()
        {
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Email Hatalı!!!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email Boş Bırakılamaz");
            RuleFor(x => x.Ad).Length(5,20).WithMessage("Ad Alanı 5,20 karakter arasında olmalı");
            RuleFor(x => x.Sifre).Must(IsValidPassword).NotEmpty().WithMessage("Şifreniz en az bir harf içermelidir");
        }
        public bool IsValidPassword(string Sifre)
        {            Regex reg = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return reg.IsMatch(Sifre);
        }
    }
}