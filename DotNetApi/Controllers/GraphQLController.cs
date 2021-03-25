using System.Threading.Tasks;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using StartWarsQL.DotNetApi.GraphQL;

namespace StartWarsQL.DotNetApi.Controllers
{
    [ApiController]
    [Route("graphql")]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        
        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDto query)
        {
            var result = await _executer.ExecuteAsync(_ => {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables?.ToInputs();
            });
            if(result.Errors?.Count > 0)
                return BadRequest();
            
            return Ok(result.Data);
        }
    }
}