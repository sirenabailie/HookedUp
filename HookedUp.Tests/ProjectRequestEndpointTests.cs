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
    public class ProjectRequestEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProjectRequestEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostProjectRequest_CreatesAndReturnsEntity()
        {
            var newRequest = new
            {
                UserId = 1,
                Title = "Unit Test Project",
                Description = "Testing POST",
                ProjectType = "TestType",
                Location = "Testville",
                DueDate = DateTime.UtcNow.AddDays(3),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = (int?)null
            };

            var postResp = await _client.PostAsJsonAsync("/projectrequests", newRequest);
            postResp.EnsureSuccessStatusCode();

            var created = await postResp.Content.ReadFromJsonAsync<ProjectRequest>();
            created.Should().NotBeNull();

            created!.Id.Should().BeGreaterThan(0);
            created.Title.Should().Be(newRequest.Title);
            created.Description.Should().Be(newRequest.Description);
        }

        [Fact]
        public async Task GetProjectRequest_ReturnsById()
        {
            var newRequest = new
            {
                UserId = 1,
                Title = "Fetch Test",
                Description = "GetById",
                ProjectType = "X",
                Location = "L",
                DueDate = DateTime.UtcNow.AddDays(1),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = (int?)null
            };
            var post = await _client.PostAsJsonAsync("/projectrequests", newRequest);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ProjectRequest>();
            created.Should().NotBeNull();

            var getResp = await _client.GetAsync($"/projectrequests/{created!.Id}");
            getResp.EnsureSuccessStatusCode();
            var fetched = await getResp.Content.ReadFromJsonAsync<ProjectRequest>();
            fetched.Should().NotBeNull();

            fetched!.Id.Should().Be(created.Id);
            fetched.Title.Should().Be(newRequest.Title);
        }

        [Fact]
        public async Task PutProjectRequest_UpdatesEntity()
        {
            var newRequest = new
            {
                UserId = 1,
                Title = "Before Update",
                Description = "Old",
                ProjectType = "A",
                Location = "X",
                DueDate = DateTime.UtcNow.AddDays(2),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = (int?)null
            };
            var post = await _client.PostAsJsonAsync("/projectrequests", newRequest);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ProjectRequest>();
            created.Should().NotBeNull();

            var updated = new
            {
                Id = created!.Id,
                UserId = created.UserId,
                Title = "After Update",
                Description = "New",
                ProjectType = created.ProjectType,
                Location = created.Location,
                DueDate = created.DueDate.AddDays(1),
                Status = "Closed",
                Claimed = true,
                ClaimedByUserId = 2
            };

            var putResp = await _client.PutAsJsonAsync($"/projectrequests/{created.Id}", updated);
            putResp.EnsureSuccessStatusCode();

            var getResp = await _client.GetAsync($"/projectrequests/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var verify = await getResp.Content.ReadFromJsonAsync<ProjectRequest>();
            verify.Should().NotBeNull();

            verify!.Title.Should().Be("After Update");
            verify.Status.Should().Be("Closed");
            verify.Claimed.Should().BeTrue();
            verify.ClaimedByUserId.Should().Be(2);
        }

        [Fact]
        public async Task DeleteProjectRequest_RemovesEntity()
        {
            var newRequest = new
            {
                UserId = 1,
                Title = "To Delete",
                Description = "Will go",
                ProjectType = "D",
                Location = "Nowhere",
                DueDate = DateTime.UtcNow.AddDays(5),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = (int?)null
            };
            var post = await _client.PostAsJsonAsync("/projectrequests", newRequest);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ProjectRequest>();
            created.Should().NotBeNull();

            var delResp = await _client.DeleteAsync($"/projectrequests/{created!.Id}");
            delResp.EnsureSuccessStatusCode();

            var getAfter = await _client.GetAsync($"/projectrequests/{created.Id}");
            getAfter.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
