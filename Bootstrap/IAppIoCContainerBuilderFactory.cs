using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList.Bootstrap
{
    public interface IAppIoCContainerBuilderFactory
    {
        ContainerBuilder GetBuilder();
    }
}
