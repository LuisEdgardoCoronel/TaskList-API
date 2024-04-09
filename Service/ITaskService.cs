using TaskList_API.Model;

namespace TaskList_API.Service
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();
        TaskModel GetOneTask(Guid id);
        IEnumerable<TaskModel> GetTaskByUser(Guid userId);
        Task SaveTask(TaskModel task);
        Task UpdateTask(Guid id, TaskModel task);
        Task DeleteTask(Guid id);
    }
}
