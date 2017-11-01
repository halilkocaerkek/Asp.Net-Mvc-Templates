                
using DataModel;
              
public partial class SchoolbranchRepository : Repository<schoolbranch>, ISchoolbranchRepository
{
    private ddsport _context;

    public SchoolbranchRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISchoolbranchRepository.cs file
}
