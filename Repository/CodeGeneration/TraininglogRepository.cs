                
using DataModel;
              
public partial class TraininglogRepository : Repository<traininglog>, ITraininglogRepository
{
    private ddsport _context;

    public TraininglogRepository(ddsport context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ITraininglogRepository.cs file
}
