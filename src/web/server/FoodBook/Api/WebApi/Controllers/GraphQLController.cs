using System.Threading.Tasks;
using FoodBook.Application.GraphQL.Schemes;
using FoodBook.WebApi.Attributes;
using FoodBook.WebApi.Models;
using GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    [ApiController]
    [Produces("application/json")]
    public class GraphQLController: ControllerBase
    {
        private readonly CommonGraphScheme _scheme;
        
        public GraphQLController(CommonGraphScheme scheme)
        {
            _scheme = scheme;
        }
        
        /// <summary>
        /// Returns result of graphql query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Result of operation</returns>
        [HttpPost]
        public async Task<object> GraphQl([FromBody] GraphQLQuery query)
        {
            Inputs inputs = query.Variables.ToInputs();

            return await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _scheme;
                _.Query = query.Query;
                _.Inputs = inputs;
            }).ConfigureAwait(false);
        }
    }
}