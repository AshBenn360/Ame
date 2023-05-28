using Application.Core;
using MediatR;
using Persistence;

namespace Application.Quotations
{
    public class DeleteApplicationInformationDetails
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id {get; set;}
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
                var appInformation = await _context.ApplicationInformationDetails.FindAsync(request.Id);
                
                if(appInformation == null) return null;

                _context.Remove(appInformation);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the app information");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}