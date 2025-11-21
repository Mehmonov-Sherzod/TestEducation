namespace TestEducation.Aplication.Service
{
    public interface IClaimService
    {
        string ClaimGetUserId();

        string GetClaim(string key);
    }
}
