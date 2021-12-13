namespace MosqueLife.Shared.Features.Members
{
    public record GetMembersResult
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MemberSince { get; set; }
        public int[] YearsPaid { get; set; } = Array.Empty<int>();
    }
}
