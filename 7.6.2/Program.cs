using System;

namespace AdapterCustom
{
    class OldAudioSystem
    {
        public string PlayMonoTrack()
        {
            return "old mono analog sound";
        }
    }


    interface INewAudioSystem
    {
        string PlayDigitalSurroundTrack();
    }


    class ModernAudioSystem : INewAudioSystem
    {
        public string PlayDigitalSurroundTrack()
        {
            return "modern digital surround 5.1 sound";
        }
    }

 
    class AudioAdapter : INewAudioSystem
    {
        private readonly OldAudioSystem _adaptee;

        public AudioAdapter(OldAudioSystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string PlayDigitalSurroundTrack()
        {
            return _adaptee.PlayMonoTrack();
        }
    }

    class AudioPlayerClient
    {
        public static void OutputSound(INewAudioSystem audioSystem)
        {
            Console.WriteLine(audioSystem.PlayDigitalSurroundTrack());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            var modernSystem = new ModernAudioSystem();
            AudioPlayerClient.OutputSound(modernSystem);

            var oldSystem = new OldAudioSystem();
            var adapter = new AudioAdapter(oldSystem);
            AudioPlayerClient.OutputSound(adapter);

            Console.ReadKey();
        }
    }
}