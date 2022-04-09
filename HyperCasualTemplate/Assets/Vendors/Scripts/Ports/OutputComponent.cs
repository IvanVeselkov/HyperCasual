using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public sealed class OutputComponent : CoreOutputPort
    {
        public override Color Color { get; } = new Color(.5f,.5f,1f,1f);
        public override Port.Capacity PortCapacity { get; } = Port.Capacity.Multi;
    }
}