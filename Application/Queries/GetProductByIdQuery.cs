
using Application.DTOs;
using Transport.Queries;

namespace Application.Queries
{
    public class GetProductByIdQuery : IQuery<ProductDto>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
