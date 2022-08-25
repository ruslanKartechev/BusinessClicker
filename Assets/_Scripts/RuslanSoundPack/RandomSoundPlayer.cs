using System.Collections.Generic;
using UnityEngine;

namespace RuslanScripts.Sound
{
    public class RandomSoundPlayer : ISoundPlayerMono
    {
        public List<SoundSettings> PlaySoundOptions;
        public SoundPlayChannel Channel;
        public AudioSource Source;

        public override AudioClip CurrentClip => _currentClip;
        private AudioClip _currentClip;
        public override void PlayLoop()
        {
            var sound = GetRandomSound();
            _currentClip = sound.Clip;
            Channel.PlaySoundLoop(Source, sound);
        }

        public override void PlayOnce()
        {
            var sound = GetRandomSound();
            _currentClip = sound.Clip;
            Channel.PlaySoundOnce(Source, sound);
        }

        public override void StopLoop()
        {
            Channel.StopLoop(Source);
        }


        private SoundSettings GetRandomSound()
        {
            int index = UnityEngine.Random.Range(0, PlaySoundOptions.Count);
            return PlaySoundOptions[index];
        }
    }
}