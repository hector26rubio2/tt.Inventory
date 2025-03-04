namespace Application.DTOs
{
    public class ProductDto
    {
 
        public Guid Id { get; set; }

 
        public string Name { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public decimal Price { get; set; }
    }
}
