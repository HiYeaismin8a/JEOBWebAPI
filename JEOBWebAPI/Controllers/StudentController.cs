using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using JEOBWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        private readonly StudentService _studentService;

        public StudentController(DataContext context)
        {
            this._context = context;
            this._studentService = new StudentService(context);
        }


        [HttpGet, ActionName("GetStudent"), Route("{id:int}")]
        public IActionResult GetStudent([FromRoute] int id)
        {

            return Ok(this._studentService.GetStudent(id));
        }


        [HttpGet, ActionName("GetAllStudents")]
        public IActionResult GetAllStudents()
        {

            return Ok(this._studentService.GetAllStudents());
        }

        [HttpGet, ActionName("GetSubjectByIdStudent"), Route("{id:int}")]
        public IActionResult GetSubjectByIdStudent([FromRoute] int id) {
            return Ok(this._studentService.GetSubjectByIdStudent(id));
        }

        [HttpPost, ActionName("PostStudent")]
        public IActionResult PostStudent([FromBody] Alumno alumno)
        {

            return Ok(this._studentService.AddStudent(alumno));
        }

        [HttpPost, Route("{idAlumno:int}")]
        public IActionResult PostSubject([FromRoute] int idAlumno, [FromBody] List<int> materias)
        {
            return Ok(this._studentService.AddSubject( idAlumno, materias));
        }


        [HttpPut, ActionName("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Alumno alumno)
        {
            alumno.Materias = new List<Materia>();
            return Ok(this._studentService.UpdateStudent(alumno));
        }


        [HttpDelete, ActionName("DeleteStudent"), Route("{id:int}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {//id

            return Ok(this._studentService.DeleteStudent(id));
        }

    }
}
