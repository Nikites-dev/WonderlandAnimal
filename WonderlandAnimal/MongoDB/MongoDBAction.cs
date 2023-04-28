using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WonderlandAnimal.Models;


namespace WonderlandAnimal.MongoDB
{
  public class MongoDBAction
    {
        // public static void AddToDatabase(Account account)
        // {
        //     var client = new MongoClient("mongodb://uwsxumz5nuroddcwz6ap:l6fmrK3bw8Qh1kzekE44@n1-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017,n2-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017/bdmjygryz3sofqt?replicaSet=rs0");
        //     var database = client.GetDatabase("Wanimal");
        //     
        //     
        //     var collection = database.GetCollection<Account>("Accounts");
        //     collection.InsertOne(account);
        // }
        
        // public static CharacterDb UnitToCharacter(String name, Unit unit)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     CharacterDb db = new CharacterDb(
        //         name,
        //         unit.GetType().Name,
        //         unit.CurrentStrensth, 
        //         unit.CurrentDesterity,
        //         unit.CurrentConstitution,
        //         unit.CurrentIntellisense,
        //         unit.Inventory,
        //         unit.Exp,
        //         unit.Equipments);
        //     
        //    return db;
        // }
        //
        public static Account FindByName(String email, String password)
        {
            var client = new MongoClient("mongodb://uwsxumz5nuroddcwz6ap:l6fmrK3bw8Qh1kzekE44@n1-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017,n2-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017/bdmjygryz3sofqt?replicaSet=rs0");
            var database = client.GetDatabase("Wanimal");
            var collection = database.GetCollection<Account>("Accounts");
            Account account = collection.Find(x => x.Email  == email).FirstOrDefault();
            

            if (account == null)
            {
                return null;
            }

            // if (account.Password == password)
            // {
            //     return account;
            // }
             return null;
        }
        
        // public static Account FindById(int? id)
        // {
        //     var client = new MongoClient("mongodb://uwsxumz5nuroddcwz6ap:l6fmrK3bw8Qh1kzekE44@n1-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017,n2-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017/bdmjygryz3sofqt?replicaSet=rs0");
        //     var database = client.GetDatabase("Wanimal");
        //     var collection = database.GetCollection<Account>("Accounts");
        //     Account account = collection.Find(x => x._id  == id).FirstOrDefault();
        //     
        //
        //     if (account == null)
        //     {
        //         return null;
        //     }
        //     return account;
        // }



        public static int GetLastAccountId()
        {
            var client = new MongoClient("mongodb://uwsxumz5nuroddcwz6ap:l6fmrK3bw8Qh1kzekE44@n1-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017,n2-c2-mongodb-clevercloud-customers.services.clever-cloud.com:27017/bdmjygryz3sofqt?replicaSet=rs0");
            var database = client.GetDatabase("Wanimal");
            var collection = database.GetCollection<Account>("Accounts");
            int lastIndx = Convert.ToInt32(collection.Find(x => x.Email  != "").Count());
            return lastIndx;
        }


        //
        //     switch (unit.ClassName)
        //     {
        //         case "Warrior":
        //             return new Warrior(unit.Strength,
        //                 unit.Dexterity,
        //                 unit.Constitution,
        //                 unit.Intellisense,
        //                 unit.Items, 
        //                 unit.Exp, 
        //                 unit.Equipments)
        //             { Name = unit.Name};
        //         
        //         case "Wizard":
        //             return new Wizard(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense,
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         
        //         case "Rogue":
        //             return new Rogue(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense, 
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         default: return null;
        //     }
        //     return null;
        // }
        //
        // public static String DeleteByName(String name)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<Unit>("HeroCollection");
        //     var unit = collection.DeleteOne(x => x.Name == name);
        //     return $"Unit {unit.GetType().Name} is remove!";
        // }
        //
        // public static void ClearDB()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     client.GetDatabase("Warcraft").DropCollectionAsync("HeroCollection");
        // }
        //
        // public static List<String> AddListHeroes()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var strNames = collection.Find<CharacterDb>(x => x.Name != null && x.Name != "")
        //         .ToEnumerable<CharacterDb>();
        //     return strNames.Select(x => x.Name).ToList<String>();
        // }
        //
        // public static void UpdateByName(String name, Unit unit)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var b = collection.ReplaceOne(x => x.Name == name, UnitToCharacter(name, unit)).ModifiedCount > 0;
        // }
    }
}