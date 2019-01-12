using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Mud : Entity
    {
        public override char GetCharacter()
        {
            return '#';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }
    }
}
