using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JEOBWebAPI.Services
{
    public class LoginService
    {
        private readonly DataContext _dataContext;
        public LoginService(DataContext context)
        {
            this._dataContext = context;
        }
        public Alumno Verifylogin(LoginInput login)
        {
            var context = _dataContext;
            var alumnos = from a in context.Alumnos
                          where a.Nombre.Equals(login.name) && a.ApellidoPaterno.Equals(login.lastName)
                          select a;


            return alumnos.FirstOrDefault();
        }
    }
}
