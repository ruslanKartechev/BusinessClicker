using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuslanScripts
{

    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "SO/BusinessConfig")]
    public class BusinessConfig : ScriptableObject
    {
        public float IncomeGenTime;
        public float BasePrice;
        public float BaseIncome;
        public List<BusinessModifier> Modifiers;
    }
}