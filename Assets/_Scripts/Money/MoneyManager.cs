
using UnityEngine;
namespace RuslanScripts
{

    public class MoneyManager : MonoBehaviour
    {
        public bool UseLoadedData = true;
        public float CurrentMoney { get => _currentMoney; set => _currentMoney = value; }

        [SerializeField] private float _currentMoney;
        [SerializeField] private MoneyChannel _moneyChannel;
        [SerializeField] private IMoneySaveLoad _saveLoad;

        public void Init()
        {
            _moneyChannel.Impl_AddMoney = AddMoney;
            _moneyChannel.Impl_GetCurrentMoney = GetMoneyCount;
            _moneyChannel.Impl_RemoveMoney = RemoveMoney;
            if(UseLoadedData == true)
            {
                _saveLoad.LoadData();
            }
        }

        private void AddMoney(float money)
        {
            _currentMoney += money;
            _moneyChannel.RaiseOnMoneyChaned(_currentMoney);
        }

        private float GetMoneyCount()
        {
            return _currentMoney;
        }

        private void RemoveMoney(float money)
        {
            _currentMoney -= money;
            if (_currentMoney < 0)
                _currentMoney = 0;
            _moneyChannel.RaiseOnMoneyChaned(_currentMoney);
        }

    }
}