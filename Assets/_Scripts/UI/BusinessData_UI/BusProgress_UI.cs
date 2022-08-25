using UnityEngine;
using UnityEngine.UI;
namespace RuslanScripts
{
    public class BusProgress_UI : Bus_UI
    {
      
        [SerializeField] private Image _fillImage;
        
        public override void UpdateUI(BusinessBase bus)
        {
            _fillImage.fillAmount = bus.CurrentIncomeProgress;
        }

    }


}