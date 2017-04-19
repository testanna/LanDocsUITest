namespace LanDocsUITest.LanDocs3Client.Exceptions
{
    /// <summary>
    /// Исключение, возвращаемое, если объект не найден.
    /// </summary>
    class ObjectNotFoundException : System.Exception
    {
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
