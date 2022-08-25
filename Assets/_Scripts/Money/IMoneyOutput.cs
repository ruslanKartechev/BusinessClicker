using UnityEngine;
namespace RuslanScripts
{
    public abstract class IMoneyOutput : MonoBehaviour
    {
        public abstract void UpdateCount(float money);
    }
}