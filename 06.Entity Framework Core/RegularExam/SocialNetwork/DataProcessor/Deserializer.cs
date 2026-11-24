using Newtonsoft.Json;
using ProductShop.Utilities;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            const string xmlRootName = "Messages";
            StringBuilder output = new StringBuilder();

            ICollection<Message> messagesToImport = new List<Message>();

            IEnumerable<ImportMessagesDto>? messagesDtos =
                XmlSerializerWrapper.Deserialize<ImportMessagesDto[]>(xmlString, xmlRootName);
            if (messagesDtos != null)
            {
                foreach (var messageDto in messagesDtos)
                {
                    if(!IsValid(messageDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (messageDto.Content.Length < 1 || messageDto.Content.Length > 200)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSentAtValid = DateTime
                        .TryParseExact(messageDto.SentAt,"yyyy-MM-ddTHH:mm:ss",CultureInfo.InvariantCulture,
                         DateTimeStyles.None,out DateTime sentAt);
                    bool isMesssageStatusValid = Enum
                        .TryParse<MessageStatus>(messageDto.Status, out MessageStatus messageStatus);
                    if (!isSentAtValid || !isMesssageStatusValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    bool conversationExists = dbContext.Conversations
                        .Any(c => c.Id == messageDto.ConversationId);
                    bool userExists = dbContext.Users
                        .Any(u => u.Id == messageDto.SenderId);
                    if (!conversationExists || !userExists)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    bool isDuplicateInDb = dbContext
                        .Messages.Any(m =>
                        m.Content == messageDto.Content &&
                        m.SentAt == sentAt &&
                        m.Status == messageStatus &&
                        m.SenderId == messageDto.SenderId &&
                        m.ConversationId == messageDto.ConversationId);

                   
                    bool isDuplicateInBatch = messagesToImport
                        .Any(m =>
                        m.Content == messageDto.Content &&
                        m.SentAt == sentAt &&
                        m.Status == messageStatus &&
                        m.SenderId == messageDto.SenderId &&
                        m.ConversationId == messageDto.ConversationId);

                    if (isDuplicateInDb || isDuplicateInBatch)
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    
                    Message message = new Message
                    {
                        Content = messageDto.Content,
                        SentAt = sentAt,
                        Status = messageStatus,
                        ConversationId = messageDto.ConversationId,
                        SenderId = messageDto.SenderId
                    };

                    messagesToImport.Add(message);
                    output.AppendLine(string.Format(SuccessfullyImportedMessageEntity, 
                        sentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                        messageStatus));
                }
            }

            dbContext.Messages.AddRange(messagesToImport);
            dbContext.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Post> postsToImport = new List<Post>();

            IEnumerable<ImportPostsDto>? postsDtos = JsonConvert
                .DeserializeObject<ImportPostsDto[]>(jsonString);
            if(postsDtos != null)
            {
                foreach (var postDto in postsDtos)
                {
                    if (!IsValid(postDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (postDto.Content.Length < 5 || postDto.Content.Length > 300)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedAtValid = DateTime
                        .TryParseExact(postDto.CreatedAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out DateTime createdAt);
                    bool isCreatorIdValid = int
                        .TryParse(postDto.CreatorId, out int creatorId);
                    
                    if (!isCreatedAtValid || !isCreatorIdValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    User? creator = dbContext
                        .Users
                        .FirstOrDefault(u => u.Id == creatorId);
                    
                    if (creator == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicateInDb = dbContext
                        .Posts
                        .Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAt &&
                        p.CreatorId == creatorId);

                    bool isDuplicateInBatch = postsToImport
                        .Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAt &&
                        p.CreatorId == creatorId);

                    if (isDuplicateInDb || isDuplicateInBatch)
                    {
                        output.AppendLine(DuplicatedDataMessage);
                        continue;
                    }
                    
                    Post post = new Post
                    {
                        Content = postDto.Content,
                        CreatedAt = createdAt,
                        CreatorId = creatorId
                    };

                    postsToImport.Add(post);
                    output.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username,
                        createdAt.ToString("yyyy-MM-ddTHH:mm:ss")));
                }

                dbContext.Posts.AddRange(postsToImport);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
