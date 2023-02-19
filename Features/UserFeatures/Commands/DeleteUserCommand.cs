using cqrssAPI.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrssAPI.Features.UserFeatures.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteUserHandler:IRequestHandler<DeleteUserCommand,int>
        {
            private readonly IApplicationContext _context;
            public DeleteUserHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUserCommand command,CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (user == null) return default;
                _context.Users.Remove(user);
                await _context.SaveChanges();
                return user.Id;
            }
        }
    }
}
