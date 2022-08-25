using UnityEngine;
namespace RuslanScripts
{
    [CreateAssetMenu(fileName = "Business", menuName = "SO/Business")]
    public class Business : BusinessBase
    {
        [SerializeField] private IBusnessIncomeCalculator _incomeCalculator;
        [SerializeField] private MoneyChannel _moneyChannel;

        public override void BuyLevel()
        {
            Debugger.LogGreen($"Business id:{ID}, new level purchase");
            if (CurrentLevel == 0)
            {
                IsPurchased = true;
                RaiseOnBusinessPurchased();
            }
            CurrentLevel++;
            CalculateCurrentIncome();
            RaiseOnNewLevel(CurrentLevel);
        }

        public override void TickProgress()
        {
            if(IsPurchased == false)
            {
                return;
            }
            CurrentIncomeProgress += Time.deltaTime / Config.IncomeGenTime;
            if (CurrentIncomeProgress >= 1)
            {
                CalculateCurrentIncome();
                _moneyChannel?.AddMoney(CurrentIncome);
                CurrentIncomeProgress = 0;
                RaiseOnMoneyGen(CurrentIncome);
            }
        }

        public override void UnlockModifier(int modIndex)
        {
            if(modIndex >= _myModifiers.Count)
            {
                Debug.Log($"Wrong Modifier index passed");
                return;
            }
            if(_myModifiers[modIndex].IsPurchased == true)
            {
                Debug.Log("Already purchased");
                return;
            }
            var mod = _myModifiers[modIndex];
            mod.IsPurchased = true;
            _myModifiers[modIndex] = mod;
            CalculateCurrentIncome();
            RaiseOnModifierPurchase(modIndex);
        }

        public override float CalculateCurrentIncome()
        {
            var income = _incomeCalculator.CalculateIncome(this);
            CurrentIncome = income;
            return income;
        }

        public override float GetNextLevelPrice()
        {
            return Config.BasePrice * (CurrentLevel + 1);
        }

    }
}