using UnityEngine;


namespace RuslanScripts
{
    public abstract class IMoneyChannel : ScriptableObject
    {
        public abstract void AddMoney(float amount);
        public abstract void RemoveMoney(float amount);
        public abstract float GetCurrentMoney();
    }
}