
using System.ComponentModel.DataAnnotations;
using static Horizons.GCommon.ValidationConstatnts.Destination;

namespace Horizons.Web.ViewModels.Destination
{
    public class AddDestinationInputModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int TerrainId { get; set; }

        [Required]
        [MinLength(PublishedOnLength)]
        [MaxLength(PublishedOnLength)]
        public string PublishedOn { get; set; } = null!;

        public IEnumerable<AddDestinationTerrainDropDownModel>? Terrains { get; set; }
    }
}
