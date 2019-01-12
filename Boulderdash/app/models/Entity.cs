﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulderdash.Enums;

namespace Boulderdash.app.models
{
    public abstract class Entity : Tile
    {
        public Tile Tile { get; set; }
                
        public abstract char GetCharacter();

        public abstract ConsoleColor GetColor();

        public virtual void Move(Tile from, Tile to = null) { }
        
        public virtual void Destroy(Tile destroyable = null)
        {
            //If rockford is destroyed, you lose the game
            if (destroyable.Is<Rockford>())
                Tile.Level.Lost = true;
            
            //If a moveable is destroyed, remove it from the moveables list
            if (destroyable.Is<Moveable>())
                Tile.Level.Moveables.Remove(Tile.Level.Moveables.Find(m => m.Entity == destroyable.Entity));
            
            //Only anything other than a steelwall or exit can be destroyed
            if (!destroyable.Is<Steelwall>() || !destroyable.Is<Exit>())
            {
                destroyable.Entity = new Air();
                destroyable.Entity.Destroy();
            }
        }
        
        //Explode entities within a blast radius
        public void Explode(Tile center, int blastRadius = 3)
        {    
            if (--blastRadius > 0)
            {
                Explode(center.Left, blastRadius);
                Explode(center.Right, blastRadius);    
                Explode(center.Top, blastRadius);
                Explode(center.Bottom, blastRadius);
            }
            
            Destroy(center);
        }
    }
}
