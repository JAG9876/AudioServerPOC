namespace AudioCollectorPOC1
{
    public class AudioRepository : IAudioRepository
    {
        private readonly List<AudioRecordingEntity> _recordings = [];
        private int _lifetimeInMs = 10 * 1000;
        private long _oldestReadTime = long.MaxValue;

        public void AddRecording(AudioRecordingEntity recording)
        {
            if (RecordingIsTooOld(recording.ReadTime))
                return;

            _recordings.Add(recording);

            if (recording.ReadTime < _oldestReadTime)
                _oldestReadTime = recording.ReadTime;

            Cleanup();
        }

        public int GetRecordingCount()
        {
            return _recordings.Count;
        }

        public void SetLifetimeInMs(int lifetimeInMs)
        {
            _lifetimeInMs = lifetimeInMs;
        }

        private bool RecordingIsTooOld(long readTime)
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (now - readTime) > _lifetimeInMs;
        }

        private void Cleanup()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (now - _oldestReadTime > _lifetimeInMs)
                _recordings.RemoveAll(r => now - r.ReadTime > _lifetimeInMs);

            _oldestReadTime = _recordings.Min(r => r.ReadTime);
        }
    }
}
