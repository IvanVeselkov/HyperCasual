using System.Diagnostics.CodeAnalysis;
using Krem.AppCore.Attributes;
using UnityEngine;
using Krem.AppCore;

namespace platypus.logic
{
    [NodeGraphGroupName("platypus/logic")]
    [DisallowMultipleComponent]
    public class CircleParametersComponent : CoreComponent
    {
        [Header("Dependencies")]
        [SerializeField, NotNull] protected float _r;
        [SerializeField, NotNull, Range(-1, 1)] protected int _sign;
        [SerializeField, NotNull] protected float _speed;
        public float R => _r;
        public int Signature => _sign;

        public float Speed => _speed;
    }
}