using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Generico_Lib.User.Db.Data
{
    /// <summary>
    /// This class is the data access to the database using entity framework
    /// </summary>
    public class SqlDataEF
    {
        //Create the context is the conection to data base
        readonly TG_DbContext _context = new TG_DbContext();
        
        /// <summary>
        /// insert the new user and return the id of the inserted user.
        /// </summary>
        /// <param name="user"> Object User</param>
        /// <returns></returns>
        public string insertUser(User user)
        {
            //we use the sql msg to save the last inserted id
            var result = _context.sqlMsg.SqlQuery(@"exec TG_insertUser 
                                                                                 @p0, 
                                                                                 @p1,
                                                                                 @p2,
                                                                                 @p3", 
                                                            parameters: new[] {
                                                                                user.name,      //p0
                                                                                user.lastName,  //p1
                                                                                user.email,     //p2
                                                                                user.password   //p3
                                                            }).ToList();
            //we access to ht message.
            return result[0].Message;
        }

        /// <summary>
        /// This method is to logical delete a user
        /// </summary>
        /// <param name="userId">TG_User_Id from DB</param>
        public void deleteUserLogic(int userId)
        {
            //we use the sql msg to save the last inserted id
            _context.Database.ExecuteSqlCommand(@"exec TG_deleteUserLogic 
                                                                                @p0",
                                                            parameters: new[] {
                                                                               userId.ToString()      //p0
                                                                               
                                                            });
           
        }

        /// <summary>
        /// This method is to delete a user from the db
        /// </summary>
        /// <param name="userId">TG_User_Id from DB</param>
        public void deleteUser(int userId)
        {
            //we execute the SP
            _context.Database.ExecuteSqlCommand(@"exec TG_deleteUser 
                                                                                @p0",
                                                            parameters: new[] {
                                                                               userId.ToString()      //p0
                                                                               
                                                            });

        }

        /// <summary>
        /// this method update the user information
        /// </summary>
        /// <param name="user">Object User</param>
        public void updateUser(User user)
        {
            //we execute the SP
            _context.Database.ExecuteSqlCommand(@"exec TG_updateUser 
                                                                    @p0, 
                                                                    @p1,
                                                                    @p2,
                                                                    @p3,
                                                                    @p4",
                                                  parameters: new[] {

                                                                     user.userId.ToString(), //p0
                                                                     user.name,      //p1
                                                                     user.lastName,  //p2
                                                                     user.email,     //p3
                                                                     user.password   //p4
                                                                               
                                                            });

        }

        /// <summary>
        /// Get all the user in the table TG_User
        /// </summary>
        /// <returns></returns>
        public List<User> selectAllUser()
        {
            //we get all the user from SP
            var result = _context.user.SqlQuery(@"exec TG_selectAllUsers").ToList();
        
            return result;
        }


        /// <summary>
        /// Get the info from one user
        /// </summary>
        /// <param name="userId">TG_User_Id from DB</param>
        /// <returns>Object User</returns>
        public User selectUser(int userId)
        {
            //run the SP
            var result = _context.user.SqlQuery(@"exec TG_selectUser  @p0",  parameters: new[] {  userId.ToString()  }).ToList();
          
            return result[0];
        }


    }
}
