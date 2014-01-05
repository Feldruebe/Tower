using UnityEngine;
using UnityEditor;
using System.Collections;
using Tower.Parallax;

[CustomEditor(typeof(ParallaxController))]
public class ParallaxControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ParallaxController parallaxController = ((ParallaxController)target);
        base.OnInspectorGUI();

        if(GUILayout.Button("Add Layer"))
        {
            GameObject newLayer = new GameObject("Layer " + parallaxController.layers.Count,typeof(ParallaxLayer));
            newLayer.transform.parent = parallaxController.transform;
            parallaxController.layers.Add(newLayer.GetComponent<ParallaxLayer>());
            newLayer.transform.position = Vector3.zero;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

}