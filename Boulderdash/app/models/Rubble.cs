using System;

namespace Boulderdash.app.models
{
    public class Rubble : Moveable
    {
        public override char GetCharacter()
        {
            return '*';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }
    }
}