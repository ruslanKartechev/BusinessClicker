using UnityEngine;
using UnityEditor;
namespace RuslanScripts
{
#if UNITY_EDITOR

    [CustomEditor(typeof(GameDataSaver))]
    public class BusinessDataSaverEditor : Editor
    {
        GameDataSaver me;
        private void OnEnable()
        {
            me = target as GameDataSaver;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Init"))
            {
                me.Init();
            }
            if (GUILayout.Button("SaveAll"))
            {
                me.SaveAll();
            }
            if (GUILayout.Button("ClearAll"))
            {
                me.ClearAll();
            }
            GUILayout.EndHorizontal();
        }

        
    }
#endif
}