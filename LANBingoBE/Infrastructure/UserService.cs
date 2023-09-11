using System.Text;
using LANBingoBE.Extensions;
using Microsoft.Data.Sqlite;

namespace LANBingoBE.Infrastructure;

public class UserService : IUserService
{
    private readonly Configuration _configuration;
    private const int BINGO_SIZE = 25;

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

    public void CreateUserBingo(int userId)
    {
        using SqliteConnection connection = new(_configuration.ConnectionString);
        connection.Open();

        StringBuilder query = new();
        query.Append(" SELECT COUNT(1) FROM Cards ");

        using SqliteCommand command = new(query.ToString(), connection);
        int totalCards = Convert.ToInt32(command.ExecuteScalar()); // For some reason, COUNT returns a long instead of an int, although its value is well below int's max value.

        List<int> listCards = Enumerable.Range(1, totalCards).ToList();
        listCards.Shuffle();
        listCards = listCards.Take(BINGO_SIZE).Order().ToList();

        query.Clear();
        query.AppendLine(" INSERT INTO Bingo (user_id, card_id) VALUES ");
        for (int cardCount = 1; cardCount < listCards.Count; cardCount++)
        {
            query.AppendLine($"(@userId, @cardId{cardCount}), ");
        }
        query.AppendLine($"(@userId, @cardId{listCards.Count}) ");

        command.Dispose();
        using SqliteCommand insertCommand = new(query.ToString(), connection);
        int i = 1;
        foreach (int cardId in listCards)
        {
            insertCommand.Parameters.AddWithValue($"cardId{i}", cardId);
            i++;
        }
        insertCommand.Parameters.AddWithValue("userId", userId);

        insertCommand.ExecuteNonQuery();
    }
}
