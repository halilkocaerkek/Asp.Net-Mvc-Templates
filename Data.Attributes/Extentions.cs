using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class ModelExtensionMethods
{
    public static bool isShowInGrid(this PropertyInfo obj)
    {
        if (obj == null)
            return false;

        var showingrid = obj.GetCustomAttribute<ShowInGridAttribute>();
        if(showingrid != null)
        {
            return showingrid.Show;
        }

        return true;
    }

 
}