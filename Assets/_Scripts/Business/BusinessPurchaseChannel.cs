using UnityEngine;
using System;
namespace RuslanScripts
{
    [CreateAssetMenu(fileName = "BusinessPurchaseChannel", menuName = "SO/BusinessPurchaseChannel")]
    public class BusinessPurchaseChannel : ScriptableObject
    {
        public Action<BusinessBase> Impl_BuyBusiness;
        public Action<BusinessBase,int> Impl_BuyBusinessModifier;


        public void BuyBusLevel(BusinessBase bus)
        {
            if (Impl_BuyBusiness != null)
            {
                Impl_BuyBusiness.Invoke(bus);
            }
            else
                Debug.Log("Impl_BuyBusiness action is null");
        }

        public void BuyBusModifier(BusinessBase bus, int index)
        {
            if (Impl_BuyBusinessModifier != null)
            {
                Impl_BuyBusinessModifier.Invoke(bus, index);
            }
            else
                Debug.Log("Impl_BuyBusinessModifier action is null");
        }
    }
}