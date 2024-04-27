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
            return context.Tasks
                .Select(tasks => new TaskModel()
                {
                    TaskId = tasks.TaskId,
                    UserId = tasks.UserId,
                    TaskName = tasks.TaskName,
                    TaskDescription = tasks.TaskDescription,
                    CreatedDate = tasks.CreatedDate,
                    ImportanceOfTask = tasks.ImportanceOfTask,
                });
        }



        public TaskModel GetOneTask(Guid id)
        {
            return context.Tasks.Find(id);
        }




        public IEnumerable<TaskModel> GetTaskByUser(Guid userId)
        {
            return context.Tasks
                .Where(x => x.UserId == userId)
                .Select(tasks => new TaskModel() {
                    UserId = tasks.TaskId, 
                    TaskName= tasks.TaskName, 
                    TaskDescription= tasks.TaskDescription,
                    CreatedDate = tasks.CreatedDate,
                    ImportanceOfTask= tasks.ImportanceOfTask
                });
        }




        public async Task SaveTask(TaskModel task)
        {
            context.Tasks.Add(task);
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
