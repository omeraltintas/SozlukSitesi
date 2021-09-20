using BusinessLayer.Concrete;
using DAL.Concrete;
using DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];  
            var msglist = mm.GetListInbox(p);
            return View(msglist);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var msglist = mm.GetListSendBox(p);
            return View(msglist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
    }
}