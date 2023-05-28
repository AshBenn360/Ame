using Application.ApplicationInformation;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Quotations
{
    public class EditApplicationInformation
    {
        public class Command : IRequest<Result<Unit>> 
        {
            public AppInformation AppInformation {get; set;}
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
            
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
                
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var appInfo = await _context.ApplicationInformationDetails.FindAsync(request.AppInformation.Id);

                if (appInfo == null) return null;

                _mapper.Map(request.AppInformation, appInfo);

               var result = await _context.SaveChangesAsync() > 0;

               if(!result) return Result<Unit>.Failure("Failed to update application Information");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}