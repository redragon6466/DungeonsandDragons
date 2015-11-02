using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDSim.Characters.EventArgs
{
    public class MessageEventArgs
    {
        public MessageEventArgs(string msg)
        {
            Message = msg;
        }

        public String Message { get; private set; }
    }
}
