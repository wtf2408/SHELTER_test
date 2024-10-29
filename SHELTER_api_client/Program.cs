using System.Net.Http.Json;
using System.Net.Http.Headers;

var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "shelter_test_task_2408");
System.Console.WriteLine(client.DefaultRequestHeaders.Authorization);
string apiUrl = "http://localhost:5198/api/companies/read";

while (true)
{
    try
    {
        var response = await client.PostAsync(apiUrl, null);
        if (response.IsSuccessStatusCode)
        {
            var companies = await response.Content.ReadFromJsonAsync<List<Company>>();
            var todayPhoneNumber = DateTime.Now.ToShortDateString();

            if (!companies.Any(c => c.Phone == todayPhoneNumber))
            {
                var newCompany = new Company
                {
                    Phone = todayPhoneNumber,
                    Name = $"Компания {companies.Select(c => c.ID).Max()+1}",
                    INN = String.Join("", Enumerable.Range(0, 12).Select(n => new Random().Next(0, 10)))
                };
                Console.WriteLine(newCompany.INN);
                await client.PostAsJsonAsync("http://localhost:5198/api/companies/create", newCompany);
            }
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Ошибка при подключении к серверу: {e.Message}");
    }
    Thread.Sleep(5000);
}

public class Company : IEquatable<Company>
{
    public int ID { get; set; }
    public int? ParentCompanyID { get; set; }
    public string Name { get; set; }
    public string INN { get; set; }
    public string Phone { get; set; }

    public bool Equals(Company? other)
    {
        return this.INN == other?.INN;
    }
    // public override int GetHashCode()
    // {
    //     return this.INN.GetHashCode();
    // }
    // public override bool Equals(object? obj)
    // {
    //     return this.Equals(obj as Company);
    // }
}


