                
using DataModel;
              
public partial class TeacherRepository : Repository<teacher>, ITeacherRepository
{
    private ddsport _context;

    public TeacherRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITeacherRepository.cs file
}
