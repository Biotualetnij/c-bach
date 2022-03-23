using System.Collections.Generic;
using holyBoly.Entities;
using System.IO;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace holyBoly.Repositories
{
    public class UserRepository{
            
        private readonly List<User> users = new(){
            new User {
                FirstName = "admin",
                LastName = "adminovich",
                Email="admin@admin.ss",
                Password = "admin"
            },
        };
        public IEnumerable<User> GetUsers(){
            return users;
        }
        public String signUp(User user){
            if(!this.checkIfUserExist(user)){
                this.writeToDb(user);
                return "everything is normal";
            }
            return "neeeeeeeeeeeeeeee";
        }
        private void writeToDb(User user){
        List<User> jsonObj =  this.getDb();
            // Open the text file using a stream reader.
    
        jsonObj.Add(user);
        // Set a variable to the Documents path.
        string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine("../holyBoly/db", "usersDb.txt")))
        {
            
                outputFile.WriteLine(JsonSerializer.Serialize(jsonObj));
        }
        }
        private List<User> getDb(){
            List<User> jsonObj;
            List<User> emptyList = new List<User>();
            User emptyUser  = new User {
                FirstName = "",
                LastName = "",
                Email="",
                Password = ""
            };
            emptyList.Add(emptyUser);

             IEnumerable<string> lines = File.ReadLines("db/usersDb.txt");
             Console.WriteLine();
               if(String.Join(Environment.NewLine, lines) != ""){
                    Console.WriteLine("this is not funny bljat" + String.Join(Environment.NewLine, lines) );
                    return jsonObj = JsonSerializer.Deserialize<List<User>>(String.Join(Environment.NewLine, lines));    
                }
                jsonObj =  emptyList;
                return jsonObj;

        }
        private Boolean checkIfUserExist(User user){
            User findedUser = this.findUser(user.Email);

            if(findedUser.Email != ""){
                return true;
            }else{
                return false;
            }
            
        }
        private User findUser(String email){
            List<User> jsonObj =  this.getDb();

            User user = jsonObj.Find((element)=>{
                if(email == element.Email){
                    return true;
                }
                return false;
            });
            
             if(user == null){
                 User emptyUser  = new User {
                    FirstName = "",
                    LastName = "",
                    Email="",
                    Password = ""
                };
                return emptyUser;
            }
            return user;
        }
        // public Item GetItem(Guid id){
        //     return items.Where(item => item.Id == id).SingleOrDefault();
        // }
    }
}