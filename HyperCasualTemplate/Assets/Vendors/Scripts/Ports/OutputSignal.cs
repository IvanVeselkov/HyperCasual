using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public sealed class OutputSignal : CoreOutputPort
    {
        public override Color Color { get; } = Color.green;
        public override Port.Capacity PortCapacity { get; } = Port.Capacity.Multi;
        
        public event Action InvocationList;

        public void Invoke()
        {
            InvocationList?.Invoke();
        }

        public void AddListener(Action listener)
        {
            InvocationList += listener;
        }

        public void RemoveListener(Action listener)
        {
            InvocationList -= listener;
        }
    }
}