using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibraryMSBuild
{
    internal class GoogleHelper
    {
        public static string ApplicationName = "Google Api DotNetCore Web Client";
        public static string ClientId = "222901148030-s8pssnusb551b869va2rbu86tj3ri991.apps.googleusercontent.com";
        public static string ClientSecret = "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";
        public static string DevToken = "lYWzWvFVX-IeZ0vtNcxmXw";
        public static string CusId = "3296179833";
        public static string RedirectUri = "http://localhost:4200";
        public static string OauthUri = "https://accounts.google.com/o/oauth2/auth?";
        public static string TokenUri = "https://accounts.google.com/o/oauth2/token";
        public static string[] Scopes = { "https://www.googleapis.com/auth/adwords" };

        public static async Task<TokenResponse> GetTokenByCode(string code)
        {
            GoogleAuthorizationCodeFlow authorizationCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                Scopes = Scopes
            });
            var token = await authorizationCodeFlow.ExchangeCodeForTokenAsync(
                    "me",
                    code,
                    "http://localhost:4200",
                    CancellationToken.None);
            return token;
        }

        public static GoogleAdsClient CreateAdClient(string token)
        {
            GoogleAdsConfig config = new GoogleAdsConfig()
            {
                DeveloperToken = DevToken,
                OAuth2Mode = Google.Ads.Gax.Config.OAuth2Flow.APPLICATION,
                OAuth2ClientId = ClientId,
                OAuth2ClientSecret = ClientSecret,
                OAuth2RefreshToken = token
            };
            GoogleAdsClient client = new GoogleAdsClient(config);
            return client;
        }
    }
}
