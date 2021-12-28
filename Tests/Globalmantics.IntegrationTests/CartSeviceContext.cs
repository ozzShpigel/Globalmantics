using Globalmantics.Domain;
using Globalmantics.Logic;

namespace Globalmantics.IntegrationTests
{
    internal class CartSeviceContext : UserServiceContext
    {
        protected CartSeviceContext()
        {
            CartService = new CartService(Repository);
        }

        public CartService CartService { get; }

        public Cart WhenLoadCart()
        {
            var user = UserService.GetUserByEmail(EmailAddress);
            Context.SaveChanges();

            var cart = CartService.GetCartForUser(user);
            Context.SaveChanges();
            return cart;
        }

        public void WhemAddItemToCart(Cart cart, int quantity = 1)
        {
            CartService.AddItemToCart(cart, "CAFE-314", quantity);
            Context.SaveChanges();
        }

        public static new CartSeviceContext GivenServices()
        {
            return new CartSeviceContext();
        }
    }
}