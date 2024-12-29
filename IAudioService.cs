namespace AudioCollectorPOC1
{
    public interface IAudioService
    {
        string AddRecording(AudioRecordingDto recording);
        void SetLifetimeInMs(int lifetimeInMs);
        int GetRecordingCount();
    }
}