using System;
using System.Threading.Tasks;
using FoodBook.Application.GraphQL.Schemas;
using FoodBook.Infrastructure.Common;
using FoodBook.Infrastructure.Common.Extensions;
using FoodBook.WebApi.Attributes;
using FoodBook.WebApi.Models;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FoodBook.WebApi.Controllers
{
    [ApiRoute]
    [ApiController]
    [Produces(SystemSettings.DefaultContentTypeForApiControllers)]
    public class GraphQLController: ControllerBase
    {
        private readonly IGraphSchemaProvider _graphSchemaProvider;
        private readonly IDocumentExecuter _documentExecuter;
        
        public GraphQLController(
            IGraphSchemaProvider graphSchemaProvider,
            IDocumentExecuter documentExecuter)
        {
            _graphSchemaProvider = graphSchemaProvider;
            _documentExecuter = documentExecuter;
        }
        
        /// <summary>
        /// Returns result of graphql query
        /// </summary>
        /// <param name="query">Query for searching</param>
        /// <returns>Result of operation</returns>
        [HttpPost]
        public async Task<object> GraphQl([FromBody] GraphQLQuery query)
        {
            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _graphSchemaProvider.ResolveSchema();
                _.Query = query.Query;
                _.Inputs = query.Variables.ToInputs();
            }).ConfigureAwait(false);

            if (!result.Errors.IsNullOrEmpty())
            {
                throw new InvalidOperationException(result.Errors.Join());
            }

            return result;
        }
    }
}