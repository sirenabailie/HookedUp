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
    public class ArtistProfileEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ArtistProfileEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostArtistProfile_CreatesAndReturnsEntity()
        {
            var newProfile = new
            {
                UserId = 1,
                Specialization = "Painter",
                ProfilePicture = "http://example.com/profile.jpg",
                ExpertiseLevel = "Expert",
                WorkImages = new[] { "http://example.com/work1.jpg", "http://example.com/work2.jpg" },
                WorkDescription = "Landscapes and portraits"
            };

            var postResp = await _client.PostAsJsonAsync("/artistprofiles", newProfile);
            postResp.EnsureSuccessStatusCode();

            var created = await postResp.Content.ReadFromJsonAsync<ArtistProfile>();
            created.Should().NotBeNull();

            created!.Id.Should().BeGreaterThan(0);
            created.UserId.Should().Be(newProfile.UserId);
            created.Specialization.Should().Be(newProfile.Specialization);
            created.ExpertiseLevel.Should().Be(newProfile.ExpertiseLevel);
            created.WorkImages.Should().BeEquivalentTo(newProfile.WorkImages);
        }

        [Fact]
        public async Task GetArtistProfile_ReturnsById()
        {
            var newProfile = new
            {
                UserId = 1,
                Specialization = "Sculptor",
                ProfilePicture = "http://example.com/sculpt.jpg",
                ExpertiseLevel = "Intermediate",
                WorkImages = new[] { "http://example.com/sculpt1.jpg" },
                WorkDescription = "Abstract sculptures"
            };
            var post = await _client.PostAsJsonAsync("/artistprofiles", newProfile);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ArtistProfile>();
            created.Should().NotBeNull();

            var getResp = await _client.GetAsync($"/artistprofiles/{created!.Id}");
            getResp.EnsureSuccessStatusCode();
            var fetched = await getResp.Content.ReadFromJsonAsync<ArtistProfile>();
            fetched.Should().NotBeNull();

            fetched!.Id.Should().Be(created.Id);
            fetched.Specialization.Should().Be(newProfile.Specialization);
        }

        [Fact]
        public async Task PutArtistProfile_UpdatesEntity()
        {
            var newProfile = new
            {
                UserId = 1,
                Specialization = "Illustrator",
                ProfilePicture = "http://example.com/illust.jpg",
                ExpertiseLevel = "Beginner",
                WorkImages = new[] { "http://example.com/illust1.jpg" },
                WorkDescription = "Digital art"
            };
            var post = await _client.PostAsJsonAsync("/artistprofiles", newProfile);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ArtistProfile>();
            created.Should().NotBeNull();

            var updated = new
            {
                Id = created!.Id,
                UserId = created.UserId,
                Specialization = "Graphic Designer",
                ProfilePicture = created.ProfilePicture,
                ExpertiseLevel = "Professional",
                WorkImages = created.WorkImages,
                WorkDescription = "Branding and logos"
            };

            var putResp = await _client.PutAsJsonAsync($"/artistprofiles/{created.Id}", updated);
            putResp.EnsureSuccessStatusCode();

            var getResp = await _client.GetAsync($"/artistprofiles/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var verify = await getResp.Content.ReadFromJsonAsync<ArtistProfile>();
            verify.Should().NotBeNull();

            verify!.Specialization.Should().Be("Graphic Designer");
            verify.ExpertiseLevel.Should().Be("Professional");
            verify.WorkDescription.Should().Be("Branding and logos");
        }

        [Fact]
        public async Task DeleteArtistProfile_RemovesEntity()
        {
            var newProfile = new
            {
                UserId = 1,
                Specialization = "Photographer",
                ProfilePicture = "http://example.com/photo.jpg",
                ExpertiseLevel = "Advanced",
                WorkImages = new[] { "http://example.com/photo1.jpg" },
                WorkDescription = "Event photography"
            };
            var post = await _client.PostAsJsonAsync("/artistprofiles", newProfile);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ArtistProfile>();
            created.Should().NotBeNull();

            var delResp = await _client.DeleteAsync($"/artistprofiles/{created!.Id}");
            delResp.EnsureSuccessStatusCode();

            var getAfter = await _client.GetAsync($"/artistprofiles/{created.Id}");
            getAfter.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
