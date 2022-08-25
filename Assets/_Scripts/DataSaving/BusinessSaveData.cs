using System.Collections.Generic;
namespace RuslanScripts
{
    [System.Serializable]
    public struct BusinessSaveData
    {
        public string ID;
        public bool IsPurchased;
        public int CurrentLevel;
        public float CurrentIncome;
        public float CurrentIncomeProgress;
        public List<BusinessModifier> Modifiers;
    }
}