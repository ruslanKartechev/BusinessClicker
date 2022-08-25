using UnityEngine;
namespace RuslanScripts
{
    public class UIManager : UIManagerBase
    {
        [SerializeField] private BusinessUIManager _busUI;
        [SerializeField] private MoneyUI _moneyUI;

        public override void Init()
        {
            _busUI.Init();
            _moneyUI.Init();
        }
    }
}