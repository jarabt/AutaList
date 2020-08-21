using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.Bootstrap
{
    public class AppIoCContainerBuilderFactory : IAppIoCContainerBuilderFactory
    {
        public ContainerBuilder GetBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AppModel>().AsSelf().SingleInstance();

            foreach (var type in typeof(IoC).Assembly.GetTypes().Where(t => t.Name.EndsWith("ViewModel")))
            {
                builder.RegisterType(type).AsSelf().SingleInstance();
            }
            return builder;
        }
    }
}
