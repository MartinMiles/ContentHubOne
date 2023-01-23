using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;
using Whiskies.Models;

namespace Whiskies.Services
{
    public interface IGraphQlService
    {
        Task<Collection> GetCollection();
        Task<Whisky> GetItem(string id);
    }

    public class GraphQlService : IGraphQlService
    {
        private readonly IConfiguration _configuration;
        public GraphQlService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //const string endpoint = "https://edge.sitecorecloud.io/api/graphql/v1";
        //const string apiToken = "R3FLNHFhM1lta3JUOHk3YkV3N0xCeGdYQ3BYWGUwbm5VL3VIRExXMUJzRT18aGMtcGVyZmljaWVudC05ZDU3Zg==";

        private GraphQLHttpClient Client
        {
            get
            {
                string endpoint = _configuration.GetValue<string>("Endpoint:Value")??String.Empty;
                string apiToken = _configuration.GetValue<string>("ApiToken:Value") ?? String.Empty;

                var client = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());
                client.HttpClient.DefaultRequestHeaders.Add("X-GQL-Token", apiToken);
                return client;
            }
        }
        public async Task<Collection> GetCollection()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                 {
                  collection(id: ""zTa0ARbEZ06uIGNABSCIvw"") {

                    intro
                    rich
                    archive {
                      results {
                        fileUrl
                        name
                      }
                    }
                    items{
                    results{
                      ... on Pdp {
                      id
                      vendor
                      brand
                      years
                      description
                      picture {
                         results {
                           fileUrl
                           name
                           }
                         }
                        }
                      }
                    }
                  }
                }"
            };

            //var responseDebugging = await Client.SendQueryAsync<dynamic>(request); // use to debug actual output

            var response = await Client.SendQueryAsync<Data>(request);
            return response.Data.Collection;
        }

        public async Task<Whisky> GetItem(string id)
        {
            // TODO: Redo query to accept parameters via Variables property
            var request = new GraphQLRequest
            {
                Query = @"
                 {
                      pdp(id: """+id+@""") {
                        id
                        vendor
                        brand
                        years
                        description
                        picture {
                         results {
                           fileUrl
                           name
                             }
                           }
                        video {
                         results {
                           fileUrl
                           name
                             }
                           }
                        }
                    }"
            };

            //var responseDebugging = await Client.SendQueryAsync<dynamic>(request); // use to debug actual output

            var response = await Client.SendQueryAsync<Data>(request);
            return response.Data.pdp;
        }
    }

}