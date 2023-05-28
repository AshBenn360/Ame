using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quotations
{
    public class ListApplicationInformation
    {
        public class Query : IRequest<Result<PagedList<ApplicationInformationDto>>> {
            public PagingParams Params {get; set;}
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ApplicationInformationDto>>>
        {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public async Task<Result<PagedList<ApplicationInformationDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
                var query = _context.ApplicationInformationDetails.ProjectTo<ApplicationInformationDto>(_mapper.ConfigurationProvider).AsQueryable();

               return Result<PagedList<ApplicationInformationDto>>.Success(await PagedList<ApplicationInformationDto>.CreateAsync(query, request.Params.PageNumber, 
               request.Params.PageSize));
        }
        }
    }
}