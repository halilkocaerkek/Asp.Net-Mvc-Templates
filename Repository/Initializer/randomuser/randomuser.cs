using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Initializer.randomuser
{
    public class randomuser
    {
        public static List<Result> get(int count)
        {
            var users = new List<Result>();
            var client = new RestClient("https://randomuser.me/api?results=40&nat=gb");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("", Method.GET);
            //var request = new RestRequest("api", Method.POST);
            //request.AddParameter("results" , count.ToString()); // adds to POST or URL querystring based on Method
            //request.AddParameter("nat" , "tr");
            // request.AddUrlSegment("id" , "123");

            // execute the request
            //IRestResponse response = client.Execute(request);
            //var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            var response2 = client.Execute<RootObject>(request);
            //var name = response2.Data.;

            //// easy async support
            //client.ExecuteAsync(request , response => {
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort( );
            return response2.Data.results;
        }
    }


    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
    }

    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    public class Id
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public string dob { get; set; }
        public string registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }

        public string address
        {
            get
            {
                return string.Format("{0}, {1}, {2}, {3}", location.street, location.city, location.state, location.postcode);
            }
        }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }
}