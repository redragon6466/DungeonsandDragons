using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Main.Enumerations;

namespace DNDSim.Characters.EventArgs
{
    public class PlayerActionEventArgs
    {
        public PlayerActionEventArgs(PlayerActionEnum action)
        {
            Action = action;
        }

        public PlayerActionEnum Action{ get; private set; }
    }
}
