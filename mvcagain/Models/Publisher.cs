using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcagain.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }
    }

    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(publisher => publisher.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50)
                .WithMessage("Invalid publisher name");

            RuleFor(p => p.Id).Must(id => id > 0);
        }
    }
}