                
using DataModel;
              
public partial class MeasureRepository : Repository<measure>, IMeasureRepository
{
    private ddsport _context;

    public MeasureRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMeasureRepository.cs file
}
