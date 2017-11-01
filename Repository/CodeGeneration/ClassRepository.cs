                
using DataModel;
              
public partial class ClassRepository : Repository<sinif>, IClassRepository
{
    private ddsport _context;

    public ClassRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClassRepository.cs file
}
