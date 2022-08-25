using UnityEngine;
namespace RuslanScripts
{
    [System.Serializable]
    public struct BusinessModifier
    {
        public float Price;
        [Tooltip("IN PERCENT")] public float IncomeMultiplier;
        public bool IsPurchased;
    }
}