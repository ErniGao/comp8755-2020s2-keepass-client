using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeePassLib.Shamir
{
    public class Shares 
    {
        List<int> sharesPresent;

        public Shares(List<int> sharesPresent)
        {
            this.sharesPresent = sharesPresent;
        }
       
        public List<int> GetShares()
        {
            return sharesPresent;
        }
    }
}
