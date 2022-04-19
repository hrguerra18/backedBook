using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class UserSpecification : Specification<User>
    {
        public UserSpecification(string username)
        {
            Query.Where(x => x.Username == username);
        }

        public UserSpecification(string username, string password)
        {
            Query.Where(u => u.Username == username && u.Password == password);
        }
    }
}
