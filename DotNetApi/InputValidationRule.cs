using System.Threading.Tasks;
using GraphQL.Validation;

namespace StarWarsGL.DotNetApi
{
    public class InputValidationRule : IValidationRule 
    {
        public Task<INodeVisitor> ValidateAsync(ValidationContext context)
        {
            return Task.FromResult((INodeVisitor)new EnterLeaveListener(_ => {}));
        }
    }
}