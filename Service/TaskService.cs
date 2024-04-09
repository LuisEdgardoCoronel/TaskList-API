using Microsoft.AspNetCore.Components.Forms;
using TaskList_API.Model;

namespace TaskList_API.Service
{
    public class TaskService:ITaskService
    {
        TaskContext context;

        public TaskService(TaskContext taskContext)
        {
            this.context = taskContext;
        }



        public IEnumerable<TaskModel> GetTasks() 
        {
            return context.Tasks;
        }



        public TaskModel GetOneTask(Guid id)
        {
            return context.Tasks.Find(id);
        }




        public IEnumerable<TaskModel> GetTaskByUser(Guid userId)
        {
            return context.Tasks.Where(x => x.UserId == userId);
        }




        public async Task SaveTask(TaskModel task)
        {
            context.Add(task);
            await context.SaveChangesAsync();
        }





        public async Task UpdateTask(Guid id, TaskModel task)
        {
            var taskSearched = context.Tasks.Find(id);
            if (taskSearched != null)
            {
                taskSearched.TaskName = task.TaskName;
                taskSearched.TaskDescription = task.TaskDescription;
                taskSearched.ImportanceOfTask = task.ImportanceOfTask;

                await context.SaveChangesAsync();
            }
        }





        public async Task DeleteTask(Guid id)
        {
            var taskSearched = context.Tasks.Find(id);
            if (taskSearched != null)
            {
                context.Remove(taskSearched);
                await context.SaveChangesAsync();
            }
        }
    }
}
