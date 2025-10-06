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
        /// <summary>
        /// Регистрация пользователя
        /// </summary> 
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <remarks>Данный метод регистрирует нового пользователя в системе</remarks>
        /// <response code="200">Пользователь успешно зарегистрирован</response>
        /// <response code="400">Неверные данные для регистрации</response>
        /// <response code="409">Пользователь с таким логином уже существует</response>
        /// <response code="500">При выполнении запроса на стороне сервера возникли ошибки</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            try
            {
                var context = new UserContext();
                {
                    if (context.Users.Any(u => u.Login == Login))
                        return StatusCode(409, "Пользователь с таким логином уже существует");

                    Users user = new Users()
                    {
                        Login = Login,
                        Password = Password 
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(new
                    {
                        userId = user.Id,
                        login = user.Login
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при регистрации: {ex.Message}");
                return StatusCode(500, "Произошла ошибка при регистрации пользователя");
            }
        }
    }
}
