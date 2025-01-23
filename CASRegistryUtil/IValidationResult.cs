namespace CASRegistryUtil
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        string ValidationMessage { get; }
    }
}