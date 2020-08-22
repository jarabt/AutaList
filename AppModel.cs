using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaList
{
    public class AppModel
    {
        public IList<Auto> AutaZakladni{ get; set; } = new List<Auto>();

        public AppModel()
        {
        }
    }
}
