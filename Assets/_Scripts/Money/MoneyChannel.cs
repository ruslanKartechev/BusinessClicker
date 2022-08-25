using UnityEngine;
using System;
namespace RuslanScripts
{
    [CreateAssetMenu(fileName = "MoneyChannel", menuName = "SO/MoneyChannel")]
    public class MoneyChannel : ScriptableObject
    {
        /// <summary>
        /// Event called every time money count is changed, parameter = Current Money Count
        /// </summary>
        public event Action<float> OnCountChaned;

        public Action<float> Impl_AddMoney;
        public Action<float> Impl_RemoveMoney;
        public FloatGetter Impl_GetCurrentMoney;

        
        public void AddMoney(float amount)
        {
            if (Impl_AddMoney != null)
                Impl_AddMoney?.Invoke(amount);
            else
                Debugger.LogBlue($"Impl_RemoveMoney action is null");
        }

        public void RemoveMoney(float amount)
        {
            if (Impl_RemoveMoney != null)
                Impl_RemoveMoney?.Invoke(amount);
            else
                Debugger.LogBlue($"Impl_RemoveMoney action is null");
        }

        public float GetCurrentMoney()
        {
            if(Impl_GetCurrentMoney != null)
                return Impl_GetCurrentMoney.Invoke();
            else
            {
                Debug.Log($"Impl_GetCurrentMoney is null, returning 0 money");
                return 0;
            }
        }

        public void RaiseOnMoneyChaned(float currentValue)
        {
            OnCountChaned?.Invoke(currentValue);
        }

     
    }
}