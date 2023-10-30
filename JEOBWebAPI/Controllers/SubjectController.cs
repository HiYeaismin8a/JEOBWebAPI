using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using JEOBWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace JEOBWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly DataContext _context;
        private readonly SubjectService _subjectService;
       
        public SubjectController(DataContext context, IConfiguration configuration)
        {
            this._context = context;
            this._subjectService = new SubjectService(context, configuration);

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

        [HttpGet, ActionName("GetStudentByIdSubject"), Route("{idSubject:int}")]
        public IActionResult GetStudentByIdSubject([FromRoute] int idSubject) {

            return Ok(this._subjectService.GetStudentByIdSubject(idSubject));
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


        [HttpDelete, ActionName("DeleteSubject"), Route("{id:int}")]
        public IActionResult DeleteSubject([FromRoute] int id)
        {//id

            return Ok(this._subjectService.DeleteMateria(id));
        }
    }
}
