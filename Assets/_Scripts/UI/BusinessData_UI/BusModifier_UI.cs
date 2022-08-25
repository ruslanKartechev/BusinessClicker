using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
namespace RuslanScripts
{
    public class BusModifier_UI : MonoBehaviour
    {
        public Action<int> OnClicked;
        public string DescriptionWords;
        public string PriceWords;
        public string AfterPurchasedWords;

        [HideInInspector] public int ModIndex = 0;
        [Space(10)]
        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;
        

        private void Start()
        {
            _buyButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            OnClicked?.Invoke(ModIndex);
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void UpdateUI(BusinessModifier mod)
        {
            if (mod.IsPurchased == true)
            {
                _buyButton.interactable = false;
            }
            else
            {
                _buyButton.interactable = true;
            }

            _descriptionText.text = $"{DescriptionWords}: {mod.IncomeMultiplier}%";
            if(mod.IsPurchased == false)
            {
                _priceText.text = $"{PriceWords}: {mod.Price}$";
            }
            else
            {
                _priceText.text = $"{AfterPurchasedWords}";
            }
        }
    }


}