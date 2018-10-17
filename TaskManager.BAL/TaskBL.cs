using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DAL;
using TaskManager.Entities;

namespace TaskManager.BAL
{
    public class TaskBL
    {
       public void AddTask(Task item)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                db.Tasks.Add(item);                
                db.SaveChanges();
            }
        }
        public List<Task> GetTask()
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.ToList();
            }
        }
        public Task GetTaskbyId(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.SingleOrDefault(k => k.TaskId == id);
            }
        }
       
        public void DeleteTask(int Id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {               
               Task ts = db.Tasks.Where(d => d.TaskId == Id).First();
                db.Tasks.Remove(ts);
                db.SaveChanges();
            }
        }
        public void UpdateTask(Task task)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                Task taskupdate = db.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);                
                taskupdate.ParentName = task.ParentName;
                taskupdate.TaskName = task.TaskName;
                taskupdate.Priority = task.Priority;
                taskupdate.SDate = task.SDate;
                taskupdate.EDate = task.EDate;
                db.SaveChanges();
            }
        } 
        public void Endtask(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                Task ts = db.Tasks.SingleOrDefault(x => x.TaskId == id);
                ts.flag = true;
                ts.EDate = DateTime.Now;
                db.SaveChanges();
            }
        }
       //public Task GetTaskempty(Task item)
       // {
       //     using (TaskManagerContext db = new TaskManagerContext())
       //     {
       //         Task taskupdate = db.Tasks.SingleOrDefault(x => x.TaskId == task.TaskId);
                
       //         db.SaveChanges();
       //     }

       // }
    }
}
