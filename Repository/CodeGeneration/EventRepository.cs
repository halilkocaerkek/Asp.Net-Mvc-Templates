                
using DataModel;
              
public partial class EventRepository : Repository<_event>, IEventRepository
{
    private ddsport _context;

    public EventRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IEventRepository.cs file
}
