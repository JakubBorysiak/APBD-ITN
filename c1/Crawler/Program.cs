using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string websiteUrl;
            try
            {
                websiteUrl = args[0];

                if (websiteUrl.Length == 0)
                    throw new ArgumentNullException();

                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(websiteUrl);
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();
                    var regex = new Regex(@"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})", RegexOptions.IgnoreCase);
                    Match match = regex.Match(htmlContent);
                    if (match != null)
                    {
                        while (match.Success)
                        {
                            Console.WriteLine(match.Value);
                            match = match.NextMatch();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono adresów email");
                    }
                }
                else
                {
                    throw new ArgumentException("Błąd w czasie pobierania strony");
                }
            }
            catch
            {
                throw new ArgumentNullException("Nie podano URL!");
            }
        }
    }
}