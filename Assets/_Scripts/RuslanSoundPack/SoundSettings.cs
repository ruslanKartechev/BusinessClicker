using UnityEngine;

namespace RuslanScripts.Sound
{
    [System.Serializable]
    public struct SoundSettings
    {
        [Tooltip("Cannot be null")] public AudioClip Clip;
        [Tooltip("Might be null, will use one from pool")] public AudioSource mySource;
        [Range(0f, 1f)] public float BaseVolume;
        [Range(0f, 1f)] public float BasePitch;
        [Space(10)]
        public bool Randomize;
        [Range(0f, 1f)] public float Volume_min;
        [Range(0f, 1f)] public float Volume_max;
        [Space(5)]
        [Range(0f, 1f)] public float Pitch_min;
        [Range(0f, 1f)] public float Pitch_max;

        public float GetVolume()
        {
            if(Randomize == true)
            {
                return UnityEngine.Random.Range(Volume_min, Volume_max) * BaseVolume;
                
            }
            return BaseVolume;
        }

        public float GetPitch()
        {
            if (Randomize == true)
            {
                return UnityEngine.Random.Range(Pitch_min, Pitch_max) * BasePitch;

            }
            return BasePitch;
        }
    }

}
