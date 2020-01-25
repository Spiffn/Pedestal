using System;

namespace Pedestal.Catalog.Models
{
    public class Modeldydoo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UploaderId { get; set; }
        public string FileUri { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }
        public DateTimeOffset UploadDateUtc { get; set; }
    }
}
