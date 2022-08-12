namespace MetalMogul.Exceptions
{
    public sealed class ExceedTicketsLeftException : BadRequestException
    {
        public ExceedTicketsLeftException()
            : base("You cannot book more tickets than there are tickets left.")
        {
        }
    }
}
