namespace DemoApp.API.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
            
        }
        public NotFoundException(string message, object identifier)
            : this($"{message} : {identifier.ToString()}")
        {
            
        }
    }
}
