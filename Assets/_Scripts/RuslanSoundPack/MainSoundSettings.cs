using UnityEngine;

namespace RuslanScripts.Sound
{
    [CreateAssetMenu(fileName = "MainSoundSettings", menuName = "SO/Sound/MainSoundSettings")]

    public class MainSoundSettings : ScriptableObject
    {
        public bool EnableSound = true;
        public bool EnableMusic = true;
        public bool EnableUISounds = true;
        [Range(0f,1f)] public float MasterVolume = 1f;
        [Space(10)]
        [Range(0f, 1f)]  public float MasterMusicVolume = 1f;
        [Space(10)]
        [Range(0f, 1f)] public float MasterUIVolume = 1f;

    }

}
