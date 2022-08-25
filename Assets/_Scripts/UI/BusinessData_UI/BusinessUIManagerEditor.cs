using UnityEngine;
using UnityEditor;
namespace RuslanScripts
{
#if UNITY_EDITOR
    [CustomEditor(typeof(BusinessUIManager))]
    public class BusinessUIManagerEditor : Editor
    {
        BusinessUIManager me;

        private void OnEnable()
        {
            me = target as BusinessUIManager;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("GetBlocksOnCanvas"))
            {
                me.GetAllUIBlocks();
                EditorUtility.SetDirty(me);
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("SetBusinesses"))
            {
                me.SetBusToBlocks();
                EditorUtility.SetDirty(me);

            }
            if (GUILayout.Button("SetNames"))
            {
                me.SetNamesToBlocks();
                EditorUtility.SetDirty(me);

            }
            GUILayout.EndHorizontal();

        }
    }
#endif
}