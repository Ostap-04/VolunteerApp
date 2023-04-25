using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Update.Internal;
using VolunteerApp.Helpers;

namespace VolunteerApp.Services
{
    public class GoogleOAuthService
    {
        private const string ClientId = "807141529561-tudg0b4g4gnmafmbekobuoohmgt4e4pb.apps.googleusercontent.com";
        private const string ClientSecret = "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";

        public static string GenerateOAuthREquestUrl(string scope, string redirectUrl, string codeChallange)
        {
            var oAuthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";

            var queryParams = new Dictionary<string, string>
            {
                {"client_id", ClientId },
                {"redirect_url", redirectUrl},
                {"response_type", "code" },
                {"code_challenge", codeChallange },
                {"code_challenge_method", "S256"},
                {"access_type", "offline"}
            };
            var url = QueryHelpers.AddQueryString(oAuthServerEndpoint, queryParams);
            return url;
        }

        public static async Task <TokenResult> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirectUrl)
        {
            var tokenEndpoint = "https://oauth2.googleapis.com/token";

            var authParams = new Dictionary<string, string>
            {
                {"client_id", ClientId},
                {"client_secret", ClientSecret },
                {"code", code },
                {"code_verifier", codeVerifier },
                {"grant_type", "authorization_code" },
                {"redirect_url", redirectUrl }
            };
           var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(tokenEndpoint, authParams);
           return tokenResult;
        }

        public static async Task <TokenResult> RefreshTokenAsync(string refreshToken)
        {
            var refreshEndpoint = "https://oauth2.googleapis.com/token";

            var refreshParams = new Dictionary<string, string>
            {
                {"client_id", ClientId},
                {"client_secret", ClientSecret },
                {"grant_type", "refresh_token" },
                {"refresh_token", refreshToken }
            };
            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(refreshEndpoint, refreshParams);
            return tokenResult;

        }
    }
   
}
