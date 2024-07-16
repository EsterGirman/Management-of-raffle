//using Microsoft.Owin.Security.OAuth;
//using Owin;
//using static FinalProject.APIAUTHORIZATIONSERVERPROVIDER;
//using Microsoft.Owin.Host.SystemWeb;
//using Microsoft.Owin.Cors;

//namespace FinalProject
//{
//    public class AuthenticationStartup
//    {
        
//            public void Configuration(IAppBuilder app)
//            {
//                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

//                var myProvider = new ApiAuthorizationServerProvider();

//                var options = new OAuthAuthorizationServerOptions
//                {
//                    AllowInsecureHttp = true,
//                    TokenEndpointPath = new PathString("/token"),
//                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
//                    Provider = myProvider
//                };

//                app.UseOAuthAuthorizationServer(options);
//                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

//                var config = new HttpConfiguration();
//                WebApiConfig.Register(config);
//            }
        

//    }
//}
