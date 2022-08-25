using UnityEngine;

namespace RuslanScripts
{
    public class GameManager : MonoBehaviour
    {
        public bool DoLoadOnStart = true;
        public bool DoSaveOnPause = true;
        public bool DoSaveOnQuit = true;
        [SerializeField] private IGameDataSaver _dataSaver;
        [SerializeField] private BusinessManager _busManager;
        [SerializeField] private UIManagerBase _ui;
        [SerializeField] private MoneyManager _moneyManager;

        private void Start()
        {
            InitGame();
        }

        public void InitGame()
        {
            if(DoLoadOnStart == true)
            {
                _dataSaver.Init();
                _dataSaver.LoadAll();
            }
            _moneyManager.Init();
            _busManager.Init();
            _ui.Init();
        }

        public void OnApplicationPause(bool pause)
        {
            Debug.Log("ON APPLICATION PAUSE");
            if(pause == true && DoSaveOnPause == true)
            {
                _dataSaver.SaveAll();
            }
        }

        public void OnApplicationQuit()
        {
            Debug.Log("ON APPLICATION QUIT");
            if (DoSaveOnQuit == true) 
            { 
                _dataSaver.SaveAll();
            }
        }

    }
}