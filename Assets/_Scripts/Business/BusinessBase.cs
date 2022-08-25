using UnityEngine;
using System;
using System.Collections.Generic;
namespace RuslanScripts
{
    public abstract class BusinessBase : ScriptableObject
    {
        public Action OnBusinessPurchased;
        public Action<float> OnMoneyGenerated;
        public Action<int> OnNewLevelPurchase;
        public Action<int> OnModifierPurchase;

        public List<BusinessModifier> MyModifiers { get => _myModifiers; set => _myModifiers = value; }

        public string ID;
        public BusinessConfig Config;
        public bool IsPurchased = false;
        public int CurrentLevel = 0;
        public float CurrentIncome = 0;
        public float CurrentIncomeProgress = 0;
        protected List<BusinessModifier> _myModifiers;

        public virtual void InitData()
        {
            _myModifiers = new List<BusinessModifier>(Config.Modifiers.Count);
            foreach(var mod in Config.Modifiers)
            {
                _myModifiers.Add(mod);
            }
            CalculateCurrentIncome();
        }
        public virtual void Refresh()
        {
            CurrentLevel = 0;
            CurrentIncome = 0;
            CurrentIncomeProgress = 0;
            IsPurchased = false;
        }
        public abstract void TickProgress();
        public abstract void BuyLevel();
        public abstract void UnlockModifier(int modIndex);
        public abstract float CalculateCurrentIncome();
        public abstract float GetNextLevelPrice();

      

        protected void RaiseOnMoneyGen(float money)
        {
            OnMoneyGenerated?.Invoke(money);
        }
        protected void RaiseOnNewLevel(int level)
        {
            OnNewLevelPurchase?.Invoke(level);
        }
        protected void RaiseOnModifierPurchase(int index)
        {
            OnModifierPurchase?.Invoke(index);
        }
        protected void RaiseOnBusinessPurchased()
        {
            OnBusinessPurchased?.Invoke();
        }
    }
}