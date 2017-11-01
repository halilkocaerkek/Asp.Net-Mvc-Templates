                
using DataModel;
              
public partial class ScheduledataRepository : Repository<ScheduleData>, IScheduledataRepository
{
    private ddsport _context;

    public ScheduledataRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IScheduledataRepository.cs file
}
