                
using DataModel;
              
public partial class StudentRepository : Repository<student>, IStudentRepository
{
    private ddsport _context;

    public StudentRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IStudentRepository.cs file
}
