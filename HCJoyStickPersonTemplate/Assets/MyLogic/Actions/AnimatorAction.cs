using Krem.AppCore.Attributes;
using Krem.AppCore.Basis.Components.Links;
using Krem.AppCore.Joystick.Components;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    public class AnimatorAction : CoreAction
    {
        [InjectComponent] private AnimatorComponent _animComponent;
        [InjectComponent] private TransformMovable _transformMovable;


        private bool ItIsMoving()
        {
            if(_transformMovable.InputAxis.Axis.x!=0 || _transformMovable.InputAxis.Axis.y!=0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        protected override bool Action()
        {
            if(ItIsMoving())
            {
                _animComponent.Animator.SetInteger("AnimationPar", 1);
            }
            else
            {
                _animComponent.Animator.SetInteger("AnimationPar", 0);
            }

            return true;
        }
    }
}
