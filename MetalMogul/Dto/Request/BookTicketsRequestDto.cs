namespace MetalMogul.Dto.Request
{
    public class BookTicketsRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double TotalSum { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
