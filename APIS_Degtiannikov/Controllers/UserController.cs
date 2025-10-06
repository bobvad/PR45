using APIS_Degtiannikov.Context;
using APIS_Degtiannikov.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace APIS_Degtiannikov.Controllers
{
    [Route("api/UserController")]
    public class UserController: Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary> 
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <remarks>Данный метод получает список задач, по предоставленной данные</remarks>
        ///<response code="200">Пользователя успешно авторизован</response>
        ///<response code = "403">Запрос не имеет данных для авторизации</response>
        ///<response code="500">При выполнении запроса на стороне сервера возникли ошибки</response>
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users),200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm]string Login,[FromForm]string Password)
        {
            if (Login == null && Password == null)
                return StatusCode(403);
            try
            {
                Users user = new UserContext().Users.Where(x => x.Login == Login && x.Password == Password).First();
                return Json(user);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
