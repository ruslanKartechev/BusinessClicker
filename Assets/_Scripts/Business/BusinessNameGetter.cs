using UnityEngine;
namespace RuslanScripts
{
    public abstract class BusinessNameGetter : ScriptableObject
    {
        public abstract string GetBusinessName();
        public abstract string GetModifierName(int index);

    }
}