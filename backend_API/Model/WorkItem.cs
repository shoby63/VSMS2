namespace backend_API.Model
{

    public class WorkItem
    {
        public int Id { get; set; }  // EF will handle the primary key generation
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }

}
