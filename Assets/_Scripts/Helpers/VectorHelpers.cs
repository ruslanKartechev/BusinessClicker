using UnityEngine;

namespace RuslanScripts.Helpers
{
    public static class VectorHelpers
    {
        public static Vector2Int GetOrthogonal(this Vector2Int v)
        {
            if (v.x == 0)
            {
                return new Vector2Int(v.y, 0);
            }
            else if (v.y == 0)
            {
                return new Vector2Int(0, v.x);
            }
            return v;
        }


        public static Vector2Int GetDir(char dir)
        {
            switch (dir)
            {
                case 'u':
                    return new Vector2Int(0, 1);
                case 'd':
                    return new Vector2Int(0, -1);
                case 'r':
                    return new Vector2Int(1, 0);
                case 'l':
                    return new Vector2Int(-1, 0);
            }
            return Vector2Int.zero;
        }
    }
}