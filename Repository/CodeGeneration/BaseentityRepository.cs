                
using DataModel;
              
public partial class BaseentityRepository : Repository<baseEntity>, IBaseentityRepository
{
    private ddsport _context;

    public BaseentityRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBaseentityRepository.cs file
}
