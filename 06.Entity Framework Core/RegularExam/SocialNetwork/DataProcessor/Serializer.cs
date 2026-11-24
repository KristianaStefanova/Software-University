using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Utilities;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using System.Globalization;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            ExportUsersDto exportDto = new ExportUsersDto
            {
                Users = dbContext.Users
                    .AsNoTracking()
                    .Include(u => u.Posts)
                    .OrderBy(u => u.Username)
                    .Select(u => new ExportUserWithPostsDto
                    {
                        Username = u.Username,
                        Friendships = dbContext.Friendships
                            .Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                        Posts = u.Posts
                            .OrderBy(p => p.Id)
                            .Select(p => new ExportPostDto
                            {
                                Content = p.Content,
                                CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss",
                                CultureInfo.InvariantCulture)
                            })
                            .ToArray()
                    })
                    .ToArray()
            };

            string xml = XmlSerializerWrapper.Serialize(exportDto, "Users");
            return xml;
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversations = dbContext.Conversations
                .AsNoTracking()
                .OrderBy(c => c.StartedAt)
                .Select(c => new ExportConversationWithMessagesDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new ExportMessageDto
                        {
                            Content = m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                            Status = (int)m.Status,
                            SenderUsername = m.Sender.Username
                        })
                        .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(conversations, Formatting.Indented);
            return json;
        }
    }
}
