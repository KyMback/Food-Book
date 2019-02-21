using GraphQL.Builders;
using GraphQL.Types;

namespace FoodBook.Application.GraphQL.Schemes
{
    public abstract class BaseGraphScheme : Schema
    {
        private readonly ObjectGraphType _graphType = new ObjectGraphType();
        
        protected void InitializeSchema()
        {
            Query = _graphType;
            InitializeTypes();
        }
        
        protected abstract void InitializeTypes();
        
        protected FieldBuilder<object, object> AddGraphType<TGraphType>() where TGraphType : IGraphType
        {
            return _graphType.Field<TGraphType>();
        }
    }
}