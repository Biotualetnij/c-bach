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
        public Message signUp(User user){
            if(!this.checkIfUserExist(user)){
                this.writeToDb(user);
                return new Message {message="You have registered", auth=true,userData=new UserInfo{FirstName=user.FirstName,LastName=user.LastName,Email=user.Email,State=user.State,Phone=user.Phone,Password=user.Password}};
            }
            return new Message {message="This user exist", auth=false,userData=new UserInfo{}};
        }
        public Message login(User user){
           var userToCheck = this.findUser(user.Email);
           
           if(userToCheck.Email== ""){
               return new Message {message="you have incorrect password or email", auth=false,userData=new UserInfo{}};
           }
           if(user.Password == userToCheck.Password){
               return new Message {message="you have login", auth=true,userData=new UserInfo{FirstName=userToCheck.FirstName,LastName=userToCheck.LastName,Email=userToCheck.Email,State=userToCheck.State,Phone=userToCheck.Phone,Password=userToCheck.Password}};
           }
            return new Message {message="you have incorrect password or email", auth=false,userData=new UserInfo{}}; 
        }
        public Message updateProfile(User user){
             var userToCheck = this.findUser(user.Email);

           if(userToCheck.Email== ""){
               return new Message {message="you have incorrect password or email", auth=false,userData=new UserInfo{}};
           }
           if(user.Password == userToCheck.Password){

            this.updateUserDb(user);
            return new Message {message="Profile have been changed",auth=true,userData=new UserInfo{FirstName=user.FirstName,LastName=user.LastName,Email=user.Email,State=user.State,Phone=user.Phone,Password=userToCheck.Password}};
           }
            return new Message {message="you are not loginin",auth=true,userData=new UserInfo{}};
        }
        public Message changePassword(UserInfoCP user){
                var userToCheck = this.findUser(user.Email);

           if(userToCheck.Email== ""){
               return new Message {message="you have incorrect password or email", auth=false,userData=new UserInfo{}};
           }
           if(user.Password == userToCheck.Password){

            this.updateUserPasswordDb(user);
            return new Message {message="Profile have been changed",auth=true,userData=new UserInfo{FirstName=user.FirstName,LastName=user.LastName,Email=user.Email,State=user.State,Phone=user.Phone,Password=userToCheck.Password}};
           }
            return new Message {message="you are not loginin",auth=true,userData=new UserInfo{}};

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
        private void updateUserDb( User user){
             List<User> jsonObj =  this.getDb();
             var infex = 0;
             for(int i = 0 ; i < jsonObj.Count;i++){
                 if(jsonObj[i].Email == user.Email){
                     jsonObj[i].State = user.State;
                     jsonObj[i].Phone = user.Phone;
                    jsonObj[i].Password = user.Password;
                 }
             }
                string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine("../holyBoly/db", "usersDb.txt")))
        {
            
                outputFile.WriteLine(JsonSerializer.Serialize(jsonObj));
        }
        
        }
          private void updateUserPasswordDb( UserInfoCP user){
             List<User> jsonObj =  this.getDb();
             var infex = 0;
             for(int i = 0 ; i < jsonObj.Count;i++){
                 if(jsonObj[i].Email == user.Email){

                    jsonObj[i].Password = user.newPassword;
                 }
             }
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