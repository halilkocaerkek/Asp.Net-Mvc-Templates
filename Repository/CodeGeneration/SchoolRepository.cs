                
using DataModel;
              
public partial class SchoolRepository : Repository<school>, ISchoolRepository
{
    private ddsport _context;

    public SchoolRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ISchoolRepository.cs file
}
