
using Assets.Script;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerController))]
[CanEditMultipleObjects]
public class PlayerControllerTool : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        if (GUILayout.Button("UpdateBounds"))
        {

            PlayerController playerController = serializedObject.targetObject as PlayerController;
            
            if (playerController != null)
            {
                var boxCollider = playerController.gameObject.GetComponent<BoxCollider>();
                boxCollider.size = Vector3.zero;
                boxCollider.center = Vector3.zero;
                
                var bounds = playerController.gameObject.GetCompoundBounds();
                bounds.center = playerController.transform.InverseTransformPoint(bounds.center);
                
                var objectBounds = serializedObject.FindProperty("_movementBounds");
                objectBounds.boundsValue = bounds;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}