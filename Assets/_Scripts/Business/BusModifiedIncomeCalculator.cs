using UnityEngine;
namespace RuslanScripts
{
    [CreateAssetMenu(fileName = "BusIncomeCalculator", menuName = "SO/BusIncomeCalculator")]
    public class BusModifiedIncomeCalculator : IBusnessIncomeCalculator
    {
        public override float CalculateIncome(BusinessBase business)
        {
            var income = 0f;
            try
            {
                var mod_1 = GetModifier_1(business.Config.Modifiers[0]);
                var mod_2 = GetModifier_1(business.Config.Modifiers[1]);
                income = business.CurrentLevel * business.Config.BaseIncome * (1 + mod_1 + mod_2);
                return income;

            } catch(System.Exception ex)
            {
                Debugger.LogException(ex);
                income = business.CurrentLevel * business.Config.BaseIncome;
                Debug.Log($"Returning simplified income");
                return income;
            }
        }

        private float GetModifier_1(BusinessModifier mod)
        {
            if (mod.IsPurchased == false)
                return 0f;
            return (float)mod.IncomeMultiplier / 100;
        }
    }
}