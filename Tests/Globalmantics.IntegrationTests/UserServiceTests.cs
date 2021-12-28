﻿using FluentAssertions;
using Globalmantics.DAL;
using Globalmantics.Domain;
using Globalmantics.Logic;
using Highway.Data;
using NUnit.Framework;
using System;

namespace Globalmantics.IntegrationTests
{
    [Isolated]
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void CanCreateUser()
        {
            var services = UserServiceContext.GivenServices();

            User user = services.WhenGetUserByEmail();

            user.UserId.Should().NotBe(0);
            user.Email.Should().Be(services.EmailAddress);
        }
    }
}
