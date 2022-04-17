using System.Diagnostics.CodeAnalysis;
using Krem.AppCore.Attributes;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    [DisallowMultipleComponent]
    public class AnimatorComponent : CoreComponent
    {
        [Header("Dependencies")]
        [SerializeField, NotNull] protected Animator _animator;

        public Animator Animator => _animator;
    }
}