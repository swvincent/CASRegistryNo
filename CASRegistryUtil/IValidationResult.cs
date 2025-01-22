namespace CASRegistryUtil
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }
        string ValidationMessage { get; set; }
    }
}