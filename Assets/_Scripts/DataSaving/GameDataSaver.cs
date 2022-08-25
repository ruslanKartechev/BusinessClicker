using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace RuslanScripts
{


    public class GameDataSaver : IGameDataSaver
    {
        public override GameSaveData LoadedData { get => _loadedData; protected set => _loadedData = value; }
        
        [SerializeField] private string _saveFileName;
        [SerializeField] private IMoneySaveLoad _moneySaver;
        [SerializeField] private GameSaveData _loadedData = null;
        [SerializeField] private IBusDataSaveLoad _busSaveLoad;

        private string _savePath;

        private void Awake()
        {
            CorrectSavePath();
        }

        public override void Init()
        {
            CorrectSavePath();
            var hasFile = File.Exists(_savePath);
            if (hasFile == false)
            {
                Debugger.LogRed($"JSON File at {_savePath} WAS NOT Found");
                File.WriteAllText(_savePath, "");
                return;
            }
            else
            {
                Debugger.LogGreen($"JSON FILE FOUND AT: {_savePath}");
            }
        }

        public override bool SaveAll()
        {
            CorrectSavePath();
            var hasFile = File.Exists(_savePath);
            if (hasFile == false)
            {
                Debugger.LogRed("Cannot save file, no file at path");
                return false;
            }

            GameSaveData saveGameData = new GameSaveData();
            WriteBusinessData(saveGameData);
            WriteMoneyData(saveGameData);
            string stringData = JsonUtility.ToJson(saveGameData);
            File.WriteAllText(_savePath, stringData);

            Debugger.LogGreen($"SAVED ALL DATA TO: {_savePath}");
            return true;
        }
        public override bool LoadAll()
        {
            Debugger.LogYellow($"Trying to load saved data from: {_savePath}");
            var hasFile = File.Exists(_savePath);
            if (hasFile == false)
            {
                Debugger.LogRed("Cannot load data, no file at path");
                ReadNullMoneyData();
                return false;
            }
            var text = File.ReadAllText(_savePath);
            var gameData = JsonUtility.FromJson<GameSaveData>(text);
            if (gameData == null)
            {
                Debug.LogError("Failed to read data from JSON file");
                ReadNullMoneyData();
                LoadedData = null;
                return false;
            }
            ReadMoneyData(gameData);
            LoadedData = gameData;
            Debugger.LogGreen($"Loaded all data from: {_savePath} ");
            return true;
        }

        public void ClearAll()
        {
            Debugger.LogGreen("Cleared Saved GameData");
            CorrectSavePath();
            File.WriteAllText(_savePath, "");
        }

        private void WriteBusinessData(GameSaveData saveGameData)
        {
            var saveData = _busSaveLoad.GetSaveData();
            saveGameData.BusinessData = new List<BusinessSaveData>(saveData.Count);
            foreach (var data in saveData)
            {
                saveGameData.BusinessData.Add(data);
            }
        }

        private void WriteMoneyData(GameSaveData saveGameData)
        {
            if(_moneySaver == null)
            {
                Debug.LogError("No Money Data saver");
                return;
            }
            var moneyData = _moneySaver.GetSaveData();
            saveGameData.MoneyData = moneyData;
        }

        private void ReadMoneyData(GameSaveData gameData)
        {
            if (_moneySaver == null)
            {
                Debug.LogError("No Money Data saver");
                return;
            }
            _moneySaver.InitFromData(gameData.MoneyData);
        }

        private void ReadNullMoneyData()
        {
            var moneyData = new MoneySaveData();
            moneyData.CurrentMoney = 0f;
            _moneySaver.InitFromData(moneyData);
        }

   
        private void CorrectSavePath()
        {
            _savePath = Application.persistentDataPath + $"/{_saveFileName}.json";
        }

    
    }
}