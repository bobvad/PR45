using System;

namespace APIS_Degtiannikov.Models
{
    /// <summary>
    /// Модель задачи
    /// </summary>
    public class Task
    {
        /// <summary>
        /// ID задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Дата выполнения задачи
        /// </summary>
        public DateTime DateExecute { get; set; }

        /// <summary>
        /// Комментарий к задаче
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Статус выполнения задачи
        /// </summary>
        public bool Done { get; set; }
    }
}
