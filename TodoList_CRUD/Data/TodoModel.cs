using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList_CRUD.Data
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        [Required,MaxLength(64)]
        public string Content { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateTime { get; set; }

        public TodoModel(string content, DateTime? dueTime)
        {
            Id = Guid.NewGuid();
            Content = content;
            DueTime = dueTime;
            IsCompleted = false;
            CreateTime = DateTime.Now;
        }
        public TodoModel(string content)
        {
            Id = Guid.NewGuid();
            Content = content;
            IsCompleted = false;
            CreateTime = DateTime.Now;
        }

        public TodoModel(string content,DateTime createTime ,DateTime? dueTime,bool isCompleted)
        {
            Id = Guid.NewGuid();
            Content = content;
            DueTime = dueTime;
            IsCompleted = isCompleted;
            CreateTime = createTime;
        }

        public TodoModel()
        {
            
        }
    }


}
