using System.Net;
using Newtonsoft.Json;

namespace BlazorApp1.HTTPServerApi
{
    public class HTTPServerApi
    {
        HttpListener server = new HttpListener();
        


        public HTTPServerApi()
        {
            Task.Run(() => ServerLisener());
        }
        public async Task<string> ServerLisener()
        {
            //server.Prefixes.Add("http://127.0.0.1:8888/connection/");
            //server.Start();
            //var context = await server.GetContextAsync();
            //var answer = context.Request;
            //ApiModel apiModel = JsonConvert.DeserializeObject<ApiModel>(answer);
            //if (apiModel.CheckpointName == "Metra")
            //{

            //}
            string response = "";
            return response;
        }

    }


    public class ApiModel
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public int Age { get; set; }
        }
        static int id = 1;
        List<Person> users = new List<Person>
        {
             new() { Id = id++, Name = "Tom", Age = 37 },
             new() { Id = id++, Name = "Bob", Age = 41 },
             new() { Id = id++, Name = "Sam", Age = 24 }
        };
         
        public ApiModel()
        {
           

        }
        public string CheckpointName { get; set; }


    }
}
