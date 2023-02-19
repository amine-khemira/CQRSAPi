using cqrssAPI.Context;
using cqrssAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrssAPI.Features.UserFeatures.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
        {
            private readonly IApplicationContext _context;
            public GetUsersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Users.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
