using FluentAssertions;
using Globalmantics.DAL;
using Globalmantics.Domain;
using Globalmantics.Logic;
using Highway.Data;
using NUnit.Framework;
using System;
using System.Linq;

namespace Globalmantics.IntegrationTests
{
    [Isolated]
    [TestFixture]
    public class CartSeviceTests
    {
        [Test]
        public void CartIsInitiallyEmpty()
        {
            var services = CartSeviceContext.GivenServices();

            var cart = services.WhenLoadCart();
                
            cart.CartItems.Count().Should().Be(0);
        }

        [Test]
        public void CanAddItemToCart()
        {
            var services = CartSeviceContext.GivenServices();

            var cart = services.WhenLoadCart();

            services.WhemAddItemToCart(cart);

            cart.CartItems.Count().Should().Be(1);
        }

        [Test]
        public void CanLoadCartWithOneItem()
        {
            var services = CartSeviceContext.GivenServices();
            InitializeCartWithOneItem(services.EmailAddress);
            
            var cart = services.WhenLoadCart();

            cart.CartItems.Count().Should().Be(1);
            cart.CartItems.Single().Quantity.Should().Be(2);
        }

        [Test]
        public void GroupItemsOfSameKind()
        {
            var services = CartSeviceContext.GivenServices();

            var cart = services.WhenLoadCart();

            services.WhemAddItemToCart(cart, quantity: 2);
            services.WhemAddItemToCart(cart, quantity: 1);

            cart.CartItems.Count().Should().Be(1);
            cart.CartItems.Single().Quantity.Should().Be(3);
        }

        private void InitializeCartWithOneItem(string emailAddress)
        {
            var configuration = new GlobalmanticsMappingConfiguration();
            var context = new DataContext("GlobalmanticsContext", configuration);
            var user = context.Add(User.Create(emailAddress));
            context.Commit();
            var cart = context.Add(Cart.Create(user));
            var catalogItem = context.AsQueryable<CatalogItem>()
                .Single(x => x.Sku == "CAFE-314");
            cart.AddItem(catalogItem, 2);
            context.Commit();
        }
    }
}
