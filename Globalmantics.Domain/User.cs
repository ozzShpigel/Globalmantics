using Highway.Data;

namespace Globalmantics.Domain
{
    public class User : IIdentifiable<int>
    {
        int IIdentifiable<int>.Id
        {
            get { return UserId; }
            set { UserId = value; }
        }

        private User()
        {
        }

        public int UserId { get; set; }
        public string Email { get;  set; }
        public static User Create(string email)
        {
            return new User
            {
                Email = email
            };
        }
    }
}
