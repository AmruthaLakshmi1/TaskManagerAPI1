using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Http;
using TaskManager.Entities;
using TaskManager.DAL;
using TaskManagerAPI;
using System.Web.Http.Results;

namespace TaskManager.Test
{
    [TestFixture]
    public class TestService
    {
        [Test]
        public void GetALL_service()
        {
            var obj = new TaskManagerAPI.Controllers.TaskController();
            IHttpActionResult result = obj.Get();
            var contentresult = result as OkNegotiatedContentResult<List<Task>>;
            Assert.IsNotNull(contentresult);
            Assert.IsNotNull(contentresult.Content);
            Assert.Greater(contentresult.Content.Count, 0);
        }
        [Test]
        public void GetbytaskID_Service()
        {
            var obj = new TaskManagerAPI.Controllers.TaskController();
            IHttpActionResult result = obj.Get();
            var contentresult = result as OkNegotiatedContentResult<List<Task>>;
            IHttpActionResult result2 = obj.Get(contentresult.Content[0].TaskId);
            var contentresult1 = result2 as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(contentresult1);
            Assert.IsNotNull(contentresult1.Content);
            Assert.AreEqual(contentresult.Content[0].TaskId, contentresult1.Content.TaskId);
        }
        [Test]
        public void AddTask_Service()
        {
            var obj = new TaskManagerAPI.Controllers.TaskController();
            Task ts = new Task { TaskName = "Task added", ParentName = "Parent added", Priority = 10, SDate = DateTime.Now, EDate = DateTime.Now, flag = true };
            IHttpActionResult result = obj.Post(ts);
            var contentresult = result as OkNegotiatedContentResult<string>;
            IHttpActionResult result1 = obj.Get();
            var contentresult1 = result1 as OkNegotiatedContentResult<List<Task>>;
            Assert.IsNotNull(contentresult);
            Assert.Greater(contentresult1.Content.Count, 0);
        }
        [Test]
        public void UpdateTAsk()
        {
            var obj = new TaskManagerAPI.Controllers.TaskController();            
            IHttpActionResult result = obj.Get();
            var contentresult = result as OkNegotiatedContentResult<List<Task>>;
            Task ts = new Task {TaskId=contentresult.Content[0].TaskId, TaskName = "Updated Task", ParentName = "Updated Parent", Priority = 10, SDate = DateTime.Now, EDate = DateTime.Now, flag = true };
            IHttpActionResult result1 = obj.put(ts);
            IHttpActionResult result2 = obj.Get();
            var contentresult1 = result2 as OkNegotiatedContentResult<List<Task>>;
            Assert.AreEqual(contentresult1.Content[0].TaskName, ts.TaskName);
        }
        [Test]
        public void DeleteTask()
        {
            var obj = new TaskManagerAPI.Controllers.TaskController();
            IHttpActionResult result = obj.Get();
            var contentresult = result as OkNegotiatedContentResult<List<Task>>;
            IHttpActionResult result1 = obj.Delete(contentresult.Content[0].TaskId);
            IHttpActionResult result2 = obj.Get();
            var contentresult1 = result2 as OkNegotiatedContentResult<List<Task>>;
            Assert.AreNotEqual(contentresult.Content[0].TaskId, contentresult1.Content[0].TaskId);

        }

    }
}

