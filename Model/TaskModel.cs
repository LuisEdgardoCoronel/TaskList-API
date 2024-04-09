namespace TaskList_API.Model
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public string TaskName { get; set; }
        public int TaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public ImportanceOfTask ImportanceOfTask { get; set; }
        public UserModel User { get; set; } //para clave forane

    }
}
