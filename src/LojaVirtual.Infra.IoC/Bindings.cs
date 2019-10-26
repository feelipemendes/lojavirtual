using SimpleInjector;
using Microsoft.Practices.ServiceLocation;
using LojaVirtual.Infra.Data.Repositories;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Services;
using CommonServiceLocator.SimpleInjectorAdapter;

namespace LojaVirtual.Infra.IoC
{
    public class Bindings
    {
        public static void Start(Container container)
        {
            //Infra
            container.Register<IProdutoRepository, ProdutoRepository>();

            //App
            container.Register<IProdutoService, ProdutoService>();

            //Service locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocaterAdapter(container));
        }
    }
}
