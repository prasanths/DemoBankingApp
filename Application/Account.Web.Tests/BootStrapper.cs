using Account.Web.Helpers;
using Account.Web.Helpers.Interfaces;
using Account.Web.Tests.Helpers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Web.Tests
{
    /// <summary>
    /// Bootstrapper class for DI using SimpleInjector.
    /// </summary>
    public class BootStrapper
    {
        public BootStrapper()
        {
            // Register types
            this.Container.Register<IHttpClient, FakeHttpClient>();
            this.Container.Register<IServiceResponseHelper, ServiceResponseHelper>();

            // Optionally verify the container.
            this.Container.Verify();
        }

        public Container Container { get; } = new Container();
    }
}
