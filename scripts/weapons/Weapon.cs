using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapplegunGame.scripts.weapons
{
    public abstract class Weapon : Spatial
    {
        public abstract void PrimaryFire();
        public abstract void SecondaryFire();
        public abstract void TertiaryFire();
        public abstract void Reload();
    }
}
