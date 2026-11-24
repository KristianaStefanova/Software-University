using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class Friendship
    {
        [ForeignKey(nameof(UserOne))]
        [InverseProperty(nameof(User.FriendshipsRequested))]
        public int UserOneId { get; set; }

        public virtual User UserOne { get; set; } = null!;

        [ForeignKey(nameof(UserTwo))]
        [InverseProperty(nameof(User.FriendshipsReceived))]
        public int UserTwoId { get; set; } 

        public virtual User UserTwo { get; set; } = null!;


    }
}
