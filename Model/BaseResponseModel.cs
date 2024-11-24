namespace ContactManagementService.Model
{
    public class BaseResponseModel
    {
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
    }

    public enum StatusCode
    {
        Failed = 0,
        Added = 1,
        Updated = 2,
        Deleted = 3,
        NotFound = 4,
        IdMisMatch = 5
    }

    public class StatusMessage
    {
        public const string Added = "Added successfully!";
        public const string Updated = "Updated successfully!";
        public const string Deleted = "Deleted successfully!";
        public const string Failed = "Operation Failed!";
        public const string NotFound = "Cannot find the given Id in db";
        public const string IdMisMatch = "Given id doesn't match with id in database";
    }
}
