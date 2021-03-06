using System;
using Krem.AppCore.Interfaces;
using UnityEngine;

namespace Krem.AppCore
{
    [Serializable]
    public class SerializedNodeData
    {
        public string NodeTypeName;
        public string AssemblyName;
        public string SerializedData;

        public SerializedNodeData(ICoreNode node)
        {
            NodeTypeName = node.GetType().FullName;
            AssemblyName = node.GetType().Assembly.GetName().Name;
            SerializedData = JsonUtility.ToJson(node);
        }

        public ICoreNode Deserialize()
        {
            ICoreNode result = Activator.CreateInstance(AssemblyName, NodeTypeName).Unwrap() as ICoreNode;
            JsonUtility.FromJsonOverwrite(SerializedData, result);

            return result;
        }
    }
}