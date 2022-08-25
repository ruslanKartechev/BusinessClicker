using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts.Helpers
{
    public static class HeirarchyHelpers
    {

        public static GameObject GetGoByName(Transform root, string name)
        {
            GameObject result = null;
            if (root.name == name)
                return root.gameObject;
            for (int i = 0; i < root.childCount; i++)
            {
                result = GetGoByName(root.GetChild(i), name);
                if (result != null && result.name == name)
                    return result;
            }
            return result;
        }

        public static void GetGameObjects(Transform root, List<GameObject> addtoList)
        {
            addtoList.Add(root.gameObject);
            for (int i = 0; i < root.childCount; i++)
            {
                GetGameObjects(root.GetChild(i), addtoList);
            }
        }

        public static void GetTransforms(Transform root, List<Transform> addtoList)
        {
            addtoList.Add(root);
            for (int i = 0; i < root.childCount; i++)
            {
                GetTransforms(root.GetChild(i), addtoList);
            }
        }


        public static void GetGameObjectsNames(Transform root, List<string> addtoList)
        {
            addtoList.Add(root.gameObject.name);
            for (int i = 0; i < root.childCount; i++)
            {
                GetGameObjectsNames(root.GetChild(i), addtoList);
            }
        }



        public static void GetComponentsInHeirarchy<T>(Transform root, List<T> addToList)
        {
            TryGetComponentsInHeirarchy(root.gameObject, addToList);
            for (int i = 0; i < root.childCount; i++)
            {
                GetComponentsInHeirarchy(root.GetChild(i), addToList);
            }
        }

        public static void TryGetComponentsInHeirarchy<T>(GameObject go, List<T> addToList)
        {
            var component = go.GetComponent<T>();
            if (component != null)
                addToList.Add(component);
        }

        public static void GetAllFirstChildren(GameObject go, List<GameObject> addToList)
        {
            int count = go.transform.childCount;
            for(int i =0; i<count;i++)
            {
                addToList.Add(go.transform.GetChild(i).gameObject);
            }
        }

       
    }

}