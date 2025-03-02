// Infrastructure/UnitOfWork.cs
using DotNetBase.EFCore.DBContext;
using DotNetBase.EFCore.Repositories;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Identity;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    private IRepository<User> _userRepository;
    private IRepository<Role> _roleRepository;


    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
    }

    // Lazy loading ile repository'leri oluşturuyoruz.
    public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(_context);
    public IRepository<Role> RoleRepository => _roleRepository ??= new Repository<Role>(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose(); // DbContext'i dispose ediyoruz.
        GC.SuppressFinalize(this);
    }
}