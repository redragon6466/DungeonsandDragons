using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Mechanics.Enumerations;

namespace DNDSim.Mechanics.Interfaces
{
    public interface IAlignment
    {
        string getAlignment { get; }

        MoralAllignment getMoral { get; }

        EthicalAllignment getEthic { get; }
    }
}
