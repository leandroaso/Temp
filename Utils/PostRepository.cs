using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Utils
{
    public class PostRepository
    {

        HttpClient client = new HttpClient();

        public PostRepository()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Post>> GetAsyncTask(CancellationToken cancellationToken)
        {
            await Task.Delay(3000);

            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await client.GetAsync("api/post", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Post>>(stringResult);
            }

            return new List<Post>();
        }
    }
}
