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
                new TodoTask{ID = 1, TaskName = "Write and publish an article", Descripion = "Just a simple API article."},
                new TodoTask{ID = 2, TaskName = "Push code to github", Descripion = "Make the code available on github."}
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
            var task = (from t in Tasks where t.ID == id select t).ToList();

            //returns nothing if the id is not found
            if (task.Count == 0) 
            {
                NoContent();
            }               

            //returns a specific task based on the id
            return Ok(Tasks);
        }
    }
}
