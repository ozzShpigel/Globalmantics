using Globalmantics.DAL;
using Globalmantics.Domain;
using Globalmantics.Logic.Queries;
using Highway.Data;

namespace Globalmantics.Logic
{
    public class UserService
    {
        private IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public User GetUserByEmail(string emailAdderss)
        {
            var user = _repository.Find(new UserByEmail(emailAdderss));
            if(user == null)
            {
                user = _repository.Context.Add(User.Create(emailAdderss));
            }

            return user;
        }

        public User CreateUser(string emailAddress)
        {
            return _repository.Context.Add(User.Create(emailAddress));
        }
    }
}