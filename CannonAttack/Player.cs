using System;
using System.Collections.Generic;
using System.Text;

namespace CannonAttack
{
    public class Player
    {
        public string Id { get; set; }
        public Player()
        {
            this.Id = "Human";
        }
        public Player(string custom_Id) 
        {
            this.Id = custom_Id;
        }
    }
}
