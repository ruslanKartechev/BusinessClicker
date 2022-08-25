using System.Collections.Generic;
namespace RuslanScripts
{
    public static class DataConverter
    {

        public static BusinessSaveData ConvertBusinessToSaveData(BusinessBase bus)
        {
            BusinessSaveData data = new BusinessSaveData();
            data.ID = bus.ID;
            data.IsPurchased = bus.IsPurchased;
            data.CurrentLevel = bus.CurrentLevel;
            data.CurrentIncome = bus.CurrentIncome;
            data.CurrentIncomeProgress = bus.CurrentIncomeProgress;
            data.Modifiers = new List<BusinessModifier>(bus.MyModifiers.Count);
            foreach (var mod in bus.MyModifiers)
            {
                data.Modifiers.Add(mod);
            }
            return data;
        }

        public static void WriteDataToBusiness(BusinessBase bus, BusinessSaveData data)
        {
            bus.IsPurchased = data.IsPurchased;
            bus.ID = data.ID;
            bus.CurrentLevel = data.CurrentLevel;
            bus.CurrentIncome = data.CurrentIncome;
            bus.CurrentIncomeProgress = data.CurrentIncomeProgress;
            bus.MyModifiers = data.Modifiers;
            bus.MyModifiers = new List<BusinessModifier>(data.Modifiers.Count);
            foreach(var mod in data.Modifiers)
            {
                bus.MyModifiers.Add(mod);
            }
        }
    }
}