using Account.Repository.Interfaces;
using Account.Services.Tests.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Tests
{
    /// <summary>
    /// Bootstrapper class for DI using SimpleInjector.
    /// </summary>
    public class BootStrapper
    {
        public BootStrapper()
        {
            // Register types.
            this.Container.Register<IAccountRepository, FakeAccountRepository>();
            this.Container.Register<IAccountService, AccountService>();

            // Optionally verify the container.
            this.Container.Verify();
        }

        public Container Container { get; } = new Container();
    }
}
