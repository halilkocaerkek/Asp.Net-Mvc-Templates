
using DataModel;
using DataModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SchoolRepository
{
    public override void Add ( school entity )
    {
        entity.createdAt = DateTime.Now;
        entity.deleted = false;
        entity.updatedAt = DateTime.Now;
        Byte[] bArray = new byte[8];
        bArray [ 0 ] = 1;
        entity.version = bArray;

        base.Add(entity);
    }

    public List<schoolDTO> getAllSchools ()
    {
        var schools = new List<schoolDTO>();
        _context.school.ToList( ).ForEach(o => schools.Add(new schoolDTO( ) { id = o.id , name = o.name }));
        return schools ;
    }

    public  List<teacherDTO> getAllTeachers(int id)
    {
        List<teacherDTO> teachers = new List<teacherDTO>();
        foreach ( var teacher in _context.teacher.Where(o => o.schoolid == id) )
        {
            var t = new teacherDTO {id=teacher.id, name = teacher.name, surname = teacher.surname, thumbnailUrl= teacher.thumbnailUrl };
            teachers.Add(t);
        }
        return teachers ;
    }

    public List<studentDTO> getAllStudents ( int id )
    {
        List<studentDTO> teachers = new List<studentDTO>();
        foreach ( var student in _context.teacher.Where(o => o.schoolid == id) )
        {
            var s = new studentDTO {id=student.id, name = student.name, surname = student.surname, thumbnailUrl= student.thumbnailUrl };
            teachers.Add(s);
        }
        return teachers;
    }

    public List<classDTO> getAllClasses ( int id )
    {
        List<classDTO> classes = new List<classDTO>();
        foreach ( var _class in _context.teacher.Where(o => o.schoolid == id) )
        {
            var c = new classDTO {id=_class.id, name = _class.name };
            classes.Add(c);
        }
        return classes;
    }

    public List<roomDTO> getAllRooms ( int id )
    {
        List<roomDTO> rooms = new List<roomDTO>();
        foreach ( var room in _context.room.Where(o => o.schoolid == id) )
        {
            var t = new roomDTO {id=room.id, name = room.name  };
            rooms.Add(t);
        }
        return rooms;
    }
}