using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.DAL
{
    public class TaskManagerContext:DbContext
    {
        public TaskManagerContext() : base("name=Taskdatasource")
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
