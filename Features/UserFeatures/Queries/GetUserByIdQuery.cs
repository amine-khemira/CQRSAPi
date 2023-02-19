using cqrssAPI.Context;
using cqrssAPI.Models;
using MediatR;

public class GetUserByIdQuery : IRequest<User>
{
    public int Id { get; set; }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IApplicationContext _context;
        public GetUserByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var User = _context.Users.Where(a => a.Id == query.Id).FirstOrDefault();
            if (User == null) return null;
            return User;
        }
    }
}