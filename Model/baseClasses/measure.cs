using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public partial class measure
    {
        public override string ToString ()
        {
 

            if( measuretype.Name == "Kilo")
            {
                try
                {
                    int  kilo = value / 1000;
                    int gram = value % 1000;
                    return string.Format("{0}.{1} {2}" , kilo , gram , measuretype.unit);
                }
                catch
                {

                }
            }

            return string.Format("{0} {1}" , value , measuretype.unit);
        }
    }
}
