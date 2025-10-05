using APIS_Degtiannikov.Context;
using APIS_Degtiannikov.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIS_Degtiannikov.Controllers
{
    [Route("api/TasksController")] //указываем раздел
    public class TasksController: Controller
    {
        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        ///<response code="200">Список успешно получен</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("List")]// указываем какой метод вызывается
        [HttpGet]//указываем какой тип запроса используется
        [ProducesResponseType(typeof(List<Task>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                IEnumerable<Task> Tasks = new TasksContext().Tasks;
                return Json(Tasks);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Получение задачи
        /// </summary> 
        /// <param name="Id">Код задачи</param>
        /// <remarks>Данный метод получает список задач, находящуюся в базе данных</remarks>
        ///<response code="200">Задача успешно получен</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [Route("Item")]// указываем какой метод вызывается
        [HttpGet]//указываем какой тип запроса используется
        [ProducesResponseType(typeof(Task), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                Task Task = new TasksContext().Tasks.Where(x => x.Id == Id).First();
                return Json(Task);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
      
    }
}
