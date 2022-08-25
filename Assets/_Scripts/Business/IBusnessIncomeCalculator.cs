using UnityEngine;

namespace RuslanScripts
{
    public abstract class IBusnessIncomeCalculator : ScriptableObject
    {
        public abstract float CalculateIncome(BusinessBase business);
    }
}