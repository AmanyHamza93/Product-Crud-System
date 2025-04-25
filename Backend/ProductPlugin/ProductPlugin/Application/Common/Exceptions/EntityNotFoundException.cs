namespace Plugin.Application.Common.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException(int id) : base($"A product with id = '{id}' not found.") { }

    }
}
