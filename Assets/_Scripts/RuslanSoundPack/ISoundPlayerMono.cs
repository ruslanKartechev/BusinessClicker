using UnityEngine;

namespace RuslanScripts.Sound
{
    public abstract class ISoundPlayerMono : MonoBehaviour
    {
        public abstract AudioClip CurrentClip { get; }
        public abstract void PlayOnce();
        public abstract void PlayLoop();
        public abstract void StopLoop();
    }
}