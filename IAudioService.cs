namespace AudioCollectorPOC1
{
    public interface IAudioService
    {
        void AddRecording(AudioRecordingEntity recording);
        void SetLifetimeInMs(int lifetimeInMs);
        int GetRecordingCount();
    }
}