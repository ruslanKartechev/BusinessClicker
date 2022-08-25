using UnityEngine;
using System.Collections;
namespace RuslanScripts
{
    public interface ICoroutineRunner
    {
        Coroutine StartRoutine(IEnumerator enumerator);
        void StopRoutine(Coroutine routine);
    }
}
