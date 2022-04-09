using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public sealed class OutputData<T> : CoreOutputPort
    {
        public override Color Color { get; } = new Color(1f,.5f,.5f,1f);
        public override Port.Capacity PortCapacity { get; } = Port.Capacity.Multi;
        
        public T Data;

        public void Bind(ref T data)
        {
            Data = data;
        }
    }
}