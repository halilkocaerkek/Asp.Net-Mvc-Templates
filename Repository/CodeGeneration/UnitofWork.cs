using System;
using System.Text;
using System.Data.Entity.Validation;
using DataModel;

public class UnitOfWork : IUnitOfWork
{
    private ddsport _context;

    public UnitOfWork(ddsport context)
    {
        _context = context;
    }
	 
	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new ddsport();
	}
	
    public ISinifRepository sinifs
    {
        get { return new SinifRepository(_context); }
    }

    public IClassstudentRepository classstudents
    {
        get { return new ClassstudentRepository(_context); }
    }

    public IScheduledataRepository ScheduleDatas
    {
        get { return new ScheduledataRepository(_context); }
    }

    public IClasstimeRepository classtimes
    {
        get { return new ClasstimeRepository(_context); }
    }

    public IMeasureRepository measures
    {
        get { return new MeasureRepository(_context); }
    }

    public IStudentRepository students
    {
        get { return new StudentRepository(_context); }
    }

    public IBaseentityRepository baseEntities
    {
        get { return new BaseentityRepository(_context); }
    }

    public IBeltcolorRepository beltColors
    {
        get { return new BeltcolorRepository(_context); }
    }

    public IRoomRepository rooms
    {
        get { return new RoomRepository(_context); }
    }

    public IEventRepository _events
    {
        get { return new EventRepository(_context); }
    }

    public IClassteacherRepository classteachers
    {
        get { return new ClassteacherRepository(_context); }
    }

    public ISchoolRepository schools
    {
        get { return new SchoolRepository(_context); }
    }

    public IBeltRepository belts
    {
        get { return new BeltRepository(_context); }
    }

    public IBranchRepository branchs
    {
        get { return new BranchRepository(_context); }
    }

    public ITraininglogRepository traininglogs
    {
        get { return new TraininglogRepository(_context); }
    }

    public ITeacherRepository teachers
    {
        get { return new TeacherRepository(_context); }
    }

    public ISchoolbranchRepository schoolbranchs
    {
        get { return new SchoolbranchRepository(_context); }
    }

    public IMeasuretypeRepository measuretypes
    {
        get { return new MeasuretypeRepository(_context); }
    }

    
    public void SaveChanges()
    {
        try
        {
            _context.SaveChanges( );
        }
        catch ( DbEntityValidationException ex )
        {
            StringBuilder sb = new StringBuilder(ex.Message);
            sb.AppendLine("");
            foreach(var validationError in ex.EntityValidationErrors )
            {
                sb.AppendFormat("{0} : {1}{2}" , validationError.Entry.Entity.ToString() , validationError.Entry.State, Environment.NewLine);
                foreach ( var error in validationError.ValidationErrors )
                {
                    sb.AppendFormat("{0} : {1}{2}" , error.PropertyName , error.ErrorMessage , Environment.NewLine);
                }
                sb.AppendLine("");

                try
                {
                    sb.AppendLine("Current Values:");
                    if ( validationError.Entry.CurrentValues != null )
                    {
                        foreach ( var propname in validationError.Entry.CurrentValues.PropertyNames )
                        {
                            sb.AppendFormat("{0} : {1}{2}" , propname , validationError.Entry.CurrentValues [ propname ] , Environment.NewLine);
                        }
                        sb.AppendLine("");
                    }
                }
                catch(Exception ex1)
                {
                    sb.AppendLine(ex1.Message);
                }

                try
                {
                    sb.AppendLine("Original Values:");
                    if ( validationError.Entry.OriginalValues != null )
                    {
                        foreach ( var propname in validationError.Entry.OriginalValues.PropertyNames )
                        {
                            sb.AppendFormat("{0} : {1}{2}" , propname , validationError.Entry.OriginalValues [ propname ] , Environment.NewLine);
                        }
                    }
                }
                catch(Exception ex2)
                {
                    sb.AppendLine(ex2.Message);
                }
            }
            sb.AppendLine("");
            throw new Exception(sb.ToString( ));
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
