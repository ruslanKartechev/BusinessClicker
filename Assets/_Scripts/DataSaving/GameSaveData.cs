using System.Collections.Generic;
namespace RuslanScripts
{
    [System.Serializable]

    public class GameSaveData
    {
        public List<BusinessSaveData> BusinessData;
        public MoneySaveData MoneyData;
    }
}