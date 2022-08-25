using System.Collections;
using UnityEngine;
namespace RuslanScripts
{
    public class BusinessUIBlock : MonoBehaviour
    {
        public BusinessBase mBusiness;
        public BusinessNameGetter mNames;
        [SerializeField] private BusinessPurchaseChannel _purchaseChannel;
        [Header("Components")]
        [SerializeField] private BusName_UI _nameUI;
        [SerializeField] private BusModifier_UI _mod_1;
        [SerializeField] private BusModifier_UI _mod_2;
        [SerializeField] private BusLVLUP_UI _lvlUP;
        [SerializeField] private BusProgress_UI _progressBar;
        [SerializeField] private BusDescription_UI _description;

        private Coroutine _updatingProgress;

        private void OnDisable()
        {
            if(mBusiness != null)
            {
                mBusiness.OnNewLevelPurchase -= OnLevelUpdated;
                mBusiness.OnModifierPurchase -= OnModifierPurchased;
            }
        }

        public void Init()
        {
            _mod_1.OnClicked = OnBuyMultiplierBtn;
            _mod_2.OnClicked = OnBuyMultiplierBtn;
            _lvlUP.OnClicked = OnByLevelBtn;
            mBusiness.OnNewLevelPurchase += OnLevelUpdated;
            mBusiness.OnModifierPurchase += OnModifierPurchased;
        }

        public void Hide()
        {
            StopProgUpdate();
        }

        public void UpdateUI()
        {
            _progressBar.UpdateUI(mBusiness);
            _lvlUP.UpdateUI(mBusiness);
            _description.UpdateUI(mBusiness);

            _mod_1.ModIndex = 0;
            _mod_1.UpdateUI(mBusiness.MyModifiers[0]);

            _mod_2.ModIndex = 1;
            _mod_2.UpdateUI(mBusiness.MyModifiers[1]);
        }

        public void UpdateNames()
        {
            if (mNames == null)
                return;
            string busName = mNames.GetBusinessName();
            _nameUI.SetName(busName);
            string mod_1 = mNames.GetModifierName(0);
            string mod_2 = mNames.GetModifierName(1);
            _mod_1.SetName(mod_1);
            _mod_2.SetName(mod_2);
        }

        public void UpdateProgress()
        {
            _progressBar.UpdateUI(mBusiness);
        }

        public void OnBuyMultiplierBtn(int index)
        {
            _purchaseChannel.BuyBusModifier(mBusiness, index);
        }

        public void OnByLevelBtn()
        {
            _purchaseChannel.BuyBusLevel(mBusiness);
        }

        public void StartProgUpdate()
        {
            StopProgUpdate();
            _updatingProgress = StartCoroutine(UpdatingProgress());
        }

        public void StopProgUpdate()
        {
            if (_updatingProgress != null)
                StopCoroutine(_updatingProgress);
        }

        private void OnLevelUpdated(int level)
        {
            UpdateUI();
        }

        private void OnModifierPurchased(int index)
        {
            UpdateUI();
        }


        private IEnumerator UpdatingProgress()
        {
            while (true)
            {
                UpdateProgress();
                yield return null;
            }
        }
    

    }


}