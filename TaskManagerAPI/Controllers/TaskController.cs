using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Entities;
using TaskManager.BAL;

namespace TaskManagerAPI.Controllers
{
    public class TaskController : ApiController
    {
        [Route("getall")]
        public IHttpActionResult Get()
        {
            TaskBL ts = new TaskBL();
            return Ok(ts.GetTask());
        }
        [Route("getbytaskid/{id:int}")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            TaskBL ts = new TaskBL();
            return Ok(ts.GetTaskbyId(id));
        }
        [Route("Addtask")]
        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Post(Task item)
        {
            TaskBL ts = new TaskBL();
            ts.AddTask(item);
            return Ok("Record added");
        }
        [Route("updatebytaskid/{id}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult put(Task item)
        {
            TaskBL ts = new TaskBL();
            ts.UpdateTask(item);
            return Ok("Record Updated");
        }
        [Route("updateendtask/{id:int}")]
        [AcceptVerbs("PUT")]
        [HttpPut]
        public IHttpActionResult Put(int id)
        {
            TaskBL ts = new TaskBL();
            ts.Endtask(id);
            return Ok("End Task updated");
        }
       [Route("Deletetask/{id:int}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            TaskBL ts = new TaskBL();
            ts.DeleteTask(id);
            return Ok("Record is deleted");
        }        
    }
}
