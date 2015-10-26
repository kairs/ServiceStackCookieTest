using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;

namespace SS
{
    public class AppHost : AppHostBase
    {
        //Tell ServiceStack the name of your application and where to find your services
        public AppHost() : base("Hello Web Services", typeof (HelloService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[]
                {
                    //new BasicAuthProvider(), //Sign-in with HTTP Basic Auth
                    new MyCredentialsAuthProvider() //HTML Form post of UserName/Password credentials
                }));

            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);


        }
    }
}