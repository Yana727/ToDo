using System;

namespace ToDo.Models
{
    public class ToDoModel
    {
        public string TaskName { get; set; }
        public bool Complete { get; set; } = false;
        public DateTime Time { get; set; } = DateTime.Now;

        public int ID {get; set; }

        public void Finished(){
            Complete = true; 
            Time = DateTime.Now; 
        }
    }
}