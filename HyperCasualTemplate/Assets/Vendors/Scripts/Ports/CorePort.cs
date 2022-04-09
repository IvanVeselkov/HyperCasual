using System;
using Krem.AppCore.Attributes;
using Krem.AppCore.Interfaces;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.Ports
{
    [Serializable]
    public class CorePort : ICorePort
    {
        [SerializeField][InspectorReadOnly] protected string _parentID;
        [SerializeField][InspectorReadOnly] protected string _portID;
        
        public string ParentID { get => _parentID; set => _parentID = value; }
        public string PortID { get => _portID; set => _portID = value; }
        public virtual Color Color { get; } = Color.gray;
        public virtual Port.Capacity PortCapacity { get; } = Port.Capacity.Single;

        public CorePort()
        {
            PortID = Guid.NewGuid().ToString();
        }

        public CorePort(ICoreNode parent)
        {
            PortID = Guid.NewGuid().ToString();
            ParentID = parent.NodeID;
        }

        public CorePort(string parentID, string portID)
        {
            _parentID = parentID;
            _portID = portID;
        }
    }
}