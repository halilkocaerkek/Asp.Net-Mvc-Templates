            using System;

public interface IUnitOfWork : IDisposable
{
    ISinifRepository sinifs { get; }
    IClassstudentRepository classstudents { get; }
    IScheduledataRepository ScheduleDatas { get; }
    IClasstimeRepository classtimes { get; }
    IMeasureRepository measures { get; }
    IStudentRepository students { get; }
    IBaseentityRepository baseEntities { get; }
    IBeltcolorRepository beltColors { get; }
    IRoomRepository rooms { get; }
    IEventRepository _events { get; }
    IClassteacherRepository classteachers { get; }
    ISchoolRepository schools { get; }
    IBeltRepository belts { get; }
    IBranchRepository branchs { get; }
    ITraininglogRepository traininglogs { get; }
    ITeacherRepository teachers { get; }
    ISchoolbranchRepository schoolbranchs { get; }
    IMeasuretypeRepository measuretypes { get; }
    void SaveChanges();
}
