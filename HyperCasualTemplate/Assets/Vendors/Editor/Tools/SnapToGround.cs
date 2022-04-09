using UnityEditor;
using UnityEngine;

namespace Krem.Core.Tools
{
    public class SnapToGround : MonoBehaviour
    {
        [MenuItem("Tools/Krem/Snap To Ground %G")]
        public static void Ground()
        {
            foreach (var transform in Selection.transforms)
            {
                RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 100f);

                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject == transform.gameObject)
                        continue;

                    transform.position = hit.point;
                    break;
                }
            }
        }
    }
}