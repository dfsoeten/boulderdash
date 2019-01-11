using System;
using Boulderdash.Enums;

namespace Boulderdash.app.models
{
    public class HardenedMud : Entity
    {
        public override char GetCharacter()
        {
            return '#';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkGray;
        }

        public override void Destroy()
        {
            Tile.Level.Moveables.Remove(Tile);
        }
    }
}