

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostsDto
    {
        [Required]
        [JsonProperty("Content")]
        public string Content { get; set; } = null!;

        [Required]
        [JsonProperty("CreatedAt")]
        public string CreatedAt { get; set; } = null!;

        [Required]
        [JsonProperty("CreatorId")]
        public string CreatorId { get; set; } = null!;
    }
}
