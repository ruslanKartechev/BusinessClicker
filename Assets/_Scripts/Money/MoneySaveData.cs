namespace RuslanScripts
{
    [System.Serializable]
    public struct MoneySaveData
    {
        public float CurrentMoney;

        public MoneySaveData(float money)
        {
            CurrentMoney = money;
        }

        public static MoneySaveData StartData = new MoneySaveData(0f);
    }
}