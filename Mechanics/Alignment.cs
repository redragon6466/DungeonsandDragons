using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Mechanics.Enumerations;
using DNDSim.Mechanics.Interfaces;

namespace DNDSim.Mechanics
{
    public class Alignment : IAlignment
    {
        private MoralAllignment _moral;
        private EthicalAllignment _ethic;

        public Alignment(MoralAllignment moral, EthicalAllignment ethic)
        {
            _moral = moral;
            _ethic = ethic;
        }
            
        public string getAlignment
        {
            get
            {
                return getMoral.ToString() + getEthic.ToString();
            }
        }

        public EthicalAllignment getEthic
        {
            get
            {
                return _ethic;
            }
        }

        public MoralAllignment getMoral
        {
            get
            {
                return _moral;
            }
        }
    }
}
