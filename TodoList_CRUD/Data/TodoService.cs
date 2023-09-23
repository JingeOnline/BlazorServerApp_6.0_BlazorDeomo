namespace TodoList_CRUD.Data
{
    public class TodoService
    {
        private static List<TodoModel> TodoList = new List<TodoModel>()
        {
            new TodoModel("Clean the bathroom.",
                new DateTime(2023,6,22,10,20,0),
                new DateTime(2023,6,22,13,20,0),
                true),
            new TodoModel("Update the passport detail on the internet.",
                new DateTime(2023,6,22,10,20,0),
                new DateTime(2023,6,30,12,30,0),
                true),
            new TodoModel("Shopping some milk.",
                new DateTime(2023,8,20,10,20,0),
                new DateTime(2023,9,5,10,20,0),
                false),
            new TodoModel("Check the mailbox for new letter.",
                new DateTime(2023,8,21,10,20,0),
                null,
                false),
            new TodoModel("Change the SIM Card from Telstra to Vodafon.",
                new DateTime(2023,7,21,10,20,0),
                null,
                false),
            new TodoModel("Update the CV for Barwon Water job vacancy",
                new DateTime(2023,9,1,10,20,0),
                new DateTime(2023,10,1,10,20,0),
                false),
        };

        public List<TodoModel> GetToDoByContent(string content = "")
        {
            if (string.IsNullOrEmpty(content))
            {
                return TodoList;
            }
            else
            {
                return TodoList.Where(x => x.Content.Contains(content, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public void UpdateTodo(TodoModel model)
        {
            TodoModel old= TodoList.FirstOrDefault(x=>x.Id==model.Id);
            if (old!=null)
            {
                old.Content = model.Content;
                old.DueTime = model.DueTime;
                old.IsCompleted = model.IsCompleted;
            }
        }

        public void CreateNewTodo(TodoModel model)
        {
            TodoList.Add(model);
        }

        public void DeleteTodo(TodoModel model)
        {
            TodoList.Remove(model);
        }
    }
}
