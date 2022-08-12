namespace MetalMogul.Exceptions
{
    public sealed class ConcertNotfoundException : NotFoundException
    {   
        public ConcertNotfoundException(Guid concertId)
            : base($"The concert with id {concertId} does not exist.")
        {
        }
    }
}
