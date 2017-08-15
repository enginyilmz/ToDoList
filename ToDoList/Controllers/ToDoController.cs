using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        public static IList<ToDo> ToDos = new List<ToDo>();

        // GET: ToDo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return JsonSuccess(ToDos);
        }

        public JsonResult Add(string text)
        {
            var newTodo = new ToDo() {Text = text};
            ToDos.Add(newTodo);
            return JsonSuccess(newTodo, "The new task has been successfully added.");
        }

        public JsonResult Update(Guid? Id, string Text)
        {
            var todo = ToDos.SingleOrDefault(_ => _.Guid == Id);
            if (todo != null)
            {
                todo.Text = Text;
                todo.ModifiedDate=DateTime.Now;
            }
            else
            {
                return JsonError("No Records Found!");
            }

            return JsonSuccess(todo, "Task is updated.");
        }

        public JsonResult Delete(Guid? Id)
        {
            var todo = ToDos.SingleOrDefault(_ => _.Guid == Id);
            if (todo != null)
            {
                ToDos.Remove(todo);
            }
            else
            {
                return JsonError("No Records Found!");
            }

            return JsonSuccess(todo, "Task is deleted.");
        }

        public JsonResult JsonSuccess(dynamic data, string message="")
        {
            return Json(new
            {
                IsSuccess=true,
                Message=message,
                Data=data
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonError(string message)
        {
            return Json(new
            {
                IsSuccess = false,
                Message = message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}