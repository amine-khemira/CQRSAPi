using cqrssAPI.Context;
using cqrssAPI.Models;
using MediatR;

namespace cqrssAPI.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public class CreatUserHandler: IRequestHandler<CreateUserCommand,int>
        {
            private readonly IApplicationContext _context;
            public CreatUserHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUserCommand command,CancellationToken cancellationToken)
            {
                var user = new User();
                user.Name = command.Name;
                user.LastName = command.LastName;

                await _context.Users.AddAsync(user);
                await _context.SaveChanges();
                return user.Id;
            }
        }


    }
}
