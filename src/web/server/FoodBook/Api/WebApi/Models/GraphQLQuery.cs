using GraphQL.Types;
using Newtonsoft.Json.Linq;

namespace FoodBook.WebApi.Models
{
    public class GraphQLQuery
    {
        public string Query { get; set; }
        
        public JObject Variables { get; set; }
    }
}