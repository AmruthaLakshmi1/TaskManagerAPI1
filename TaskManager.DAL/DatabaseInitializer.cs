using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace TaskManager.DAL
{
   public class DatabaseInitializer:DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext context)
        {
            base.Seed(context);
            
        }
    }
}
