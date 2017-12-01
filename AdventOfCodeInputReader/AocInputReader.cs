using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCodeInputReader
{
    public class AoCInputReader
    {
        private readonly CookieContainer _cookieContainer;

        public AoCInputReader(string sessionCookieValue)
        {
            _cookieContainer = new CookieContainer();
            _cookieContainer.Add(new Uri("http://adventofcode.com"),new Cookie("session", sessionCookieValue));
        }

        public async Task<string[]> GetInputForDay(int day)
        {
            using (var handler = new HttpClientHandler {CookieContainer = _cookieContainer})
            {
                using (var client = new HttpClient(handler){ BaseAddress = new Uri($"http://www.adventofcode.com/2017/day/{day}/input") })
                {
                    var result = await client.GetAsync("");
                    result.EnsureSuccessStatusCode();
                    var response = await result.Content.ReadAsStringAsync();
                    return response.Split('\n').Where(x => x != String.Empty).ToArray();
                }
            }
        }
    }
}
