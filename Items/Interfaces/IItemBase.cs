using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DNDSim.Items.Interfaces
{
    public interface IItemBase
    {
        void Appraise(int appraiseSkill);

        string Name { get; set; }

        int Charges { get; set; }
    }
}
