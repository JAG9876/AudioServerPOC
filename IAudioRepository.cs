namespace AudioCollectorPOC1
{
    public interface IAudioRepository
    {
        void AddRecording(AudioRecordingEntity recording);
        void SetLifetimeInMs(int lifetimeInMs);
        int GetRecordingCount();
    }
}