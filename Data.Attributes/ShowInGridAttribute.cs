using System;


[AttributeUsage(AttributeTargets.Property |  AttributeTargets.Field, AllowMultiple = false)]
sealed public class ShowInGridAttribute : Attribute
{
    private bool show = true;

    public bool Show
    {
        get
        {
            return show;
        }

        set
        {
            show = value;
        }
    }
}
