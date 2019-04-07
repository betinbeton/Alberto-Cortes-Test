using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Generico_Lib.User;
using Test_Generico_Lib.User.Db.Data;

namespace Test_User_TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 to Test Insert User");
            Console.WriteLine("2 to Test Logic Delete User");
            Console.WriteLine("3 to Test Delete User");
            Console.WriteLine("4 to Test Update User");
            Console.WriteLine("5 to Test Select All User");
            Console.WriteLine("6 to Test Select User");
            Console.WriteLine("7 to Test Json");



            string option = Console.ReadLine();

            //this is to see the test that im doing
            Guid guidNumber = Guid.NewGuid();


            Console.WriteLine("Test Number: " + guidNumber.ToString());

            while (true)
            {
               

                if (option == "1")
                {
                    try
                    {
                        //*****Testing insert user***********
                        User user = new User();

                        user.name = " user name " + guidNumber.ToString();
                        user.lastName = "lastname " + guidNumber.ToString();
                        user.email = "email@email.com " + guidNumber.ToString();
                        user.password = "password " + guidNumber.ToString();

                        SqlDataEF dbHelper = new SqlDataEF();

                        var userId = dbHelper.insertUser(user);


                        Console.WriteLine("User generated: " + userId);
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "2")
                {
                    try
                    {
                        //*****Testing  Logic Delete User***********
                        //User user = new User();

                        //user.name = " user name " + guidNumber.ToString();
                        //user.lastName = "lastname " + guidNumber.ToString();
                        //user.email = "email@email.com " + guidNumber.ToString();
                        //user.password = "password " + guidNumber.ToString();

                        Console.WriteLine("Please enter,User Id to delete");
                        string idUser = Console.ReadLine();

                        int userid = int.Parse(idUser);


                        SqlDataEF dbHelper = new SqlDataEF();

                         dbHelper.deleteUserLogic(userid);


                        Console.WriteLine("USer logical deleted");
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "3")
                {
                    try
                    {
                        //*****Testing Delete User***********
                        //User user = new User();

                        //user.name = " user name " + guidNumber.ToString();
                        //user.lastName = "lastname " + guidNumber.ToString();
                        //user.email = "email@email.com " + guidNumber.ToString();
                        //user.password = "password " + guidNumber.ToString();

                        Console.WriteLine("Please enter,User Id to delete");
                        string idUser = Console.ReadLine();



                        SqlDataEF dbHelper = new SqlDataEF();

                        dbHelper.deleteUser(int.Parse(idUser));


                        Console.WriteLine("User  deleted");
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "4")
                {
                    try
                    {
                        //*****Testing update User***********
                        User user = new User();

                        user.name = " user name Updated " + guidNumber.ToString();
                        user.lastName = "lastname Updated " + guidNumber.ToString();
                        user.email = "email@email.com Updated " + guidNumber.ToString();
                        user.password = "password Updated " + guidNumber.ToString();



                        Console.WriteLine("Please enter,User Is to update");
                        string idUser = Console.ReadLine();

                        user.userId = int.Parse(idUser);


                        SqlDataEF dbHelper = new SqlDataEF();

                        dbHelper.updateUser(user);


                        Console.WriteLine("User  updated");
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "5")
                {
                    try
                    {
                        //*****Testing Select all Users***********
                        List<User> users = new List<User>();

                        //user.name = " user name Updated " + guidNumber.ToString();
                        //user.lastName = "lastname Updated " + guidNumber.ToString();
                        //user.email = "email@email.com Updated " + guidNumber.ToString();
                        //user.password = "password Updated " + guidNumber.ToString();



                        //Console.WriteLine("Please enter,User Is to update");
                        //string idUser = Console.ReadLine();

                        //user.userId = int.Parse(idUser);


                        SqlDataEF dbHelper = new SqlDataEF();

                        users = dbHelper.selectAllUser();

                        foreach(User user in users)
                        {

                            Console.WriteLine("UserId: " + user.userId + " Name: " + user.name + " LasName: " + user.lastName +  " Email: "+ user.email + " Password: " + user.password + " Active: "+ user.active);


                        }
 
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "6")
                {
                    try
                    {
                        //*****Testing Select  User***********
                        User user = new User();

                        //user.name = " user name Updated " + guidNumber.ToString();
                        //user.lastName = "lastname Updated " + guidNumber.ToString();
                        //user.email = "email@email.com Updated " + guidNumber.ToString();
                        //user.password = "password Updated " + guidNumber.ToString();



                        Console.WriteLine("Please enter,User Is to select");
                        string idUser = Console.ReadLine();

                        //user.userId = int.Parse(idUser);


                        SqlDataEF dbHelper = new SqlDataEF();

                        user = dbHelper.selectUser(int.Parse(idUser));

                        Console.WriteLine("Name: " + user.name + " LasName: " + user.name + " Email: " + user.email + " Password: " + user.password + " Active: " + user.active);

                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }
                else if (option == "7")
                {
                    try
                    {
                        //*****Testing Select  User***********
                        User user = new User();

                        string test = @"[""0"", ""Name Test Json"", ""LastName Json"", ""email@email.com"", ""password""]";

                        //We use the Newtonsoft.Json to deserialize the list of strings.
                        var jsonResponse = JsonConvert.DeserializeObject<List<string>>(test);

                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }


                }







                Console.WriteLine("Continue with another test, press test number, if not press n ");
                option = Console.ReadLine();

                if (option == "n")
                    break;
            }

        }


        static void youRock()
        {

            Console.WriteLine("You have the power and the destiny of the Users, use it wisely  ;)");
        }
    }
}
