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
            var student = this._context.Alumnos.Include(e => e.Materias).FirstOrDefault(e => e.IdAlumno == idStudent);

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
        public bool AddSubject(int idAlumno, List<int> materias)
        {
            var alumno = this._context.Alumnos.Include(e => e.Materias).SingleOrDefault(e => e.IdAlumno == idAlumno);
            if (alumno == null) return false;

            foreach (var materia in alumno.Materias.ToList())
            {
                alumno.Materias.Remove(materia);
            }

            bool original = this._context.SaveChanges() > 0;
            var mats = this._context.Materias.Where(e => materias.Contains(e.IdMateria)).ToList();
            alumno.Materias.AddRange(mats);
            return this._context.SaveChanges() > 0 || original;
        }
    }
}
