namespace LANBingoBE.Infrastructure;

public interface IUserService
{
    bool IsUserAllowed(string user);
    void CreateUserBingo(int userId);
}
