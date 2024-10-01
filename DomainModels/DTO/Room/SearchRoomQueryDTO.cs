namespace DomainModels.DTO
{
    
    // Query object for pagination and sorting
    
    public class SearchRoomQueryDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string? SortBy { get; set; }
        public bool IsSortAscending { get; set; } = false;
        public string? Search { get; set; }
    }
}
