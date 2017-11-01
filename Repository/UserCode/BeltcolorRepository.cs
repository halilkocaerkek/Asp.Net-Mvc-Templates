
using DataModel;
using System;

public partial class BeltcolorRepository
{
    public override void Add ( beltColor entity )
    {

        // entity.id = Guid.NewGuid( ).ToString( );
        //entity.createdAt = DateTime.Now;
        //entity.deleted = false;
        //entity.updatedAt = DateTime.Now;
        //Byte[] bArray = new byte[8];
        //bArray [ 0 ] = 1;
        //entity.version = bArray;

        base.Add(entity);
    }
}