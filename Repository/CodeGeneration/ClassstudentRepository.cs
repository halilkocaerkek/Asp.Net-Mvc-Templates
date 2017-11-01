                
using DataModel;
              
public partial class ClassstudentRepository : Repository<classstudent>, IClassstudentRepository
{
    private ddsport _context;

    public ClassstudentRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IClassstudentRepository.cs file
}
