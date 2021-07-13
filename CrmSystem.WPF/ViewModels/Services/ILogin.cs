using CrmSystem.Domain.Models;

namespace CrmSystem.WPF.ViewModels.Services
{
    public interface ILogin<TEntity> where TEntity:class
    {
        TEntity Login(string email, string password);
    }
}