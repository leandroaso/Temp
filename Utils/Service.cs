using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Utils
{
    public class Service
    {
        public async Task<List<Post>> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/");
                var posts = JsonConvert.DeserializeObject<List<Post>>(json);

                return posts;
            }
        }

    }
}
