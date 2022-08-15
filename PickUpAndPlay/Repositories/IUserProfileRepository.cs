using PickUpAndPlay.Models;
using System.Collections.Generic;

namespace PickUpAndPlay.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        List<UserProfile> GetAllUsers();
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetByUserId(int id);
    }
}