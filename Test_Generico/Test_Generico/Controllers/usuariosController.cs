using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Generico_Lib.User;
using Test_Generico_Lib.User.Db.Data;

namespace Test_Generico.Controllers
{
    public class usuariosController : Controller
    {

        /// <summary>
        /// Just a friendly message to see that all is working.
        /// </summary>
        /// <returns>Is always good to see that the code is working and have a friendly Hello :)</returns>
        public string Index()
        {
            return "Hi from Mexico";
        }
        /// <summary>
        /// http://localhost:56036/usuarios/insert/?userinfo=[%220%22,%20%22Name%20Test%20Json%22,%20%22LastName%20Json%22,%20%22email@email.com%22,%20%22password%22]
        /// </summary>
        /// <param name="userinfo">json object  Example: ["0", "Name Test Json", "LastName Json", "email@email.com", "password"] </param>
        /// <returns></returns>
        public ActionResult insert(string userinfo)
        {
            //string test = "{'userid':'1','name':'nameTest','lastName':'lastnameTest','email':'email @email.com','password':'password'}";

            //We use the Newtonsoft.Json to deserialize the list of strings.
            var jsonResponse = JsonConvert.DeserializeObject<List<string>>(userinfo);



            User user = new User();

            user.name = jsonResponse[1];
            user.lastName = jsonResponse[2];
            user.email = jsonResponse[3];
           user.password = jsonResponse[4];

            SqlDataEF dbHelper = new SqlDataEF();

            var userId = dbHelper.insertUser(user);


            return Json(userId, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Delete a user( logican delete)
        /// Example of the call
        /// http://localhost:56036/usuarios/logicDeleteUser/?userid=1
        /// </summary>
        /// <param name="userid">TG_User_Id from DB</param>
        /// <returns>1 if the delete was done correct</returns>
        public ActionResult logicDeleteUser(string userid)
        {
  
            int intUsderId = int.Parse(userid);


            SqlDataEF dbHelper = new SqlDataEF();

            dbHelper.deleteUserLogic(intUsderId);

            string result = "1";

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// permanent  delete a user
        /// Example of the call:
        /// http://localhost:56036/usuarios/deleteUser/?userid=1
        /// </summary>
        /// <param name="userid">TG_User_Id from DB</param>
        /// <returns>1 if the delete was done correct</returns>
        public ActionResult deleteUser(string userid)
        {

            int intUsderId = int.Parse(userid);


            SqlDataEF dbHelper = new SqlDataEF();

            dbHelper.deleteUser(intUsderId);

            string result = "1";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Update user info
        /// Json object example
        /// ["iduser","Name", "LastName", "Email","Password"]
        /// ["4", "Name Test Json", "LastName Json", "email@email.com", "password"]
        /// http://localhost:56036/usuarios/update/?userinfo=[%224%22,%20%22Name%20Test%20Json%22,%20%22LastName%20Json%22,%20%22email@email.com%22,%20%22password%22]
        /// </summary>
        /// <param name="userinfo">Json object in the following format ["4", "Name Test Json", "LastName Json", "email@email.com", "password"]</param>
        /// <returns>IdUser updated</returns>
        public ActionResult update(string userinfo)
        {
            //string test = "{'userid':'1','name':'nameTest','lastName':'lastnameTest','email':'email @email.com','password':'password'}";

            //We use the Newtonsoft.Json to deserialize the list of strings.
            var jsonResponse = JsonConvert.DeserializeObject<List<string>>(userinfo);

            int intUsderId = int.Parse(jsonResponse[0]);

            User user = new User();

            user.userId = intUsderId;
            user.name = jsonResponse[1];
            user.lastName = jsonResponse[2];
            user.email = jsonResponse[3];
            user.password = jsonResponse[4];

            SqlDataEF dbHelper = new SqlDataEF();

             dbHelper.updateUser(user);


            return Json(intUsderId, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Select all the users info that is on the database
        /// Example of the call:
        /// http://localhost:56036/usuarios/selectAll
        /// </summary>
        /// <returns>List of users</returns>
        public ActionResult selectAll()
        {
            List<User> users = new List<User>();

            SqlDataEF dbHelper = new SqlDataEF();

            users = dbHelper.selectAllUser();


            return Json(users, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Get Specific info from user
        /// Example of the call:
        /// http://localhost:56036/usuarios/selectUser/?userid=9
        /// </summary>
        /// <param name="userid">TG_User_Id from DB</param>
        /// <returns>User Info</returns>
        public ActionResult selectUser(string userid)
        {
            User user = new User();
            int intUsderId = int.Parse(userid);

            SqlDataEF dbHelper = new SqlDataEF();

            user = dbHelper.selectUser(intUsderId);

            return Json(user, JsonRequestBehavior.AllowGet);

        }




    }
}