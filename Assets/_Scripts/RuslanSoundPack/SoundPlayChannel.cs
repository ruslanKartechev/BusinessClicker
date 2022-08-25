using UnityEngine;

namespace RuslanScripts.Sound
{
    [CreateAssetMenu(fileName = "SoundPlayChannel", menuName = "SO/Sound/SoundPlayChannel")]
    public class SoundPlayChannel : ScriptableObject
    {
        [SerializeField] private MainSoundSettings _mainSettings;

        public void PlaySoundOnce(AudioSource source, SoundSettings settings)
        {
            if(_mainSettings.EnableSound == false)
            {
                return;
            }

            if(source == null)
            {
                source = settings.mySource;
                if(source == null)
                {
                    Debug.Log("NO AUDIO SOURCE PROVIDED");
                    return;
                }
            }
            var volume = settings.GetVolume() * _mainSettings.MasterVolume ;
            var pitch = settings.GetPitch();
            source.clip = settings.Clip;
            source.volume = volume;
            source.pitch = pitch;
            source.loop = false;
            source.Play();
        }

        public void PlaySoundLoop(AudioSource source, SoundSettings settings)
        {
            if (source == null)
            {
                source = settings.mySource;
                if (source == null)
                {
                    Debug.Log("NO AUDIO SOURCE PROVIDED");
                    return;
                }
            }
            var volume = settings.GetVolume();
            var pitch = settings.GetPitch();
            source.volume = volume;
            source.pitch = pitch;
            source.loop = true;
            source.Play();
        }

        public void StopLoop(AudioSource source)
        {
            if (source == null)
                return;
            source.Stop();
            source.loop = false;
        }

        public void PlayMusicTrack(AudioSource source, SoundSettings settings)
        {
            if (_mainSettings.EnableMusic == false)
            {
                return;
            }

            if (source == null)
            {
                source = settings.mySource;
                if (source == null)
                {
                    Debug.Log("NO AUDIO SOURCE PROVIDED");
                    return;
                }
            }
            var volume = settings.GetVolume() * _mainSettings.MasterMusicVolume;
            var pitch = settings.GetPitch();
            source.clip = settings.Clip;
            source.volume = volume;
            source.pitch = pitch;
            source.loop = false;
            source.Play();
        }
    }

}
