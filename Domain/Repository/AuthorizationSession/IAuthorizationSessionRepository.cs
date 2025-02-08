using Domain.Entities.AuthorizationSession;
using Domain.Entities.ModelGateway;
using Domain.ShareData.Base;

namespace Domain.Repository.AuthorizationSession
{
    public interface IAuthorizationSessionRepository
    {

        Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(AuthorizationWebRequest request);
        Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest request);
        Task ValidateSessionTokenAsync(string token);
        Task<AuthorizationSessionEncryptResponse> EncryptFromWebAsync();
        Task<AuthorizationSessionEncryptResponse> EncryptFromCoreAsync(string sessionToken);
        Task<DeleteResponse> DeleteAuthorizationSessionAsync(string sessionId);
    }

}
