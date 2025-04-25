namespace Plugin.Application.Common.Exceptions
{
    public class DuplicateProductNameException : Exception
    {
        public DuplicateProductNameException(string name) : base($"A product with the name '{name}' already exists.") { }
    }
}
