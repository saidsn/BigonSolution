using Bigon.WebUI.Models.Entities;
using Bigon.WebUI.Models.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Bigon.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            bool isEmailValid = Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            if (!isEmailValid)
            {
                return Json(new
                {
                    error = true,
                    message = $"{email} is not a valid email address!"
                });
            }

            var subscriber = await _dataContext.Subscribers.FirstOrDefaultAsync(s => s.Email.Equals(email));

            if (subscriber != null && subscriber.Approved)
            {
                return Json(new
                {
                    error = true,
                    message = $"This {email} address is already subscribed!"
                });
            }
            else if (subscriber != null && !subscriber.Approved)
            {
                return Json(new
                {
                    error = false,
                    message = $"You must verify this {email} address!"
                });
            }

            subscriber = new Subscriber();
            subscriber.Email = email;
            subscriber.CreatedDate = DateTime.Now;

            _dataContext.Add(subscriber);
            _dataContext.SaveChanges();

            return Json(new
            {
                error = false,
                message = $"To confirm your subscription, enter your {email} address and confirm the link!"
            });
        }
    }
}
