
using UnityEngine;
namespace RuslanScripts
{
    public abstract class IMoneySaveLoad : MonoBehaviour
    {
        public abstract MoneySaveData GetSaveData();
        public abstract void InitFromData(MoneySaveData data);
        public abstract void LoadData();
    }
}