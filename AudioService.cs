namespace AudioCollectorPOC1
{
    public class AudioService(IAudioRepository audioRepository) : IAudioService
    {
        public string AddRecording(AudioRecordingDto recording)
        {
            var entity = new AudioRecordingEntity
            {
                DeviceId = recording.DeviceId,
                ReadTime = recording.ReadTime,
                AudioBuffer = recording.AudioBuffer
            };
            audioRepository.AddRecording(entity);
            return entity.Id;
        }

        public int GetRecordingCount()
        {
            return audioRepository.GetRecordingCount();
        }

        public void SetLifetimeInMs(int lifetimeInMs)
        {
            audioRepository.SetLifetimeInMs(lifetimeInMs);
        }
    }
}
