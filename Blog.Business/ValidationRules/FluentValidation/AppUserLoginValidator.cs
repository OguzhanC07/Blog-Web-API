using Blog.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılmamalıdır.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılmamalıdır");
        }
    }
}
