using Newtonsoft.Json;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    public class ExportMessageDto
    {
        [JsonProperty("Content")]
        public string Content { get; set; } = null!;

        [JsonProperty("SentAt")]
        public string SentAt { get; set; } = null!;

        [JsonProperty("Status")]
        public int Status { get; set; } 

        [JsonProperty("SenderUsername")]
        public string SenderUsername { get; set; } = null!;
    }
}

