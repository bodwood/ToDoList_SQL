using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
    public class Item
    {
        public string Description { get; set; }
        public int Id { get; }


        public Item(string description)
        {
            Description = description;

        }

        public Item(string description, int id){
          Description = description;
          Id = id;
        }

        public static List<Item> GetAll()
        {
            List<Item> allItems = new List<Item> { }; //make new list of item objects

            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString); //MySqlConnection object returns a connection
            conn.Open();  //opening sql connection

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;  //creates sql command query
            cmd.CommandText = "SELECT * FROM items;"; //this is what the command is set to

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader; //data reader
            while (rdr.Read())  //reads results from database one at a time
            {
                int itemId = rdr.GetInt32(0); //int at the 0nth index of the array returned by the reader
                string itemDescription = rdr.GetString(1);  //returns strings
                Item newItem = new Item(itemDescription, itemId); //each row in database is an Item stored in this list
                allItems.Add(newItem);
            }
            conn.Close(); //close connection
            if (conn != null)
            {
                conn.Dispose();   //disposes connection
            }
            return allItems;
        }

        public static void ClearAll()
        {

        }
        public static Item Find(int searchId)
        {
            Item placeholderItem = new Item("placeholder item");
            return placeholderItem;

        }
    }
}
