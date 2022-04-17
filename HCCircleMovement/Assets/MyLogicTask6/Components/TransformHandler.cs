using System.Diagnostics.CodeAnalysis;
using Krem.AppCore.Attributes;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    [DisallowMultipleComponent]
    public class TransformHandler : CoreComponent
    {
        [Header("Dependencies")]
        [SerializeField, NotNull] protected Transform _transform;

        public Transform Transform => _transform;
    }
}