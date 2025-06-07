using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using HookedUp.Models;
using Xunit;

namespace HookedUp.Tests
{
    public class UserEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public UserEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostUser_CreatesAndReturnsEntity()
        {
            var newUser = new
            {
                Name = "Alice Test",
                Email = "alice@example.com",
                Password = "SuperSecret123",
                Role = "Member",
                ProfilePicture = "http://example.com/alice.jpg"
            };

            var postResp = await _client.PostAsJsonAsync("/users", newUser);
            postResp.EnsureSuccessStatusCode();

            var created = await postResp.Content.ReadFromJsonAsync<User>();
            created.Should().NotBeNull();
            created!.Id.Should().BeGreaterThan(0);
            created.Name.Should().Be(newUser.Name);
            created.Email.Should().Be(newUser.Email);
            created.Role.Should().Be(newUser.Role);
        }

        [Fact]
        public async Task GetUser_ReturnsById()
        {
            // create a user first
            var newUser = new
            {
                Name = "Bob Fetch",
                Email = "bob@example.com",
                Password = "FetchPass",
                Role = "Admin",
                ProfilePicture = "http://example.com/bob.jpg"
            };
            var post = await _client.PostAsJsonAsync("/users", newUser);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<User>();
            created.Should().NotBeNull();

            // fetch it
            var getResp = await _client.GetAsync($"/users/{created!.Id}");
            getResp.EnsureSuccessStatusCode();
            var fetched = await getResp.Content.ReadFromJsonAsync<User>();
            fetched.Should().NotBeNull();

            fetched!.Id.Should().Be(created.Id);
            fetched.Email.Should().Be(newUser.Email);
        }

        [Fact]
        public async Task PutUser_UpdatesEntity()
        {
            // create
            var newUser = new
            {
                Name = "Carol Before",
                Email = "carol@before.com",
                Password = "OldPass",
                Role = "Member",
                ProfilePicture = "http://example.com/carol_old.jpg"
            };
            var post = await _client.PostAsJsonAsync("/users", newUser);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<User>();
            created.Should().NotBeNull();

            // update
            var updated = new
            {
                Id = created!.Id,
                Name = "Carol After",
                Email = "carol@after.com",
                Password = "NewPass",
                Role = "Member",
                ProfilePicture = "http://example.com/carol_new.jpg"
            };
            var putResp = await _client.PutAsJsonAsync($"/users/{created.Id}", updated);
            putResp.EnsureSuccessStatusCode();

            // verify
            var getResp = await _client.GetAsync($"/users/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var verify = await getResp.Content.ReadFromJsonAsync<User>();
            verify.Should().NotBeNull();

            verify!.Name.Should().Be("Carol After");
            verify.Email.Should().Be("carol@after.com");
        }

        [Fact]
        public async Task DeleteUser_RemovesEntity()
        {
            // create
            var newUser = new
            {
                Name = "Dave Delete",
                Email = "dave@example.com",
                Password = "DelPass",
                Role = "Member",
                ProfilePicture = "http://example.com/dave.jpg"
            };
            var post = await _client.PostAsJsonAsync("/users", newUser);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<User>();
            created.Should().NotBeNull();

            // delete
            var delResp = await _client.DeleteAsync($"/users/{created!.Id}");
            delResp.EnsureSuccessStatusCode();

            // confirm gone
            var getAfter = await _client.GetAsync($"/users/{created.Id}");
            getAfter.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
