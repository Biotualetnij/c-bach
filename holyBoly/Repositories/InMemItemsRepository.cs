using System.Collections.Generic;
using holyBoly.Entities;
using System.IO;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace holyBoly.Repositories
{
    public class InMemItemsRepository{
     
        
        public IEnumerable<Item> GetItems(){
            return this.getDb();
        }

        public Message createItem(Item item){
            if(!this.checkIfFieldsAreEmpty(item)){
             return new Message {message="some required fields are empty or has inncorect value", auth=false};
            }
            this.writeToDb(item);
            return new Message {message="you have create item", auth=true};
        }
        private Boolean checkIfFieldsAreEmpty(Item item){
            if(item.Name == "" || item.Price <= 0){
                return false;
            }
            return true;
        }
        private void writeToDb(Item item){
        List<Item> jsonObj =  this.getDb();
            // Open the text file using a stream reader.
    
        jsonObj.Add(item);
        // Set a variable to the Documents path.
        string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine("../holyBoly/db", "itemDb.txt")))
        {
            
                outputFile.WriteLine(JsonSerializer.Serialize(jsonObj));
        }
        }
        private List<Item> getDb(){
            List<Item> jsonObj;
            List<Item> emptyList = new List<Item>();
            Item emptyItem  = new Item {
              Name = "erge",
                Price = 0, 
                CreatedDate = DateTimeOffset.UtcNow,
                 Description= "",
                ImageUrl="",
            };
            emptyList.Add(emptyItem);

             IEnumerable<string> lines = File.ReadLines("db/itemDb.txt");
             Console.WriteLine();
               if(String.Join(Environment.NewLine, lines) != ""){
                    Console.WriteLine("this is not funny bljat" + String.Join(Environment.NewLine, lines) );
                    return jsonObj = JsonSerializer.Deserialize<List<Item>>(String.Join(Environment.NewLine, lines));    
                }
                jsonObj =  emptyList;
                return jsonObj;

        }

        // public Item GetItem(Guid id){
        //     return items.Where(item => item.Id == id).SingleOrDefault();
        // }
    }
}