using UnityEngine;
namespace RuslanScripts
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private IMoneyOutput _moneyOutput;
        [SerializeField] private MoneyChannel _channel;

        public void Init()
        {
            var money = _channel.GetCurrentMoney();
            _moneyOutput.UpdateCount(money);
            _channel.OnCountChaned += OnMoneyChanged;

        }

        private void OnDisable()
        {
            _channel.OnCountChaned -= OnMoneyChanged;
        }

        private void OnMoneyChanged(float money)
        {
            _moneyOutput.UpdateCount(money);
            _moneyOutput.UpdateCount(money);

        }

    }
}