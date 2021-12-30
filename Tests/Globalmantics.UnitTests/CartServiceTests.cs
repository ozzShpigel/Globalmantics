using FluentAssertions;
using Globalmantics.Domain;
using Globalmantics.Logic;
using Highway.Data;
using Highway.Data.Contexts;
using NUnit.Framework;
using System.Linq;

namespace Globalmantics.UnitTests
{

    [TestFixture]
    public class CartServiceTests
    {
        [Test]
        public void CartIsInitiallyEmpty()
        {
            var context = new InMemoryDataContext();

            var repository = new Repository(context);
            var userService = new UserService(repository);
            var cartService = new CartService(repository);

            var user = userService.GetUserByEmail("test@globalmantics.com");
            context.Commit();
            var cart = cartService.GetCartForUser(user);
            context.Commit();

            cart.CartItems.Count().Should().Be(1);
        }

        [Test]
        public void CanLoadCartWithOneItem()
        {
            var context = new InMemoryDataContext();
            InitializeCartWithOneItem(context);

            var repository = new Repository(context);
            var userService = new UserService(repository);
            var cartService = new CartService(repository);

            var user = userService.GetUserByEmail("test@globalmantics.com");
            context.Commit();
            var cart = cartService.GetCartForUser(user);
            context.Commit();

            cart.CartItems.Count().Should().Be(1);
        }

        private void InitializeCartWithOneItem(InMemoryDataContext context)
        {
            var user = context.Add(User.Create("test@globalmantics.com"));
            context.Commit();
            var cart = context.Add(Cart.Create(user));
            var catalogItem = context.Add(CatalogItem.Create
            (
                sku: "CAFE-314",
                description: "1 pound guatemalan coffee beans",
                unitPrice: 18.80m
            ));

            cart.AddItem(catalogItem, 2);
            context.Commit();
        }
    }
}
