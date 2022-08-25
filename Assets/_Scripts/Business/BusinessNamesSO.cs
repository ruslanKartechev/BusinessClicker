using UnityEngine;

namespace RuslanScripts
{
    [CreateAssetMenu(fileName = "BusinessNamesSO", menuName = "SO/BusinessNamesSO")]
    public class BusinessNamesSO : BusinessNameGetter
    {
        public string BusinessName;
        public string Modifier_1_Name;
        public string Modifier_2_Name;

        public override string GetBusinessName()
        {
            return BusinessName;
        }

        public override string GetModifierName(int index)
        {
            if (index == 0)
                return Modifier_1_Name;
            else
                return Modifier_2_Name;
        }
    }
}