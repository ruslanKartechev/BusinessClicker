using UnityEngine;
using UnityEditor;
namespace RuslanScripts
{
#if UNITY_EDITOR

    [CustomEditor(typeof(Business))]
    public class BusinessEditor : Editor
    {
        Business me;

        private void OnEnable()
        {
            me = target as Business;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Refresh"))
            {
                me.Refresh();
            }
        }
    }

#endif
}