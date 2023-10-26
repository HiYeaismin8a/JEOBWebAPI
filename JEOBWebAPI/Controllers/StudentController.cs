using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using JEOBWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Controllers
{
    [Route("api/[controller]")]
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


        [HttpPost, ActionName("PostStudent")]
        public IActionResult PostStudent([FromBody] Alumno alumno)
        {

            return Ok(this._studentService.AddStudent(alumno));
        }


        [HttpPut, ActionName("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Alumno alumno)
        {

            return Ok(this._studentService.UpdateStudent(alumno));
        }


        [HttpDelete, ActionName("DeleteStudent"), Route("{id:int}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {//id

            return Ok(this._studentService.DeleteStudent(id));
        }

        [HttpPost, Route("{idAlumno:int}/{idMateria:int}")]
        public IActionResult PostSubject([FromRoute] int idAlumno, [FromRoute] int idMateria)    {
            return Ok(this._studentService.AddSubject(idMateria, idAlumno));
        }
    }
}
