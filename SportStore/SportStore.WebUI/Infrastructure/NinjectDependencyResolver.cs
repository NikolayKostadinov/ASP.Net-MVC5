namespace SportStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Moq;
    using Ninject;
    using SportStore.Domain.Abstract;
    using SportStore.Domain.Concrete;
    using SportStore.Domain.Entities;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver" /> class.
        /// </summary>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            this.AddBindings();
        }

        /// <summary>
        /// Adds the bindings.
        /// </summary>
        private void AddBindings()
        {
            //Add bindings here

            //Adding repository
            kernel.Bind<IProductRepository>().To < EFProductRepository>();
        }

        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>The requested service or object.</returns>
        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }
    }
}