                
using DataModel;
              
public partial class RoomRepository : Repository<room>, IRoomRepository
{
    private ddsport _context;

    public RoomRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IRoomRepository.cs file
}
