
  
 
    
using DataModel;
              
public partial class SinifRepository : Repository<sinif>, ISinifRepository
{
    private ddsport _context;

    public SinifRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISinifRepository.cs file
}
