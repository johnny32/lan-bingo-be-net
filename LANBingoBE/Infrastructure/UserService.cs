using System.Text;
using Microsoft.Data.Sqlite;

namespace LANBingoBE.Infrastructure;

public class UserService : IUserService
{
    private readonly Configuration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration.Get<Configuration>();
    }

    public bool IsUserAllowed(string user)
    {
        using SqliteConnection connection = new(_configuration.ConnectionString);
        connection.Open();

        StringBuilder query = new();
        query.Append(" SELECT 1 FROM Users WHERE description = @user ");

        using SqliteCommand command = new(query.ToString(), connection);
        command.Parameters.AddWithValue("user", user);

        using SqliteDataReader reader = command.ExecuteReader();
        bool isUserAllowed = reader.HasRows;

        connection.Close();
        return isUserAllowed;
    }
}
