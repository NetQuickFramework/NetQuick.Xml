namespace NetQuick.Core.Builders
{
    public interface IBuilder
    {

    }

    public interface IBuilder<T>
    {
        /// <summary>
        /// Constructs the related type.
        /// </summary>
        /// <returns></returns>
        T Build();
    }
}
