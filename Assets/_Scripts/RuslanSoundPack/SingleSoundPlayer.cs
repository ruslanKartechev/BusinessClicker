using UnityEngine;

namespace RuslanScripts.Sound
{
    public class SingleSoundPlayer : ISoundPlayerMono
    {
        public SoundSettings PlaySound;
        public SoundPlayChannel Channel;
        public AudioSource Source;
        public override AudioClip CurrentClip => PlaySound.Clip;

        public override void PlayLoop()
        {
            Channel.PlaySoundLoop(Source, PlaySound);
        }

        public override void PlayOnce()
        {
            Channel.PlaySoundOnce(Source, PlaySound);
        }

        public override void StopLoop()
        {
            Channel.StopLoop(Source);
        }
    }
}