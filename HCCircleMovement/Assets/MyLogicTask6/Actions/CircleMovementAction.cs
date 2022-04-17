using Krem.AppCore.Attributes;
using Krem.AppCore.Basis.Components.Links;
using Krem.AppCore.Joystick.Components;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    public class CircleMovementAction : CoreAction
    {

        [InjectComponent] private TransformHandler _transformHandler;
        [InjectComponent] private CircleParametersComponent _circleParametersComponent;

        private float _correctAngle = 0;

        private Vector3 FindNewCirclePoint()
        {
            Vector3 vec = new Vector3(_circleParametersComponent.R * _circleParametersComponent.Signature * Mathf.Sin(_correctAngle), 0.5f, _circleParametersComponent.R * _circleParametersComponent.Signature * Mathf.Cos(_correctAngle));

            if (_correctAngle > 2 * Mathf.PI)
            {
                _correctAngle = 0;
            }
            else
            {
                _correctAngle += _circleParametersComponent.Speed;
            }
            return vec;
        }
        protected override bool Action()
        {
            _transformHandler.Transform.position = FindNewCirclePoint();


            return true;
        }

    }
}