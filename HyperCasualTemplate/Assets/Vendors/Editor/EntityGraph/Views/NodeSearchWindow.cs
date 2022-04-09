using System;
using System.Collections.Generic;
using System.Reflection;
using Krem.AppCore.Attributes;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Krem.AppCore.EntityGraph.Views
{
    public class NodeSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        private Action<Type> _createDelegate;

        public void Init(Action<Type> createDelegate)
        {
            _createDelegate = createDelegate;
        }
        
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            var tree = new List<SearchTreeEntry>
            {
                new SearchTreeGroupEntry(new GUIContent("Actions"), 0)
            };

            var actionTypes = TypeCache.GetTypesDerivedFrom<CoreAction>();

            var groups = new HashSet<string>();
            foreach (var type in actionTypes)
            {
                string groupName = "...";
                if (type.GetCustomAttribute<NodeGraphGroupNameAttribute>() != null)
                    groupName = type.GetCustomAttribute<NodeGraphGroupNameAttribute>().GroupName;
                
                groups.Add(groupName);
            }
            
            foreach (var groupName in groups)
            {
                tree.Add(new SearchTreeGroupEntry(new GUIContent(groupName), 1));

                foreach (var type in actionTypes)
                {
                    var tempGroupName = "...";
                    if (type.GetCustomAttribute<NodeGraphGroupNameAttribute>() != null)
                        tempGroupName = type.GetCustomAttribute<NodeGraphGroupNameAttribute>().GroupName;

                    if (tempGroupName == groupName)
                    {
                        tree.Add(new SearchTreeEntry(new GUIContent($"{type.Name}"))
                        {
                            level = 2,
                            userData = type.AssemblyQualifiedName
                        });
                    }
                }
            }

            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            var typeName = (string)searchTreeEntry.userData;
            _createDelegate.Invoke(Type.GetType(typeName));
            return true;
        }
    }
}