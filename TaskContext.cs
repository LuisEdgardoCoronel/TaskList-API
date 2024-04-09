using Microsoft.EntityFrameworkCore;
using TaskList_API.Model;

namespace TaskList_API
{
    public class TaskContext:DbContext
    {
        public DbSet<TaskModel> Tasks {  get; set; }
        public DbSet<UserModel> Users { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>(task =>
            {
                task.ToTable("Task");
                task.HasKey(t=>t.TaskId);
                task.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);//relacion 1 a muchos de user a task
                task.Property(t=> t.TaskName).IsRequired().HasMaxLength(150);
                task.Property(t => t.TaskDescription).IsRequired().HasMaxLength(250);
                task.Property(t => t.CreatedDate);
                task.Property(t => t.ImportanceOfTask);

            });

            modelBuilder.Entity<UserModel>(user => {
                user.ToTable("User");
                user.HasKey(t => t.UserId);
                user.Property(u => u.UserName).IsRequired().HasMaxLength(200);
                user.Property(u=>u.Password).IsRequired().HasMaxLength(200);
            });
        }
    }
}
