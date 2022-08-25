using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts
{
    public class BusinessManager : MonoBehaviour
    {
        public List<BusinessBase> Businesses { get => _businesses; }

        public bool LoadFromJson = true;
        [SerializeField] private List<BusinessBase> _businesses = new List<BusinessBase>();
        [SerializeField] private IBusinessTicker _ticker;
        [SerializeField] private IBusDataSaveLoad _saveLoad;
        [SerializeField] private IGameDataSaver _dataSaver;

        public void Init()
        {
            _ticker.Businesses = _businesses;
            InitBusinesses();
            _ticker.StartTicking();
        }

        public void InitBusinesses()
        {
            if(LoadFromJson == true)
            {
                if (_saveLoad.LoadSavedData() == true)
                {
                    Debug.Log("Loaded successfully");
                }
                else
                {
                    InitAsAllNew();
                }
            }
            else
            {
                InitAsAllNew();
            }
        }

        public void RefreshAllBusinesses()
        {
            foreach (var bus in _businesses)
            {
                if (bus != null)
                    bus.Refresh();
            }
        }

        private void InitAsAllNew()
        {
            bool hasOne = false;
            foreach (var bus in _businesses)
            {
                bus.InitData();
                if (bus.IsPurchased == true)
                    hasOne = true;
            }
            if(hasOne == false)
            {
                Debugger.LogRed("No business was purchased, purchase first in list");
                _businesses[0].BuyLevel();
            }
        }
    }
}