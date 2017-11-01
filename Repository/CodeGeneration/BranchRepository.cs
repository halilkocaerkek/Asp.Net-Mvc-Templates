                
using DataModel;
              
public partial class BranchRepository : Repository<branch>, IBranchRepository
{
    private ddsport _context;

    public BranchRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBranchRepository.cs file
}
