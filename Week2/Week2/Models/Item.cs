using System;
using Week2.Controllers;

namespace Week2.Models
{

    /* This class is for items that a Character type can use and a Monster type can drop
     * The items are stored in the DB and can be fetched and updated as the game is running
     * The system supports CRUDi operations for the items
     * When Monsters die, they drop items into the Items Pool for the Battle 
     */


    public class Item : Entity<Item>
    {


        // Enum of the different attributes that the item modifies, Items can only modify one item
        public AttributeEnum Attribute { get; set; }

        // The Value item modifies.  So a ring of Health +3, has a Value of 3
        public int Value { get; set; }

        // Inheritated properties
        // Id comes from BaseEntity class
        // Name comes from the Entity class... 
        // Description comes from the Entity class
        // ImageURI comes from the Entity class

        public Item()
        {
            CreateDefaultItem();
        }

        // Create a default item for the instantiation
        private void CreateDefaultItem()
        {
            Name = "Unknown";
            Description = "Unknown";
            ImageURI = ItemsController.DefaultImageURI;


            Value = 0;
            Attribute = AttributeEnum.Unknown;

            ImageURI = null;
        }

        // Helper to combine the attributes into a single line, to make it easier to display the item as a string
        public string FormatOutput()
        {
            var myReturn = Name + " , " +
                            Description + " with " +
                            Attribute.ToString() +
                            "+" + Value;

            return myReturn.Trim();
        }

        public Item(Item data)
        {
            Update(data);
        }

        // Constructor for Item called if needed to create a new item with set values.
        public Item(string name, string description, string imageuri, int value, AttributeEnum attribute)
        {
            // Create default, and then override...
            CreateDefaultItem();

            Name = name;
            Description = description;
            ImageURI = imageuri;

            Value = value;
            Attribute = attribute;
        }

        // Update for Item, that will update the fields one by one.
        public void Update(Item newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            Value = newData.Value;
            Attribute = newData.Attribute;
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
        }

        // Can potentially implement the items to Scale to Level with Character (e.g Crawl app)
        // public void ScaleLevel(int level)
    }
}