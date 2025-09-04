using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TG_Ecommerce.Infrastructure.Context;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Infrastructure.Repositories;


// Generic Repository Pattern implementasyonu
// T : class -> Yalnızca referans tipler (Entity sınıfları) kullanılabilir.
// IRepository<T> arayüzünü uygular ve temel CRUD operasyonlarını soyutlar.
// Böylece veri erişim katmanında tekrar eden kodlar azaltılır.
public class EfRepository<T>(EcommerceDbContext context) : IRepository<T> where T : class
{
    // EF Core DbContext referansı. Null verilirse ArgumentNullException fırlatılır.
    protected readonly EcommerceDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    
    // UnitOfWork pattern’i -> Veritabanı işlemlerinin transaction mantığıyla yönetilmesini sağlar.
    public IUnitOfWork UnitOfWork => _context;

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AnyAsync(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}