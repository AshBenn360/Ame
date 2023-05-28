namespace Domain
{
    public class PackagingCondition
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}