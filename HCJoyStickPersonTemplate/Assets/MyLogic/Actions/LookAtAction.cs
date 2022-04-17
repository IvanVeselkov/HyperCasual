using Krem.AppCore.Attributes;
using Krem.AppCore.Basis.Components.Links;
using Krem.AppCore.Joystick.Components;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    public class LookAtAction : CoreAction
    {

        [InjectComponent] private TransformMovable _transformMovable;
        [InjectComponent] private TransformLink _transformComponent;

        private Vector3 _LookAtVector = Vector3.zero;
        protected override bool Action()
        {
            _LookAtVector.x = _transformMovable.InputAxis.Axis.x * _transformMovable.sensitivity * Time.deltaTime;
            _LookAtVector.z = _transformMovable.InputAxis.Axis.y * _transformMovable.sensitivity * Time.deltaTime;
            _LookAtVector.y = 0;
            _LookAtVector += _transformComponent.Transform.position;
            _transformComponent.Transform.LookAt(_LookAtVector);
            return true;
        }
        
    }
}
