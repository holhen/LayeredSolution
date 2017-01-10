namespace LayeredSolution.BusinessLayer
{
    public class ProductModel
    {
        public virtual int Id { get; set; }
        public virtual string ProductNo { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
    }
}