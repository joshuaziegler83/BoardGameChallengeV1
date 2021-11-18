using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;

namespace BoardGameChallengeV1.Services
{
    public interface IMessageService
    {
        bool CreateMessage(MessageCreate model);
        bool DeleteMessage(int MessageId);
        IEnumerable<MessageList> GetAllMessages();
        MessageDetail GetMessageByMessageId(int messageId);
        IEnumerable<MessageList> GetMessagesByUserId(Guid userId1);
        IEnumerable<MessageList> GetMessagesFromUser1ToUser2(Guid userId1, Guid userId2);
        bool UpdateMessage(MessageEdit model);
    }
}