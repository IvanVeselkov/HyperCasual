using Krem.AppCore.Interfaces;
using Krem.AppCore.EntityGraph.Views;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Krem.AppCore.EntityGraph
{
    public sealed class EntityGraph : EditorWindow
    {
        private EntityGraphView _entityGraphView;
        private InspectorView _inspectorView;
        private ICoreGraph _selectedEntity;
        
        [MenuItem("Window/Show EntityGraph")]
        public static void ShowEntityGraph()
        {
            EntityGraph wnd = GetWindow<EntityGraph>();

            if (wnd == null)
            {
                Debug.LogError("Entity Editore Window is Not Created");
                
                return;
            } else if (!wnd.docked)
            {
                wnd.Close();
                wnd = GetWindow<EntityGraph>();
            }
            
            wnd.titleContent = new GUIContent("EntityGraph");
        }

        public void CreateGUI()
        {
            CreateGraphGUI();
            BindEvents();
            PopulateEntityGraph();
        }

        private void CreateGraphGUI()
        {
            VisualElement root = rootVisualElement;
            VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("EntityGraph/EntityGraph");
            visualTree.CloneTree(root);
            
            StyleSheet styleSheet = Resources.Load<StyleSheet>("EntityGraph/USS/EntityGraph");
            root.styleSheets.Add(styleSheet);
            
            _entityGraphView = root.Q<EntityGraphView>();
            _inspectorView = root.Q<InspectorView>();
        }

        private void BindEvents()
        {
            _entityGraphView.OnNodeSelected = OnNodeSelectionChanged;
            _entityGraphView.OnNodeCreated = OnNodeCreated;
            _entityGraphView.OnNodeDeleted = OnNodeDeleted;
            _entityGraphView.OnNodeChanged = OnNodeChanged;
            _entityGraphView.OnEdgeCreated = OnEdgeCreated;
            _entityGraphView.OnEdgeDeleted = OnEdgeDeleted;
            _inspectorView.OnNodeValueChanged = OnNodeChanged;
        }

        private void PopulateEntityGraph()
        {
            ICoreGraph coreEntity = (Selection.activeObject as GameObject)?.GetComponent<ICoreGraph>();
            if (coreEntity != null)
            {
                _selectedEntity = coreEntity;
                _entityGraphView.PopulateView(_selectedEntity);
            }
        }

        private void OnNodeSelectionChanged(NodeView nodeView)
        {
            _inspectorView.UpdateNodeSelection(nodeView);
        }
        
        private void OnNodeCreated()
        {
            _selectedEntity.SetDirty();
        }

        private void OnNodeDeleted()
        {
            _inspectorView.ClearInspector();
            
            _selectedEntity.SetDirty();
        }

        private void OnNodeChanged(NodeView nodeView)
        {
            _selectedEntity.SetDirty();
        }

        private void OnEdgeCreated()
        {
            _selectedEntity.SetDirty();
        }

        private void OnEdgeDeleted()
        {
            _selectedEntity.SetDirty();
        }
    }
}