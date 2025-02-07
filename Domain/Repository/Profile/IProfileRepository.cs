using Domain.Entities.Profile;
using Domain.Entities.Profile.Response;
using Domain.Wrapper;

namespace Domain.Repository.Profile;

public interface IProfileRepository
{

    public Task<Result<ProfileUserResponse>> GetProfileUserAsync();
    public Task<Result<ProfileResponse>> getProfileAsync();

    public Task<Result<ProfileResponse>> UpdateProfileAsync(ProfileRequest profileRequest);


    public Task<Result<bool>> DeleteProfileAsync(string profileId);

   
    public Task<Result<ProfileResponse>> CreateProfileAsync(ProfileRequest profileRequest);
}
