using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts
{
    public class BusinessPurchaseManager : MonoBehaviour
    {
        public BusinessPurchaseChannel Channel;
        public MoneyChannel Money;

        void Start()
        {
            Channel.Impl_BuyBusiness = BuyBusiness;
            Channel.Impl_BuyBusinessModifier = BuyModifier;
        }

        private void BuyModifier(BusinessBase bus, int index)
        {
            if(index >= bus.MyModifiers.Count || index < 0)
            {
                Debug.LogError($"Trying to buy modifier out of list indeces");
                return;
            }
            if(bus.MyModifiers[index].IsPurchased == true)
            {
                return;
            }
            var cost = bus.MyModifiers[index].Price;
            var money = Money.GetCurrentMoney();
            if(money >= cost)
            {
                Money.RemoveMoney(cost);
                bus.UnlockModifier(index);
            }
        }

        private void BuyBusiness(BusinessBase bus)
        {
            var cost = bus.GetNextLevelPrice();
            var money = Money.GetCurrentMoney();
            if(money >= cost)
            {
                Money.RemoveMoney(cost);
                bus.BuyLevel();
            }
        }

   
    }
}