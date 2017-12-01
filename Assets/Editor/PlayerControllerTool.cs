
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
                playerController.bounds = playerController.gameObject.GetCompoundBounds();

                var boxCollider = playerController.gameObject.AddComponent<BoxCollider>();
                boxCollider.size = playerController.bounds.size;
                boxCollider.center = playerController.transform.InverseTransformPoint(playerController.bounds.center);;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}