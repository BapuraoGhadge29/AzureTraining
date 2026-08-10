using System.Text.Json;
using DemoRedis.Models;
using Microsoft.Data.SqlClient;
using StackExchange.Redis;


string dbCon = "Server=tcp:bgzenserver.database.windows.net,1433;Initial Catalog=bgzendemodb;Persist Security Info=False;User ID=bgadmin;Password=Pass@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

string redCon = "bgzenredis.southeastasia.redis.azure.net:10000,password=PeMpkpz_U8tjXGLxCCoDjR_gIb4-W77ajAZCAOHK3u8=,ssl=True";

ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(redCon);

IDatabase cache = redis.GetDatabase();
static async Task<AccountSummary?> GetAccountSummaryAsync(
    int accountId,
    IDatabase cache,
    string sqlConnectionString)
{
    string cacheKey = $"account:{accountId}";

    Console.WriteLine("Checking Redis Cache...");

    string? cachedData = await cache.StringGetAsync(cacheKey);

    if (!string.IsNullOrEmpty(cachedData))
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("Cache HIT");

        Console.ResetColor();

        return JsonSerializer.Deserialize<AccountSummary>(cachedData);
    }

    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("Cache MISS");

    Console.ResetColor();

    AccountSummary account = null!;

    using SqlConnection connection =
        new SqlConnection(sqlConnectionString);

    await connection.OpenAsync();

    string query = @"
        SELECT *
        FROM Accounts
        WHERE AccountId = @AccountId";

    SqlCommand command =
        new SqlCommand(query, connection);

    command.Parameters.AddWithValue("@AccountId", accountId);

    SqlDataReader reader =
        await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        account = new AccountSummary
        {
            AccountId = Convert.ToInt32(reader["AccountId"]),
            CustomerName = reader["CustomerName"].ToString()!,
            Balance = Convert.ToDecimal(reader["Balance"]),
            AvailableBalance = Convert.ToDecimal(reader["AvailableBalance"]),
            RewardPoints = Convert.ToInt32(reader["RewardPoints"]),
            AccountStatus = reader["AccountStatus"].ToString()!
        };

        await cache.StringSetAsync(
            cacheKey,
            JsonSerializer.Serialize(account),
            TimeSpan.FromMinutes(10));

        Console.WriteLine("Data stored in Redis");
    }

    return account;
}
static void DisplayAccount(AccountSummary account)
{
    Console.WriteLine();
    Console.WriteLine("----- Account Summary -----");
    Console.WriteLine($"Account Id       : {account.AccountId}");
    Console.WriteLine($"Customer Name    : {account.CustomerName}");
    Console.WriteLine($"Balance          : {account.Balance:C}");
    Console.WriteLine($"Available Balance: {account.AvailableBalance:C}");
    Console.WriteLine($"Reward Points    : {account.RewardPoints}");
    Console.WriteLine($"Status           : {account.AccountStatus}");
}
AccountSummary account =
    await GetAccountSummaryAsync(
        10001,
        cache,
        dbCon);

//await TransferMoneyAsync(1000, 10000, cache, dbCon);

if (account != null)
{
    DisplayAccount(account);
}

static async Task TransferMoneyAsync(

    int accountId,

    decimal amount,

    IDatabase cache,

    string sqlConnectionString)

{

    using SqlConnection connection =

        new SqlConnection(sqlConnectionString);

    await connection.OpenAsync();

    string updateQuery = @"

            UPDATE Accounts

            SET Balance = Balance - @Amount,

                AvailableBalance = AvailableBalance - @Amount

            WHERE AccountId = @AccountId";


    SqlCommand cmd = new SqlCommand(updateQuery, connection);

    cmd.Parameters.AddWithValue("@Amount", amount);

    cmd.Parameters.AddWithValue("@AccountId", accountId);

    await cmd.ExecuteNonQueryAsync();

    await cache.KeyDeleteAsync($"account:{accountId}");

    Console.WriteLine("Cache Invalidated");
}