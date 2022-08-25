using System.Collections.Generic;
using UnityEngine;

namespace RuslanScripts
{
    public abstract class IBusinessTicker : MonoBehaviour
    {
        public abstract List<BusinessBase> Businesses {get; set;}

        public abstract void StartTicking();
        public abstract void StopTicking();
    }
}