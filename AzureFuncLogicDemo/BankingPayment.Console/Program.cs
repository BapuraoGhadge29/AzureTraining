using System.Text;
using System.Text.Json;

var request = new
{
  CustomerName= "Bapurao Ghadge",
  Email= "bapuraoghadge@gmail.com",
  FromAccount= "123456789",
  ToAccount= "987654321",
  Amount= 6000,
  TransactionDate= DateTime.UtcNow
};

string functionUrl ="https://bankingpaymentfunction-dne0gxh6ffc5bkhk.southeastasia-01.azurewebsites.net/api/PaymentTransfer?code=80LJjAZAGnRZwaNA8jgPJN71gYIY453azba3YR6MJReKAzFuNY7OhA==";
string json = JsonSerializer.Serialize(request);
Console.WriteLine(json);
using HttpClient client = new HttpClient();
var response =await client.PostAsync(functionUrl,new StringContent(json,Encoding.UTF8,"application/json"));
Console.WriteLine(await response.Content.ReadAsStringAsync());