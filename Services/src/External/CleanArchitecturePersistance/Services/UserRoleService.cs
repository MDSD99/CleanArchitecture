using CleanArchitecture.App.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.App.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecturePersistance.Services
{
    public sealed class UserRoleService : IUserRoleService
    {
          private readonly IUserRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRole userRole = new()
            {
                RoleId = request.RoleId,
                UserId = request.UserId
            };

            await _repository.AddAsync(userRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
