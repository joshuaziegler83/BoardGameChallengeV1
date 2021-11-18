using BoardGameChallengeV1.Models;
using System;
using System.Collections.Generic;

namespace BoardGameChallengeV1.Services
{
    public interface IFriendRequestService
    {
        bool CreateFriendRequest(FriendRequestCreate model);
        bool DeleteFriendRequest(int FriendRequestId);
        FriendRequestDetail GetFriendRequestByFriendRequestId(int friendRequestId);
        IEnumerable<FriendRequestList> GetFriendRequestsByUserId(Guid userId1);
        bool UpdateFriendRequest(FriendRequestEdit model);
    }
}