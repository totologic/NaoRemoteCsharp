using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaoRemote
{

    public class ALMotion : PrxMotion
    {

        private PrxMotion _postInstance;

        public ALMotion(NaoRemoteModule naoModule) : base(naoModule, false)
        {
            _postInstance = new PrxMotion(naoModule, true);
        }

        public PrxMotion post
        {
            get
            {
                return _postInstance;
            }
        }

    }

}
