namespace Plugin.Application.Common.Exceptions
{
    public class DuplicateProductCodeException:Exception
    {
        public DuplicateProductCodeException(string code) : base($"A product with the code '{code}' already exists.") { }

    }
}
