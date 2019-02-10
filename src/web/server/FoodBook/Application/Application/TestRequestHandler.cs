using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FoodBook.Application
{
    public class TestRequestHandler: IRequestHandler<TestRequest, string>
    {
        public Task<string> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("test");
        }
    }
}