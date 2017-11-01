                
using DataModel;
              
public partial class MeasuretypeRepository : Repository<measuretype>, IMeasuretypeRepository
{
    private ddsport _context;

    public MeasuretypeRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IMeasuretypeRepository.cs file
}
