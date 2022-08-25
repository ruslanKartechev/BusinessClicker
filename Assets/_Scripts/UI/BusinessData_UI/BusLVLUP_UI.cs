using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
namespace RuslanScripts
{
    public class BusLVLUP_UI : Bus_UI
    {
        public Action OnClicked;
        public string PriceWords;
        [Space(10)]
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _priceText;
        private void Start()
        {
            _buyButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            OnClicked?.Invoke();
        }

        public override void UpdateUI(BusinessBase bus)
        {
            var price = bus.GetNextLevelPrice();
            _priceText.text = $"{PriceWords}: {price}$";
        }
    }


}