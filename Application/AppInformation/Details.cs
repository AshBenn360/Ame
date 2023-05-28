using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Quotations
{
    public class DetailsApplicationInformation
    {
        public class Query : IRequest<Result<AppInformation>>
        {
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Query, Result<AppInformation>>
        {
        private readonly DataContext _context;
        
            public Handler(DataContext context)
            {
                _context = context;
           
            }

            public async Task<Result<AppInformation>> Handle(Query request, CancellationToken cancellationToken)
            {
               var appInfo = await _context.ApplicationInformationDetails.FindAsync(request.Id);

               return Result<AppInformation>.Success(appInfo);
            }
        }
    }
}