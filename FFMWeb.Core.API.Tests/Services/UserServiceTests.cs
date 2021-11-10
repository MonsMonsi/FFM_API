using AutoFixture;
using FFMWeb.Core.API.Config;
using FFMWeb.Core.API.Exceptions;
using FFMWeb.Core.API.Models.Create;
using FFMWeb.Core.API.Services;
using FFMWebCore.Data.Tests;
using FFMWebCore.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FFMWeb.Core.API.Tests.Services
{
    public class UserServiceTests : FootballContextFixture, IDisposable
    {
        private UserService _service = new(DataTestUtils.CreateFootballContext(), new Mock<IHttpContextAccessor>().Object, AutoMapperConfig.ConfigureAutoMapper());

        [Fact]
        public async Task TestCreateUserAsync()
        {
            var fixture = new Fixture();
            var model = fixture.Create<CreateUserModel>();

            var result = await _service.CreateUserAsync(model);

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                var fromDb = await context.Users.FindAsync(result.Id);

                fromDb.EMail.Should().Be(model.Email);
                fromDb.Identifier.Should().Be(model.Identifier);
            };
        }

        [Fact]
        public async Task TestGetUserByIdAsync()
        {
            var user = new User
            {
                EMail = "alalalalalalalalalalal.sgsdg",
                Identifier = "Id0923059234"
            };

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            };

            var result = await _service.GetUserByIdAsync(user.Id);
            result.EMail.Should().Be(user.EMail);
            result.Identifier.Should().Be(user.Identifier);

            await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetUserByIdAsync(-1));
        }

        [Fact]
        public async Task TestGetUserByIdentifier()
        {
            var user = new User
            {
                EMail = "lalalalalal.sgsdg",
                Identifier = "Id092"
            };

            await using (var context = DataTestUtils.CreateFootballContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            };

            var result = await _service.GetUserByIdentifierAsync(user.Identifier);
            result.EMail.Should().Be(user.EMail);
            result.Identifier.Should().Be(user.Identifier);

            await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetUserByIdentifierAsync("lalala"));
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
