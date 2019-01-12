using System;
using Boulderdash.Enums;

namespace Boulderdash.app.models
{
    public class HardenedMud : Entity
    {
        private int Health { get; set; } = 2;
        
        public override char GetCharacter()
        {
            return '#';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkGray;
        }

        public override void Destroy(Tile destroyable = null)
        {
            if (--Health <= 0)
            {
                Tile.Level.HardenedMuds.Remove(destroyable);
                destroyable.Entity = new Mud { Tile = destroyable };
            }
        }
    }
}