using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    [TypeConverter(typeof(ItemTypeConverter))]
    public class Item
    {
        [Required (ErrorMessage = "Level is required.")]
        [Range (1,99, ErrorMessage = "Value must be between 1 and 99")]
        public int _level {get; set;}
        [Required (ErrorMessage = "Type is required")]
        public ItemType _type {get; set;}
        [Required (ErrorMessage = "Creation date is required.")]
        public DateTime _creationDate {get; set;}

        public Guid _itemId {get; set;}

        public Item (int level, ItemType type, DateTime creation, Guid id)
        {
            _level = level;
            _type = type;
            _creationDate = creation;
            _itemId = id;
        }

        public override string ToString()
        {
            string s = _type.ToString() + ", lvl. " + _level + " (created: " + _creationDate + ") " + _itemId;
            return s;
        }


    }

    public class NewItem
    {
        [Required]
        [Range (1,99)]
        public int _level {get; set;}
        [Required]
        public ItemType _type {get; set;}
        [Required]
        public DateTime _creationDate {get; set;}

        public Guid _itemId {get; set;}
    }

    public class ModifiedItem
    {
        [Required]
        [Range (1,99)]
        public int _level {get; set;}
        public Guid _itemId {get; set;}

    }
}