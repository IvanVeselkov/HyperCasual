using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public sealed class InputSignal : CorePort
    {
        public override Color Color { get; } = Color.green;
        public override Port.Capacity PortCapacity { get; } = Port.Capacity.Multi;
        
        public Action InvokeAction;

        public void Invoke()
        {
            InvokeAction?.Invoke();
        }
    }
}