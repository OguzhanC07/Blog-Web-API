using Blog.DTO.DTOs.CommentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("E-mail alanı boş bırakılamaz");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
            
        }
    }
}
