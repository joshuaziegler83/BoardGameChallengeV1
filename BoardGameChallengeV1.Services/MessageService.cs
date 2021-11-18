using BoardGameChallengeV1.Data;
using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Services
{
    public class MessageService
    {
        private readonly Guid _ownerId;

        public MessageService(Guid ownerId)
        {
            _ownerId = ownerId;
        }


        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    MessageId = model.MessageId,
                    UserId1 = model.UserId1,
                    UserId2 = model.UserId2,
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MessageList> GetAllMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Select(
                            e =>
                                new MessageList
                                {
                                    MessageId = e.MessageId,
                                    UserId1 = e.UserId1,
                                    UserId2 = e.UserId2,
                                    Content = e.Content
                                }
                                );
                return query.ToArray();
            }
        }

        public MessageDetail GetMessageByMessageId(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single((e => e.MessageId == messageId));
                return new MessageDetail
                {
                    MessageId = entity.MessageId,
                    UserId1 = entity.UserId1,
                    UserId2 = entity.UserId2,
                    Content = entity.Content
                };
            }
        }

        public IEnumerable<MessageList> GetMessagesByUserId(Guid userId1)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.UserId1 == _ownerId.ToString())
                        .Select(
                            e =>
                                new MessageList
                                {
                                    MessageId = e.MessageId,
                                    UserId1 = e.UserId1,
                                    UserId2 = e.UserId2,
                                    Content = e.Content
                                }
                                );
                return query.ToArray();
            }
        }
        public IEnumerable<MessageList> GetMessagesFromUser1ToUser2(Guid userId1, Guid userId2)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.UserId1 == _ownerId.ToString() && e.UserId2 == userId2.ToString())
                        .Select(
                            e =>
                                new MessageList
                                {
                                    MessageId = e.MessageId,
                                    UserId1 = e.UserId1,
                                    UserId2 = e.UserId2,
                                    Content = e.Content
                                }
                                );
                return query.ToArray();
            }
        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                       .Messages
                       .Single(e => e.MessageId == model.MessageId);
                entity.MessageId = model.MessageId;
                entity.UserId1 = model.UserId1;
                entity.UserId2 = model.UserId2;
                entity.Content = model.Content;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int MessageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == MessageId);
                ctx.Messages.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
