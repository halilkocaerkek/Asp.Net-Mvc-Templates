                
using DataModel;
              
public partial class BeltcolorRepository : Repository<beltColor>, IBeltcolorRepository
{
    private ddsport _context;

    public BeltcolorRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IBeltcolorRepository.cs file
}
