namespace Extensions.Helpers
{
    public abstract class SemanticType<T>
    {
        protected SemanticType(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
