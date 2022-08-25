using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts
{
    public abstract class IGameDataSaver : MonoBehaviour
    {
        public abstract GameSaveData LoadedData { get; protected set; }
        public abstract void Init();
        public abstract bool SaveAll();
        public abstract bool LoadAll();
    }
}