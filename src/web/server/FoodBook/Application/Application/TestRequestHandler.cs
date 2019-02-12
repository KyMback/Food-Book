using System.Threading;
using System.Threading.Tasks;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using MediatR;

namespace FoodBook.Application
{
    public class TestRequestHandler: IRequestHandler<TestRequest, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TestRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Task<string> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("test");
        }
    }
}