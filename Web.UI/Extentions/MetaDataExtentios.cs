using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public static class MetaDataExtentios
{

    public static bool isX(this PropertyMetadata obj)
    {
        Debug.WriteLine(obj.ToString());
        return true;
    }
}


