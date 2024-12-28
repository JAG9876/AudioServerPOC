namespace AudioCollectorPOC1
{
    public class AudioRecordingDto
    {
        /// <summary>
        /// If Android device: "Android-UniqueAndroidDeviceId"
        /// </summary>
        public string DeviceId { get; set; } = string.Empty;

        /// <summary>
        /// Number of milliseconds since midnight 1970_01_01 (UTC)
        /// </summary>
        public long ReadTime { get; set; }

        // Assumes all recordings are in mono channel, 16 bit PCM, at 44100 Hz sample rate.
        public short[] AudioBuffer { get; set; } = [];
    }
}
