using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using JEOBWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace JEOBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly DataContext _context;
        private readonly SubjectService _subjectService;
        public SubjectController(DataContext context)
        {
            this._context = context;
            this._subjectService = new SubjectService(context);
        }

        [HttpGet, ActionName("GetMateria"), Route("{id:int}")]
        public IActionResult GetMateria([FromRoute] int id)
        {//Extraerr

            return Ok(this._subjectService.GetMateria(id));
        }

        [HttpGet, ActionName("GetAllMateria")]
        public IActionResult GetAllMateria()
        {//Extraerr
            return Ok(this._subjectService.GetAllMateria());
        }

        [HttpPost, ActionName("PostMateria")]
        public IActionResult PostMateria([FromBody] Materia materia)
        {//Crear- Insertear
            return Ok(this._subjectService.AddSubject(materia));
        }


        [HttpPut, ActionName("UpdateMateria")]
        public IActionResult UpdateMateria([FromBody] Materia materia)
        {
            return Ok(this._subjectService.UpdateMateria(materia));
        }


        [HttpDelete, ActionName("DeleteMateria"), Route("{id:int}")]
        public IActionResult DeleteMateria([FromRoute] int id)
        {//id

            return Ok(this._subjectService.DeleteMateria(id));
        }


        [HttpPost, Route("{idAlumno:int}/{idMateria:int}")]
        public IActionResult PostStudent([FromRoute] int idAlumno, [FromRoute] int idMateria)
        {
            return Ok(this._subjectService.AddStudent(idAlumno, idMateria));
        }
    }
}
