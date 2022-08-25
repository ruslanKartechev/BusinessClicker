using System.Collections.Generic;
using System.Collections;
using UnityEngine;
namespace RuslanScripts
{
    public class SimpleBusinessTicker : IBusinessTicker
    {
        [SerializeField] private List<BusinessBase> _businesses = new List<BusinessBase>();
        public override List<BusinessBase> Businesses { 
            get => _businesses;
            set => _businesses = value;
        }

        private Coroutine _ticking;

        public override void StartTicking()
        {
            if (_ticking != null)
                StopCoroutine(_ticking);
            _ticking = StartCoroutine(Ticking());
        }

        public override void StopTicking()
        {
            if (_ticking != null)
                StopCoroutine(_ticking);
        }

        private IEnumerator Ticking()
        {
            while (true)
            {
                foreach(var bus in _businesses)
                {
                    if(bus != null)
                    {
                        bus.TickProgress();
                    }
                }
                yield return null;
            }
        }



    }
}