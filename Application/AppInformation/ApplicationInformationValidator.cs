using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.ApplicationInformation
{
    public class ApplicationInformationValidator :AbstractValidator<AppInformation>
    {
        public ApplicationInformationValidator()
        {
            
        }
    }
}