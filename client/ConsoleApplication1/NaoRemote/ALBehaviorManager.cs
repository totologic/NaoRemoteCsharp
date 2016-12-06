using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaoRemote
{

    public class ALBehaviorManager : PrxBehaviorManager
    {

        private PrxBehaviorManager _postInstance;

        public ALBehaviorManager(NaoRemoteModule naoModule) : base(naoModule, false)
        {
            _postInstance = new PrxBehaviorManager(naoModule, true);
        }

        public PrxBehaviorManager post
        {
            get
            {
                return _postInstance;
            }
        }



    }

}
