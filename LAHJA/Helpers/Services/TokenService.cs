using LAHJA.Helpers.Enum;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Shared.Constants;
using Shared.Helpers;
namespace LAHJA.Helpers.Services
{

    ////TODO: 8-2
    public class TokenService : ITokenService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ProtectedSessionStorage PSession;
        public TokenService(IJSRuntime jsRuntime, ProtectedSessionStorage pSession)
        {
            _jsRuntime = jsRuntime;
            PSession = pSession;
        }
        public async Task<bool> IsWebHasStartUpAsync()
        {
            try
            {
                return (await PSession.GetAsync<bool>(ConstantsApp.START_UP_WEB)).Value;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        public async Task<bool> StartUpWebSessionAsync()
        {

            try
            {
                if (!await IsWebHasStartUpAsync())
                {
                    await PSession.SetAsync(ConstantsApp.START_UP_WEB, true);
                    return true;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task SaveTokenInSessionAsync(string token)
        {

            try
            {
                if (!string.IsNullOrEmpty(token))
                {

                    await PSession.SetAsync(ConstantsApp.ACCESS_TOKEN, token);
                }

            }
            catch (Exception e)
            {

            }
        }

        public async Task DeleteTokenFromSessionAsync()
        {
            try
            {
                await PSession.DeleteAsync(ConstantsApp.ACCESS_TOKEN);

            }catch(Exception e)
            {

            }
        }

        public async Task<string> GetTokenFromSessionAsync()
        {
            return  (await PSession.GetAsync<string>(ConstantsApp.ACCESS_TOKEN)).Value??"";
        }

        public async Task SaveTokenAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.ACCESS_TOKEN, token);
            }
           
        }

        public async Task SaveRefreshTokenAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.REFRESH_TOKEN, token);
            }

           
        }
        public async Task SaveExpiresInTokenAsync(string expiresIn)
        {
            if (!string.IsNullOrEmpty(expiresIn))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.EXPIRES_IN_TOKEN, expiresIn);
            }
           
        }
        public async Task SaveTokenTypeAsync(string tokenType)
        {
            if (!string.IsNullOrEmpty(tokenType))
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.TOKEN_TYPE, tokenType);
            }
 
        }
        public async Task SaveLoginTypeAsync(LoginType type)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LOGIN_TYPE, type.ToString());
        }
        public async Task DeleteLoginTypeAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LOGIN_TYPE);
        }
        public async Task<string> GetLoginTypeAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.LOGIN_TYPE) ?? LoginType.Email.ToString();
        }
        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.ACCESS_TOKEN)??"";
        }  
        

        public async Task<string> GetRefreshTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.REFRESH_TOKEN) ?? "";
        }
        public async Task<string> GetExpiresInTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.EXPIRES_IN_TOKEN);
        }
        public async Task<string> GetTokenTypeAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.TOKEN_TYPE);
        }

        public async Task SaveAllTokensAsync(string accessToken, string refreshToken,
            string expiresInToken, string tokenType)
        {

            if (!string.IsNullOrEmpty(accessToken))
            {
                await SaveTempTokenAsync(accessToken);
            }


            await SaveTokenAsync(accessToken);
             
            await SaveRefreshTokenAsync(refreshToken);
             
            await SaveExpiresInTokenAsync(expiresInToken);

            await SaveTokenTypeAsync(tokenType);
            
        
          
           
          
        }

        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
        }

	
		public async Task RemoveAllTokensAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.ACCESS_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.REFRESH_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.EXPIRES_IN_TOKEN);
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", ConstantsApp.TOKEN_TYPE);

                await RemoveTempTokenAsync();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
		public async Task SaveTempTokenAsync(string token)
		{
			await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "Temp_Token", token);
		}

		public async Task<string> GetTempTokenAsync()
		{
			return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "Temp_Token") ?? "";
		}
		public async Task RemoveTempTokenAsync()
		{
			try
			{
				await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", "Temp_Token");
			}
			catch (Exception ex)
			{

			}
		}





	}
}
