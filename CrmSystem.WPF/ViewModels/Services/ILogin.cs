using CrmSystem.Domain.Models;

namespace CrmSystem.WPF.ViewModels.Services
{
    public interface ILogin<TEntity> where TEntity:class
    {
        LoginStateOption Login(string email, string password, out TEntity entity);
    }
}