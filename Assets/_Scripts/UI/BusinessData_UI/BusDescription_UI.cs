using UnityEngine;
using TMPro;
namespace RuslanScripts
{
    public class BusDescription_UI : Bus_UI
    {
        public string LevelWords;
        public string IncomeWords;
        [Space(10)]
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _incomeText;

        public override void UpdateUI(BusinessBase bus)
        {
            _levelText.text = $"{LevelWords}\n{bus.CurrentLevel}";
            _incomeText.text = $"{IncomeWords}\n{bus.CurrentIncome}";

        }
    }


}