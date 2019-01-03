using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Tile : Level
    {
        public Entity Entity { get; set; }

        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }
        public Tile Left { get; set; }

        public char Character => Entity.GetCharacter();

        public ConsoleColor Color => Entity.GetColor();

        //Destroy Entities in a certain radius
        public void Explode(Tile center)
        {
            //Top three Entities
            center.Left.Top.Entity.Destroy(center.Left.Top);
            center.Top.Entity.Destroy(center.Top);
            center.Right.Top.Entity.Destroy(center.Right.Top);

            //Middle three
            center.Left.Entity.Destroy(center.Left);
            center.Entity.Destroy(center);
            center.Right.Entity.Destroy(center.Right);

            //Bottom three Entities
            center.Left.Bottom.Entity.Destroy(center.Left.Bottom);
            center.Bottom.Entity.Destroy(center.Bottom);
            center.Right.Bottom.Entity.Destroy(center.Right.Bottom);
        }

        //Check if entity is a SteelWall
        public bool IsSteelWall()
        {
            return Entity is Steelwall;
        }

        //Check if entity is a Wall
        public bool IsWall()
        {
            return Entity is Wall;
        }

        //Check if entity is Mud
        public bool IsMud()
        {
            return Entity is Mud;
        }

        //Check if entity is a Diamond
        public bool IsDiamond()
        {
            return Entity is Diamond;
        }

        //Check if entity is a Boulder
        public bool IsBoulder()
        {
            return Entity is Boulder;
        }

        //Check if entity is Air
        public bool IsAir()
        {
            return Entity is Air;
        }

        //Check if entity is RockFord
        public bool IsRockford()
        {
            return Entity is Rockford;
        }

        //Check if entity is a FireFly
        public bool IsFireFly()
        {
            return Entity is Firefly;
        }
    }
}
