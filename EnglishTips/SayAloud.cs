using System;
using System.Speech.Synthesis;


namespace MySupervisor
{
    /// <summary>
    /// Example of static class, doesnt need to be initialized, just use it like namespace.
    /// <example> SayAloud.Say("Something"); </example>
    /// </summary>
    static class SayAloud
    {
        public static void Say(string text)
        {
            // Initialization of synthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output.
            synth.SetOutputToDefaultAudioDevice();

            // Say da thing
            synth.Speak(text);
        }
    }
}
