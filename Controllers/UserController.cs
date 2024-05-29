using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index(string searchString = null)
        {
            // Retrieve the list of users from the userlist
            var users = userlist;

            // If a search string is provided, filter the userlist based on the search string
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Name.Contains(searchString) || u.Email.Contains(searchString)).ToList();
            }

            // Return the Index view with the list of users
            return View(users);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the Details view with the user
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }
 
      // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Add the user to the userlist
                userlist.Add(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the Create view with the user object
            return View(user);
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If successful, it returns the Edit view with the user object.
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the Edit view with the user object
            return View(user);

        }
 
      // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Retrieve the user from the userlist based on the provided ID
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the user's information with the new values
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Return the Delete view with the user
            return View(user);
        }

         [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Retrieve the user from the userlist based on the provided ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Search
        public ActionResult Search(string searchString)
        {
            // Filter the userlist based on the search string
            var filteredUsers = userlist.Where(u => u.Name.Contains(searchString) || u.Email.Contains(searchString)).ToList();

            // Return the Index view with the filtered list of users
            return View("Index", filteredUsers);
        }

    }
}
