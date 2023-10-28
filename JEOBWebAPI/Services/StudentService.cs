using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace JEOBWebAPI.Services
{
    public class StudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            this._context = context;
        }

        //Get
        public Alumno GetStudent(int id)
        {

            return this._context.Alumnos.Include(e => e.Materias).FirstOrDefault();
        }

        //GetStudents
        public List<Alumno> GetAllStudents()
        {

            return this._context.Alumnos.Include(e => e.Materias).ToList();
        }

        //GetSubjectByIdStudent
        public List<Materia> GetSubjectByIdStudent(int idStudent)
        {
            var student =  this._context.Alumnos.Include(e => e.Materias).FirstOrDefault(e => e.IdAlumno == idStudent);

            return (student == null) ? new List<Materia>() : student.Materias;
        }

        //Post
        public Alumno AddStudent(Alumno alumno)
        {
            var result = this._context.Alumnos.Add(alumno);
            this._context.SaveChanges();

            return result.Entity;
        }

        //Put
        public Alumno UpdateStudent(Alumno alumno)
        {
            var result = this._context.Alumnos.Update(alumno).Entity;
            this._context.SaveChanges();

            return result;
        }

        //Delete
        public bool DeleteStudent(int id)
        {
            var alumno = this._context.Alumnos.Find(id);
            if (alumno.Materias.Count > 0) return false;

            var result = this._context.Alumnos.Remove(this._context.Alumnos.Find(id));
            this._context.SaveChanges();

            return this._context.Alumnos.Find(id) == null; //null == true -> Se borró
        }

        //
        public bool AddSubject(int idMateria, int idAlumno)
        {
            var alumno = this._context.Alumnos.Find(idAlumno);
            var materia = this._context.Materias.Find(idMateria);
            alumno.Materias.Add(materia);
            var result = this._context.SaveChanges();

            return result > 0;
        }
    }
}
