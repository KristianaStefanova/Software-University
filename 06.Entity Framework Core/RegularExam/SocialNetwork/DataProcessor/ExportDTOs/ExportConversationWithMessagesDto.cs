using Newtonsoft.Json;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    public class ExportConversationWithMessagesDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; } = null!;

        [JsonProperty("StartedAt")]
        public string StartedAt { get; set; } = null!;

        [JsonProperty("Messages")]
        public ExportMessageDto[] Messages { get; set; } = null!;
    }
}

