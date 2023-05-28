using Application.ApplicationInformation;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Quotations
{
    public class CreateApplicationInformation
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppInformation AppInformation {get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.AppInformation).SetValidator(new ApplicationInformationValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
        private readonly DataContext _context;

            public Handler(DataContext context)
            {
            _context = context;
                
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.ApplicationInformationDetails.Add(request.AppInformation);

               var result = await _context.SaveChangesAsync() > 0;

               if(!result) return Result<Unit>.Failure("Failed to create Application information Details");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}