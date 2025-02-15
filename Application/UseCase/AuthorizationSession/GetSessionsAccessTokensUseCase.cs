using Domain.Entities.AuthorizationSession;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class GetSessionsAccessTokensUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public GetSessionsAccessTokensUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<AccessTokenAuthResponse>>> ExecuteAsync()
        {
            try
            {
                var response = await repository.GetSessionsAsync();
                return Result<List<AccessTokenAuthResponse>>.Success(response);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<List<AccessTokenAuthResponse>>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<List<AccessTokenAuthResponse>>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }


}
