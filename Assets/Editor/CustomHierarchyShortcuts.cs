using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class CustomHierarchyShortcuts
{
    private static GameObject lastSelectedObject = null;

    static CustomHierarchyShortcuts()
    {
        // Register the key shortcuts
        EditorApplication.update += Update;
        // Add a global key listener
        HandleGlobalShortcuts();
    }

    private static void Update()
    {
        // Do nothing here, this is just to keep the EditorApplication.update call
    }

    private static void HandleGlobalShortcuts()
    {
        Event currentEvent = Event.current;

        // Handle Control + J
        if (currentEvent != null && currentEvent.type == EventType.KeyDown &&
            currentEvent.control && currentEvent.keyCode == KeyCode.J)
        {
            // Get the currently selected GameObject
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject != null)
            {
                lastSelectedObject = selectedObject;
                Debug.Log($"Object {lastSelectedObject.name} marked for later selection.");
            }
            currentEvent.Use(); // Mark the event as used
        }

        // Handle Control + H
        if (currentEvent != null && currentEvent.type == EventType.KeyDown &&
            currentEvent.control && currentEvent.keyCode == KeyCode.H)
        {
            if (lastSelectedObject != null)
            {
                Selection.activeGameObject = lastSelectedObject;
                EditorGUIUtility.PingObject(lastSelectedObject);
                Debug.Log($"Object {lastSelectedObject.name} selected.");
            }
            else
            {
                Debug.Log("No object has been marked for selection.");
            }
            currentEvent.Use(); // Mark the event as used
        }
    }
}
