                
using DataModel;
              
public partial class ClasstimeRepository : Repository<classtime>, IClasstimeRepository
{
    private ddsport _context;

    public ClasstimeRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClasstimeRepository.cs file
}
