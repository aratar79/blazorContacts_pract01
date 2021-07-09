using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;

namespace Repositories
{
    public interface IContactRepository
    {
         Task<bool> InsertContact(Contact contact);
         Task<bool> UpdateContact(Contact contact);
         Task DeleteContact (int id);
         Task<IEnumerable<Contact>> GetAll();
         Task<Contact> GetContact(int id);
    }
}