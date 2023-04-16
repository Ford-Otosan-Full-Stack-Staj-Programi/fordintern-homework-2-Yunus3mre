using hw2.Core.Token;

namespace hw2.Core.Services
{
    public interface ITokenManagementService
    {
        TokenResponse GenerateToken(TokenRequest tokenRequest);
    }
}
