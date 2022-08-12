namespace MetalMogul.Exceptions
{
    public sealed class InvalidEmailException : BadRequestException
    {
        public InvalidEmailException()
            : base("Invalid email address.")
        {
        }
    }
}
