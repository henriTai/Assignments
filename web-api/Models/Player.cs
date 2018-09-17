using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace web_api.Models

{
    [TypeConverter(typeof(PlayerTypeConverter))]
    public class Player
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public int Score {get; set;}

        public int level;
        public bool IsBanned {get; set;}

        public List<Item> items;
        public DateTime CreationTime {get; set;}
    }

    [TypeConverter(typeof(NewPlayerTypeConverter))]
    public class NewPlayer
    {
        public string Name {get; set;}
        public NewPlayer(string name) { this.Name = name; }
    }

    [TypeConverter(typeof(ModifiedPlayerTypeConverter))]
    public class ModifiedPlayer
    {
        public int Score {get; set;}

        public ModifiedPlayer() {}
    }
}