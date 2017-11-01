                
using DataModel;
              
public partial class ClassteacherRepository : Repository<classteacher>, IClassteacherRepository
{
    private ddsport _context;

    public ClassteacherRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClassteacherRepository.cs file
}
