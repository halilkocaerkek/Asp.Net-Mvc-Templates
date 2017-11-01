using System;
using System.Diagnostics;

namespace CustomViewTemplate
{
    public static class T4Helpers
    {
        public static bool isShowInGrid(string viewDataTypeName, string propertyName)
        {
            Debug.WriteLine( string.Format("{0} - {1}", viewDataTypeName, propertyName ));
            bool isShowInGrid = false;
            ShowInGridAttribute ShowInGrid = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                Debug.WriteLine("typeModel != null");
                ShowInGrid = (ShowInGridAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(ShowInGridAttribute));
                if ( ShowInGrid != null ) return false;
                return ShowInGrid.Show;
            }

            return isShowInGrid;
        }
    }
}