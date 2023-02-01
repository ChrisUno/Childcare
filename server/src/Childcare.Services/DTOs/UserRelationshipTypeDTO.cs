namespace Childcare.Services.Services.DTOs
{
    public class UserRelationshipTypeDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int RelationshipTypeId { get; set; }
    
    }
}