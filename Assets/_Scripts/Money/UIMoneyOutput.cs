using UnityEngine;
using TMPro;
namespace RuslanScripts
{
    public class UIMoneyOutput : IMoneyOutput
    {
        public string CountWords = "Balance";
        [SerializeField] private TextMeshProUGUI _moneyText;

        public override void UpdateCount(float money)
        {
            _moneyText.text = $"{CountWords}: {money}$";

        }
    }
}