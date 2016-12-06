using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaoRemote
{

    public class PrxBehaviorManager
    {

        private const String MODULE_NAME = "ALBehaviorManager";
        private NaoRemoteModule _naoModule;
        private Boolean _isPost;

        public PrxBehaviorManager(NaoRemoteModule naoModule, Boolean isPost)
        {
            _naoModule = naoModule;
            _isPost = isPost;
        }

        public void AddDefaultBehavior(String prefixedBehavior)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "addDefaultBehavior", prefixedBehavior);
        }

        public List<String> GetInstalledBehaviors()
        {
            return _naoModule.Eval<List<String>>(MODULE_NAME, _isPost, "getInstalledBehaviors");
        }

        public List<String> GetRunningBehaviors()
        {
            return _naoModule.Eval<List<String>>(MODULE_NAME, _isPost, "getRunningBehaviors");
        }

        public List<String> GetSystemBehaviorNames()
        {
            return _naoModule.Eval<List<String>>(MODULE_NAME, _isPost, "getSystemBehaviorNames");
        }

        public Boolean InstallBehavior(String absolutePath, String localPath, Boolean overwrite)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "installBehavior", absolutePath, localPath, overwrite);
        }

        public Boolean InstallBehavior(String localPath)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "installBehavior", localPath);
        }

        public Boolean IsBehaviorInstalled(String name)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "isBehaviorInstalled", name);
        }

        public Boolean IsBehaviorRunning(String name)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "IsBehaviorRunning", name);
        }

        public Boolean PreloadBehavior(String name)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "preloadBehavior", name);
        }

        public Boolean RemoveBehavior(String name)
        {
            return _naoModule.Eval<Boolean>(MODULE_NAME, _isPost, "removeBehavior", name);
        }

        public void RemoveDefaultBehavior(String name)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "removeDefaultBehavior");
        }

        public void RunBehavior(String name)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "runBehavior", name);
        }

        public void StopAllBehaviors()
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stopAllBehaviors");
        }

        public void StopBehavior(String name)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stopBehavior", name);
        }

    }

}
