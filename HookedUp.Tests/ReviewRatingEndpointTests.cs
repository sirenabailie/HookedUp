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
    public class ReviewRatingEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ReviewRatingEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostReviewRating_CreatesAndReturnsEntity()
        {
            var newRating = new
            {
                ProjectRequestId = 1,
                UserId           = 1,
                ArtistId         = 1,
                Rating           = 5,
                ReviewText       = "Excellent work!",
                ReviewImage      = new[] { "http://example.com/img1.jpg" }
            };

            var postResp = await _client.PostAsJsonAsync("/reviewratings", newRating);
            postResp.EnsureSuccessStatusCode();

            var created = await postResp.Content.ReadFromJsonAsync<ReviewRating>();
            created.Should().NotBeNull();
            created!.Id.Should().BeGreaterThan(0);
            created.ProjectRequestId.Should().Be(newRating.ProjectRequestId);
            created.Rating.Should().Be(newRating.Rating);
            created.ReviewText.Should().Be(newRating.ReviewText);
            created.ReviewImage.Should().Contain(newRating.ReviewImage[0]);
        }

        [Fact]
        public async Task GetReviewRating_ReturnsById()
        {
            // First create one
            var newRating = new
            {
                ProjectRequestId = 1,
                UserId           = 1,
                ArtistId         = 1,
                Rating           = 4,
                ReviewText       = "Good job",
                ReviewImage      = new[] { "http://example.com/img2.jpg" }
            };
            var post = await _client.PostAsJsonAsync("/reviewratings", newRating);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ReviewRating>();
            created.Should().NotBeNull();

            var getResp = await _client.GetAsync($"/reviewratings/{created!.Id}");
            getResp.EnsureSuccessStatusCode();
            var fetched = await getResp.Content.ReadFromJsonAsync<ReviewRating>();
            fetched.Should().NotBeNull();

            fetched!.Id.Should().Be(created.Id);
            fetched.ReviewText.Should().Be(newRating.ReviewText);
        }

        [Fact]
        public async Task PutReviewRating_UpdatesEntity()
        {
            // Create
            var newRating = new
            {
                ProjectRequestId = 1,
                UserId           = 1,
                ArtistId         = 1,
                Rating           = 3,
                ReviewText       = "Average",
                ReviewImage      = new[] { "http://example.com/img3.jpg" }
            };
            var post = await _client.PostAsJsonAsync("/reviewratings", newRating);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ReviewRating>();
            created.Should().NotBeNull();

            // Prepare update
            var updated = new
            {
                Id               = created!.Id,
                ProjectRequestId = created.ProjectRequestId,
                UserId           = created.UserId,
                ArtistId         = created.ArtistId,
                Rating           = 2,
                ReviewText       = "Needs improvement",
                ReviewImage      = new[] { "http://example.com/img4.jpg" }
            };

            var putResp = await _client.PutAsJsonAsync($"/reviewratings/{created.Id}", updated);
            putResp.EnsureSuccessStatusCode();

            var getResp = await _client.GetAsync($"/reviewratings/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var verify = await getResp.Content.ReadFromJsonAsync<ReviewRating>();
            verify.Should().NotBeNull();

            verify!.Rating.Should().Be(updated.Rating);
            verify.ReviewText.Should().Be(updated.ReviewText);
            verify.ReviewImage.Should().Contain(updated.ReviewImage[0]);
        }

        [Fact]
        public async Task DeleteReviewRating_RemovesEntity()
        {
            // Create
            var newRating = new
            {
                ProjectRequestId = 1,
                UserId           = 1,
                ArtistId         = 1,
                Rating           = 1,
                ReviewText       = "Poor",
                ReviewImage      = new[] { "http://example.com/img5.jpg" }
            };
            var post = await _client.PostAsJsonAsync("/reviewratings", newRating);
            post.EnsureSuccessStatusCode();
            var created = await post.Content.ReadFromJsonAsync<ReviewRating>();
            created.Should().NotBeNull();

            // Delete
            var delResp = await _client.DeleteAsync($"/reviewratings/{created!.Id}");
            delResp.EnsureSuccessStatusCode();

            // Verify removal
            var getAfter = await _client.GetAsync($"/reviewratings/{created.Id}");
            getAfter.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
