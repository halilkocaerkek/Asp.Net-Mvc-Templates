                
using DataModel;
              
public partial class BeltRepository : Repository<belt>, IBeltRepository
{
    private ddsport _context;

    public BeltRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBeltRepository.cs file
}
