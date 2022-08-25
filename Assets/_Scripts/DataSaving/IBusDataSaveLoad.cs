using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts
{
    public abstract class IBusDataSaveLoad : MonoBehaviour
    {
        public abstract List<BusinessSaveData> GetSaveData();
        public abstract bool LoadSavedData();
        public abstract void InitFromSaved(List<BusinessSaveData> data);

    }
}