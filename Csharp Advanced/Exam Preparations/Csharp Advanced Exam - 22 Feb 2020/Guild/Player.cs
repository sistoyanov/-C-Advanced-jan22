using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string _class )
        {
            Name = name;
            Class = _class;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Rank { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        public override string ToString()
        {
            return $"Player {Name}: {Class}{Environment.NewLine}Rank: {Rank}{Environment.NewLine}Description: {Description}".ToString();
        }
    }
}
