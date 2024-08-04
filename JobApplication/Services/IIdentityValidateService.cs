namespace JobApplication.Services
{
    public interface IIdentityValidateService
    {
        bool IsValid(string IdentityNumber);
    }
}