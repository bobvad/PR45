using APIS_Degtiannikov.Context;
using APIS_Degtiannikov.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIS_Degtiannikov.Controllers
{
    [Route("api/TasksController")] //указываем раздел
    [ApiExplorerSettings(GroupName = "v1")]
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
        /// <summary>
        /// Метод добавления задачи
        /// </summary> 
        /// <param name="task">Данные о задаче</param>
        /// <remarks>Данный метод получает добавляет задачу в базе данных</remarks>
        ///<response code="200">Задача успешно добавлена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [ApiExplorerSettings(GroupName = "v3")]
        [HttpPut]
        [Route("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm]Task task)
        {
           try
           {
              TasksContext context = new TasksContext();
              {
                 context.Tasks.Add(task);
                 context.SaveChanges();
                 return StatusCode(200);
              }
           }
           catch (Exception ex)
           {
              return StatusCode(500);
           }
        }
        /// <summary>
        /// Метод добавления задачи
        /// </summary> 
        /// <param name="task">Данные о задаче</param>
        /// <remarks>Данный метод получает добавляет задачу в базе данных</remarks>
        ///<response code="200">Задача успешно добавлена</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>
        [ApiExplorerSettings(GroupName = "v3")]
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Update([FromForm] Task task)
        {
            try
            {
              TasksContext context = new TasksContext();
              if (task != null)
              {
                 var existingTask = context.Tasks.Find(task.Id);
                 existingTask.Name = task.Name;
                 existingTask.Priority = task.Priority;
                 existingTask.Comment = task.Comment;
                 existingTask.DateExecute = task.DateExecute;
                 existingTask.Done = task.Done;
                 context.SaveChanges();
              }
              return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
