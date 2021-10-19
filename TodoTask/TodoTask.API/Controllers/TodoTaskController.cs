using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TodoTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        List<TodoTask> Tasks = new();
        public TodoTaskController()
        {
            Tasks = new List<TodoTask>()
            {
                new TodoTask{ID = 1, TaskName = "Shopping", Descripion = "Buy a new sneakers."},
                new TodoTask{ID = 2, TaskName = "Workout", Descripion = "Finish weekly reps."}
            };
        }

        // GET: api/values
        [HttpGet]
        [Route("GetAllTodoTasks")]
        public IActionResult GetAllTodoTaskList()
        {
            //return a list of all the tasks
            return Ok(Tasks);
        }

        // POST: api/values
        [HttpPost]
        [Route("CreateNewTodoTask")]
        public IActionResult CreateNewTodoTask(TodoTask todoTask)
        {
            Tasks.Add(todoTask);

            //creates and returns a new task
            return Ok(Tasks);
        }

        // GET: api/values/2
        [HttpGet]
        [Route("GetTodoTaskByID/{ID}")]
        public IActionResult GetTodoTaskByID(int id)
        {
            var search = (from t in Tasks where t.ID == id select t).ToList();

            //returns nothing if the id is not found
            if (search.Count == 0) 
            {
                NoContent();
            }               

            //returns a specific task based on the id
            return Ok(search);
        }
    }
}
