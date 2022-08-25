
using UnityEngine;
namespace RuslanScripts
{
    public class MoneyManagerSaveLoad : IMoneySaveLoad
    {
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private IGameDataSaver _dataSaver;
        public override MoneySaveData GetSaveData()
        {
            MoneySaveData data = new MoneySaveData();
            data.CurrentMoney = _moneyManager.CurrentMoney;
            return data;
        }

        public override void InitFromData(MoneySaveData data)
        {
            var amount = data.CurrentMoney;
            _moneyManager.CurrentMoney = amount;
        }

        public override void LoadData()
        {
            if (_dataSaver.LoadedData == null)
            {
                InitFromData(MoneySaveData.StartData);
            }
            else
            {
                var data = _dataSaver.LoadedData.MoneyData;
                InitFromData(data);
            }
        }

    }
}