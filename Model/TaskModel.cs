using System.Text.Json.Serialization;

namespace TaskList_API.Model
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public required string TaskName { get; set; }
        public required string TaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public ImportanceOfTask ImportanceOfTask { get; set; }
        public virtual UserModel? User { get; set; } //para clave foranea

    }

    public class TaskDto//data transfer Object
    {
        public Guid TaskId { get; set;}
        public Guid UserId { get; set;}
        public required string TaskName { get; set; }
        public required string TaskDescription { get; set; }
        public ImportanceOfTask ImportanceOfTask { get; set;}

    }
}
