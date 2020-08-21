using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.Bootstrap
{
    public class IoC
    {
        private static IContainer Container { get; set; }

        public static void Configure (IAppIoCContainerBuilderFactory builderFactory)
        {
            Container = builderFactory.GetBuilder().Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
