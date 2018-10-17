using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskManager.BAL;
using TaskManager.Entities;

namespace TaskManager.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Getall()
        {
            TaskBL obj = new TaskBL();
            int count = obj.GetTask().Count();
            Assert.Greater(count, 0);
        }
        [Test]
        public void Getbytask()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetTask();            
            //Task count = obj.GetTaskbyId(1);
            Task count = obj.GetTaskbyId(Ts[0].TaskId);
            Assert.IsNotNull(count);
           //   Assert.Greater(count, 0);
        }
        [Test]
        public void AddTask()
        {
            TaskBL obje = new TaskBL();
            int count = obje.GetTask().Count();
            //dynamic testtask = new (Task) list<Task>;
            Task T=(new Task { ParentName = "ParentTaskstest", TaskName = "Testtaskname",Priority=15,SDate=DateTime.Now,EDate=DateTime.Now});
            obje.AddTask(T);
            int count1 = obje.GetTask().Count();
            Assert.AreEqual(count1, count+1);
        }
        [Test]
        public void updateTask()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetTask();
            Task Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
            int count = obj.GetTask().Count();
            //dynamic testtask = new (Task) list<Task>;
            Task T = (new Task {TaskId=Taskgetbyid.TaskId, ParentName = "ParentTaskstest", TaskName = "Testtaskname", Priority = 15, SDate = DateTime.Now, EDate = DateTime.Now });
            obj.UpdateTask(T);
            int count1 = obj.GetTask().Count();
            List<Task> TS1 = obj.GetTask();
            //Assert.AreEqual(count1, count );
            Assert.AreEqual(T.TaskName,TS1[0].TaskName);
        }
        [Test]                        
        public void DeleteTask()
        {
            TaskBL obj = new TaskBL();
            List<Task> Ts = obj.GetTask();
            Task Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
            int count1 = obj.GetTask().Count();
            //dynamic testtask = new (Task) list<Task>;
            //Task T = (new Task { TaskId = 1015, ParentName = "ParentTaskstest", TaskName = "Testtaskname", Priority = 15, SDate = DateTime.Now, EDate = DateTime.Now });           
            obj.DeleteTask(Taskgetbyid.TaskId);
            int count2 = obj.GetTask().Count();
            Assert.AreEqual(count2, count1 - 1);
        }
    }
}
