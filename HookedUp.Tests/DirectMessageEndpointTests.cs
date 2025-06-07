using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using HookedUp.DTOs;
using Xunit;

namespace HookedUp.Tests
{
    public class DirectMessageEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public DirectMessageEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostDirectMessage_CreatesAndReturnsDto()
        {
            var newMsg = new
            {
                SenderId         = 1,
                ReceiverId       = 2,
                ProjectRequestId = 3,
                MessageText      = "Hello there!"
            };

            var post = await _client.PostAsJsonAsync("/directmessages", newMsg);
            post.StatusCode.Should().Be(HttpStatusCode.Created);

            var created = await post.Content.ReadFromJsonAsync<DirectMessageDto>();
            created.Should().NotBeNull();
            created!.Id.Should().BeGreaterThan(0);
            created.SenderId.Should().Be(newMsg.SenderId);
            created.ReceiverId.Should().Be(newMsg.ReceiverId);
            created.ProjectRequestId.Should().Be(newMsg.ProjectRequestId);
            created.MessageText.Should().Be(newMsg.MessageText);
            created.Timestamp.Should().BeBefore(DateTime.UtcNow.AddSeconds(1));
        }

        [Fact]
        public async Task GetAllDirectMessages_ReturnsList()
        {
            // ensure at least one exists
            var msg = new { SenderId = 10, ReceiverId = 20, ProjectRequestId = 30, MessageText = "List test" };
            await _client.PostAsJsonAsync("/directmessages", msg);

            var get = await _client.GetAsync("/directmessages");
            get.EnsureSuccessStatusCode();

            // if there was none before, API returns string; but after one POST it should return DTO list
            var dtos = await get.Content.ReadFromJsonAsync<List<DirectMessageDto>>();
            dtos.Should().NotBeNull();
            dtos!.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetById_ReturnsDto()
        {
            var msg = new { SenderId = 5, ReceiverId = 6, ProjectRequestId = 7, MessageText = "ById test" };
            var post = await _client.PostAsJsonAsync("/directmessages", msg);
            var created = await post.Content.ReadFromJsonAsync<DirectMessageDto>();
            created.Should().NotBeNull();

            var get = await _client.GetAsync($"/directmessages/{created!.Id}");
            get.EnsureSuccessStatusCode();

            var dto = await get.Content.ReadFromJsonAsync<DirectMessageDto>();
            dto.Should().NotBeNull();
            dto!.Id.Should().Be(created.Id);
            dto.MessageText.Should().Be(msg.MessageText);
        }

        [Fact]
        public async Task GetBySender_ReturnsDtos()
        {
            var senderId = 11;
            var msg1 = new { SenderId = senderId, ReceiverId = 12, ProjectRequestId = 13, MessageText = "Sender test" };
            await _client.PostAsJsonAsync("/directmessages", msg1);

            var get = await _client.GetAsync($"/directmessages/sender/{senderId}");
            get.EnsureSuccessStatusCode();

            var dtos = await get.Content.ReadFromJsonAsync<List<DirectMessageDto>>();
            dtos.Should().NotBeNull();
            dtos!.Should().Contain(x => x.SenderId == senderId && x.MessageText == msg1.MessageText);
        }

        [Fact]
        public async Task GetByReceiver_ReturnsDtos()
        {
            var receiverId = 21;
            var msg1 = new { SenderId = 22, ReceiverId = receiverId, ProjectRequestId = 23, MessageText = "Receiver test" };
            await _client.PostAsJsonAsync("/directmessages", msg1);

            var get = await _client.GetAsync($"/directmessages/receiver/{receiverId}");
            get.EnsureSuccessStatusCode();

            var dtos = await get.Content.ReadFromJsonAsync<List<DirectMessageDto>>();
            dtos.Should().NotBeNull();
            dtos!.Should().Contain(x => x.ReceiverId == receiverId && x.MessageText == msg1.MessageText);
        }

        [Fact]
        public async Task PutDirectMessage_UpdatesMessageTextAndTimestamp()
        {
            var msg = new { SenderId = 31, ReceiverId = 32, ProjectRequestId = 33, MessageText = "Before update" };
            var post = await _client.PostAsJsonAsync("/directmessages", msg);
            var created = await post.Content.ReadFromJsonAsync<DirectMessageDto>();
            created.Should().NotBeNull();

            var originalTimestamp = created!.Timestamp;

            var updated = new
            {
                Id               = created.Id,
                SenderId         = created.SenderId,
                ReceiverId       = created.ReceiverId,
                ProjectRequestId = created.ProjectRequestId,
                MessageText      = "After update"
            };

            var put = await _client.PutAsJsonAsync($"/directmessages/{created.Id}", updated);
            put.EnsureSuccessStatusCode();

            var dto = await put.Content.ReadFromJsonAsync<DirectMessageDto>();
            dto.Should().NotBeNull();
            dto!.MessageText.Should().Be(updated.MessageText);
            dto.Timestamp.Should().BeAfter(originalTimestamp);
        }

        [Fact]
        public async Task DeleteDirectMessage_RemovesIt()
        {
            var msg = new { SenderId = 41, ReceiverId = 42, ProjectRequestId = 43, MessageText = "To be deleted" };
            var post = await _client.PostAsJsonAsync("/directmessages", msg);
            var created = await post.Content.ReadFromJsonAsync<DirectMessageDto>();
            created.Should().NotBeNull();

            var del = await _client.DeleteAsync($"/directmessages/{created!.Id}");
            del.EnsureSuccessStatusCode();

            var getAfter = await _client.GetAsync($"/directmessages/{created.Id}");
            getAfter.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
