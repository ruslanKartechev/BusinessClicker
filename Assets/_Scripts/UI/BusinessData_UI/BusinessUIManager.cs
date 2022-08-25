using System.Collections.Generic;
using UnityEngine;
using RuslanScripts.Helpers;
namespace RuslanScripts
{
    public class BusinessUIManager : MonoBehaviour
    {
        public Canvas BusCanvas;
        public List<BusinessUIBlock> _blocks = new List<BusinessUIBlock>();
        [Space(10)]
        public BusinessManager _busManager;
        public List<BusinessNameGetter> _names = new List<BusinessNameGetter>();

        public void Init()
        {
            foreach(var block in _blocks)
            {
                block.Init();
                block.UpdateUI();
                block.UpdateNames();
                block.StartProgUpdate();
            }
        }

        public void GetAllUIBlocks()
        {
            if(BusCanvas == null)
            {
                Debug.Log("No business UI canvas provided");
                return;
            }
            _blocks = new List<BusinessUIBlock>();
            HeirarchyHelpers.GetComponentsInHeirarchy(BusCanvas.transform, _blocks);
        }

        public void SetNamesToBlocks()
        {
            for(int i =0; i<_blocks.Count; i++)
            {
                var block = _blocks[i];
                if(block != null)
                {
                    if (i >= _names.Count)
                        break;
                    block.mNames = _names[i];
                }
            }
        }

        public void SetBusToBlocks()
        {
            var busList = _busManager.Businesses;
            for (int i = 0; i < _blocks.Count; i++)
            {
                var block = _blocks[i];
                if (block != null)
                {
                    if (i >= busList.Count)
                        break;
                    block.mBusiness = busList[i];
                }
            }
        }
    }
}