using UnityEditor;
using UnityEngine;

namespace Krem.Core.Tools
{
    public class CreateEntity : MonoBehaviour
    {
        [MenuItem("Tools/Krem/Create Entity #%E")]
        public static void CreateEntityInstance()
        {
            GameObject entity = Resources.Load("Entity") as GameObject;
            GameObject parent = Selection.activeGameObject;

            GameObject instance = Instantiate(entity, parent?.transform);
            instance.transform.position = Vector3.zero;
            instance.name = "Entity";
            
            Undo.RegisterCreatedObjectUndo(instance, "Add Entity");
        }
    }
}