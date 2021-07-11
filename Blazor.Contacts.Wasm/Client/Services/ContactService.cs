using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;

namespace Client.Services
{
    public class ContactService : IContactService
    {
        public Task DeleteContact(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveContact(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}