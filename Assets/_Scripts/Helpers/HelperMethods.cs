using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuslanScripts.Helpers
{
    public static class HelperMethods
    {

       

        public static int ToMs(this float sec)
        {
            return (int)(1000 * sec);
        }

        public static List<List<Vector2Int>> SeparateIntoColomns(List<Vector2Int> data)
        {
            List<Vector2Int> m_data = new List<Vector2Int>(data);
            List<List<Vector2Int>> colomns = new List<List<Vector2Int>>();
            List<int> colomnPos = new List<int>();

            while(m_data.Count > 0)
            {
                var colomn = GetColomn(m_data);
                colomns.Add(colomn);
            }
            return colomns;
        }

        public static List<Vector2Int> GetColomn(List<Vector2Int> data)
        {
            var x = data[0].x;
            List<Vector2Int> result = new List<Vector2Int>();
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if(data[i].x == x)
                {
                    result.Add(data[i]);
                    data.RemoveAt(i);
                }
            }
            return result;
        }

        public static List<int> GetRandomIndices(int start, int end, int count)
        {
            if ((end - start) < count) { Debug.Log("Wrong start/end input"); return null; }
            List<int> Pool = new List<int>();
            for (int i = start; i <= end; i++)
            {
                Pool.Add(i);
            }
            List<int> chosenInd = new List<int>();
            while (chosenInd.Count < count)
            {
                int ind = (int)Random.Range(0, Pool.Count);
                int rand = Pool[ind];
                Pool.RemoveAt(ind);
                chosenInd.Add(rand);
            }
            return chosenInd;
        }

        public static Transform FindByName(Transform parent, string name)
        {
            Transform result = null;
            foreach (Transform child in parent)
            {
                if (child.transform.name == name)
                    result = child;
            }
            return result;
        }

        public static Transform FindByTag(Transform parent, string tag)
        {
            Transform result = null;
            foreach (Transform child in parent)
            {
                if (child.transform.tag == tag)
                    result = child;
            }
            return result;
        }

        public static Vector3 GetRandomUILocalEulers()
        {
            return new Vector3(0, 0, Random.Range(0, 180));
        }   

        public static Vector3 GetRandomOrthogonalDirection()
        {
            int random = UnityEngine.Random.Range(0, 4);
            Vector3 result = new Vector3();
            switch (random)
            {
                case 1:
                    result =  Vector3.up;
                    break;
                case 2:
                    result = Vector3.right;
                    break;
                case 3:
                    result = Vector3.forward;
                    break;
            }
            int invert = UnityEngine.Random.Range(0, 3);
            if (invert > 1)
                result *= -1;
            return result;
        }


        public static T GetRandomFromList<T>(List<T> list)
        {
            int rand = UnityEngine.Random.Range(0,list.Count);
            return list[rand];
        }

    }
}