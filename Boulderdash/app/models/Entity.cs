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

        public virtual void Destroy() { }
        
        public virtual void Move(Tile @from, Tile to = null) { }

        public virtual void Interact() { }
    }
}
