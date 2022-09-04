using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Queries.GetById
{
    public class GetProgrammingLanguageByIdValidator : AbstractValidator<GetProgrammingLanguageByIdQuery>
    {
        public GetProgrammingLanguageByIdValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
