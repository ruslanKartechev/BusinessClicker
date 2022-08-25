using System.Collections.Generic;
using UnityEngine;
namespace RuslanScripts
{
    public class BusManagerSaveLoad : IBusDataSaveLoad
    {
        [SerializeField] private GameDataSaver _dataSaver;
        [SerializeField] private BusinessManager _busManager;

        public override List<BusinessSaveData> GetSaveData()
        {
            var businesses = _busManager.Businesses;
            List<BusinessSaveData> data = new List<BusinessSaveData>(businesses.Count);
            foreach (var bus in businesses)
            {
                if (bus != null)
                    data.Add(DataConverter.ConvertBusinessToSaveData(bus));
            }
            return data;
        }

        public override bool LoadSavedData()
        {
            var gameData = _dataSaver.LoadedData;
            if (gameData == null)
            {
                Debug.LogError("No data was loaded");
                return false;
            }
            if (gameData.BusinessData == null || gameData.BusinessData.Count == 0)
            {
                Debug.Log("No business data was saved");
                return false;
            }
            InitFromSaved(gameData.BusinessData);
            return true;
        }

        public override void InitFromSaved(List<BusinessSaveData> savedData)
        {
            var businesses = _busManager.Businesses;
            for (int i = 0; i < businesses.Count; i++)
            {
                var bus = businesses[i];
                if (i >= savedData.Count)
                {
                    Debug.Log($"Business count > saved data count");
                    bus.InitData();
                    continue;
                }
                var data = savedData[i];
                DataConverter.WriteDataToBusiness(bus, data);
            }
        }


    }
}