using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public sealed class InputComponent<T> : CorePort where T : CoreComponent
    {
        public override Color Color { get; } = new Color(.5f,.5f,1f,1f);
        public override Port.Capacity PortCapacity { get; } = Port.Capacity.Single;
        
        public T Component;

        public void Bind(ref T component)
        {
            Component = component;
        }
    }
}