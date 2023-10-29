using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace JEOBWebAPI.Services
{
    public class SubjectService
    {
        private readonly DataContext _dataContext;
        public SubjectService(DataContext context) { 
            this._dataContext = context;
        }

        //Get
        public Materia GetMateria(int id)
        {

            return this._dataContext.Materias.Include(e => e.Alumnos).FirstOrDefault();
        }


        //GetAllSubjects
        public List<Materia> GetAllMateria() {

            return this._dataContext.Materias.Include(e => e.Alumnos).ToList();
        }

        //GetStudentByIdSubject
        public List<Alumno> GetStudentByIdSubject(int idSubject) {
            var subject = this._dataContext.Materias.Include(e => e.Alumnos).FirstOrDefault(e => e.IdMateria == idSubject);

            return (subject == null) ? new List<Alumno>() : subject.Alumnos;
        }

        //Post
        public Materia AddSubject(Materia materia) {
            var result = this._dataContext.Materias.Add(materia);
            this._dataContext.SaveChanges();

            return result.Entity;
        }

        //Put
        public Materia UpdateMateria(Materia materia) {
            var result = this._dataContext.Materias.Update(materia).Entity;
            this._dataContext.SaveChanges();

            return result;
        }


        //Delete
        public bool DeleteMateria(int id) {
            var materia = this._dataContext.Materias.Find(id);
            if (materia.Alumnos.Count > 0) return false;

            var result = this._dataContext.Materias.Remove(this._dataContext.Materias.Find(id));
            this._dataContext.SaveChanges();

            return this._dataContext.Materias.Find(id) == null;
        }


        public bool AddStudent(int idAlumno, int idMateria) { 
            var alumno = this._dataContext.Alumnos.Find(idAlumno);
            var materia = this._dataContext.Materias.Find(idMateria);
            materia.Alumnos.Add(alumno);
            var result = this._dataContext.SaveChanges();

            return result > 0;
        }

    }
}
