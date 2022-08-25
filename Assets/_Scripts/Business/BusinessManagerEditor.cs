using UnityEngine;
using UnityEditor;
namespace RuslanScripts
{
#if UNITY_EDITOR
    [CustomEditor(typeof(BusinessManager))]
    public class BusinessManagerEditor : Editor
    {
        BusinessManager me;
        private void OnEnable()
        {
            me = target as BusinessManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("RefreshAll"))
            {
                me.RefreshAllBusinesses();
                EditorUtility.SetDirty(me);
            }
        }
    }
#endif
}