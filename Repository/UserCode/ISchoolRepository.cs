using DataModel.Dto;

using System.Collections.Generic;

partial interface ISchoolRepository
{
    List<schoolDTO> getAllSchools ();
    List<teacherDTO> getAllTeachers ( int id );
    List<classDTO> getAllClasses ( int id );
    List<studentDTO> getAllStudents ( int id );
    List<roomDTO> getAllRooms ( int id );
}

