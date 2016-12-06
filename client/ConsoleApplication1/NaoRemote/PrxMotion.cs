using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaoRemote
{

    public class PrxMotion
    {

        private const String MODULE_NAME = "ALMotion";
        private NaoRemoteModule _naoModule;
        private Boolean _isPost;

        public PrxMotion(NaoRemoteModule naoModule, Boolean isPost)
        {
            _naoModule = naoModule;
            _isPost = isPost;
        }





            /////////////////////////////////////
            /// /// Cartesian control API /// ///
            /////////////////////////////////////

        public void PositionInterpolation(String chainName, int space, List<double> position, int axisMask, double duration, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "positionInterpolation", chainName, space, position, axisMask, duration, isAbsolute);
        }

        public void PositionInterpolation(String chainName, int space, List<List<double>> path, int axisMask, List<double> durations, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "positionInterpolation", chainName, space, path, axisMask, durations, isAbsolute);
        }

        public void PositionInterpolations(List<String> effectorNames, int taskSpaceForAllPaths, List<List<List<double>>> paths, List<int> axisMasks, List<List<double>> relativeTimes, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "positionInterpolations", effectorNames, taskSpaceForAllPaths, paths, axisMasks, relativeTimes, isAbsolute);
        }

        public void SetPosition(String chainName, int space, List<double> position, double fractionMaxSpeed, int axisMask)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setPosition", chainName, space, position, fractionMaxSpeed, axisMask);
        }

        public void ChangePosition(String effectorName, int space, List<double> positionChange, double fractionMaxSpeed, int axisMask)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "changePosition", effectorName, space, positionChange, fractionMaxSpeed, axisMask);
        }

        public List<double> GetPosition(String name, int space, Boolean useSensorValues)
        {
            return _naoModule.Eval<List<double>>(MODULE_NAME, _isPost, "getPosition", name, space, useSensorValues);
        }

        public void TransformInterpolation(String chainName, int space, List<double> transform, int axisMask, double duration, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "transformInterpolation", chainName, space, transform, axisMask, duration, isAbsolute);
        }

        public void TransformInterpolation(String chainName, int space, List<List<double>> path, int axisMask, List<double> durations, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "transformInterpolation", chainName, space, path, axisMask, durations, isAbsolute);
        }

        public void TransformInterpolations(List<String> effectorNames, int taskSpaceForAllPaths, List<List<List<double>>> paths, List<int> axisMasks, List<List<double>> durations, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "transformInterpolations", effectorNames, taskSpaceForAllPaths, paths, axisMasks, durations, isAbsolute);
        }

        public void SetTransform(String chainName, int space, List<double> transform, double fractionMaxSpeed, int axisMask )
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setTransform", space, transform, fractionMaxSpeed, axisMask);
        }

        public void ChangeTransform(String chainName, int space, List<double> transform, double fractionMaxSpeed, int axisMask)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "changeTransform", space, transform, fractionMaxSpeed, axisMask);
        }

        public List<double> GetTransform(String name, int space, Boolean useSensorValues)
        {
            return _naoModule.Eval<List<double>>(MODULE_NAME, _isPost, "getTransform", name, space, useSensorValues);
        }




            /////////////////////////////////
            /// /// General tools API /// ///
            /////////////////////////////////







            /////////////////////////////////
            /// /// Joint control API /// ///
            /////////////////////////////////

        public void AngleInterpolation(String name, double angle, double time, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolation", name, angle, time, isAbsolute);
        }

        public void AngleInterpolation(String name, List<double> angles, List<double> times, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolation", name, angles, times, isAbsolute);
        }

        public void AngleInterpolation(List<String> names, List<List<double>> angles, List<List<double>> times, Boolean isAbsolute)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolation", names, angles, times, isAbsolute);
        }

        public void AngleInterpolationWithSpeed(String name, double targetAngle, double maxSpeedFraction)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolationWithSpeed", name, targetAngle, maxSpeedFraction);
        }

        public void AngleInterpolationWithSpeed(List<String> names, List<double> targetAngles, double maxSpeedFraction)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolationWithSpeed", names, targetAngles, maxSpeedFraction);
        }

        public void AngleInterpolationWithSpeed(String name, List<double> targetAngles, double maxSpeedFraction)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolationWithSpeed", name, targetAngles, maxSpeedFraction);
        }

        public void AngleInterpolationBezier(List<String> jointNames, List<List<double>> times, List<List<List<Object>>> controlPoints)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "angleInterpolationBezier", jointNames, times, controlPoints);
        }

        public void SetAngles(String name, double angle, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setAngles", name, angle, fractionMaxSpeed);
        }

        public void SetAngles(List<String> names, List<double> angles, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setAngles", names, angles, fractionMaxSpeed);
        }

        public void SetAngles(String name, List<double> angles, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setAngles", name, angles, fractionMaxSpeed);
        }

        public void ChangeAngles(String name, double change, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "changeAngles", name, change, fractionMaxSpeed);
        }

        public void ChangeAngles(List<String> names, List<double> changes, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "changeAngles", names, changes, fractionMaxSpeed);
        }

        public void ChangeAngles(String name, List<double> changes, double fractionMaxSpeed)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "changeAngles", name, changes, fractionMaxSpeed);
        }

        public List<double> GetAngles(String name, Boolean useSensors)
        {
            return _naoModule.Eval<List<double>>(MODULE_NAME, _isPost, "getAngles", name, useSensors);
        }

        public List<double> GetAngles(List<String> names, Boolean useSensors)
        {
            return _naoModule.Eval<List<double>>(MODULE_NAME, _isPost, "getAngles", names, useSensors);
        }

        public void CloseHand(String handName)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "closeHand", handName);
        }

        public void OpenHand(String handName)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "openHand", handName);
        }





        //////////////////////////////////////
        /// /// Stiffness  control API /// ///
        //////////////////////////////////////

        public void WakeUp()
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "wakeUp");
        }

        public void Rest()
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "rest");
        }

        public void StiffnessInterpolation(String name, double stiffness, double time)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stiffnessInterpolation", name, stiffness, time);
        }

        public void StiffnessInterpolation(String name, List<double> listStiffness, List<double> times)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stiffnessInterpolation", name, listStiffness, times);
        }

        public void StiffnessInterpolation(List<String> names, List<double> listStiffness, List<double> times)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stiffnessInterpolation", names, listStiffness, times);
        }

        public void StiffnessInterpolation(List<String> names, List<List<double>> listStiffness, List<List<double>> times)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "stiffnessInterpolation", names, listStiffness, times);
        }

        public void SetStiffnesses(String name, double stiffness)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setStiffnesses", name, stiffness);
        }

        public void SetStiffnesses(List<String> names, List<double> listStiffness)
        {
            _naoModule.Eval<Object>(MODULE_NAME, _isPost, "setStiffnesses", names, listStiffness);
        }

        public double getStiffnesses(String name)
        {
            return _naoModule.Eval<double>(MODULE_NAME, _isPost, "getStiffnesses", name);
        }

        public List<double> getStiffnesses(List<String> names)
        {
            return _naoModule.Eval<List<double>>(MODULE_NAME, _isPost, "getStiffnesses", names);
        }

    }

}
