using cqrssAPI.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrssAPI.Features.UserFeatures.Commands
{
    public class UpdateUserCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IApplicationContext _context;
            public  UpdateUserHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUserCommand command,CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.Id == command.Id).FirstOrDefault();

                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.Name = command.Name;
                    user.LastName = command.LastName;
                    await _context.SaveChanges();
                    return user.Id;
                }
            }
        }
    }
}
