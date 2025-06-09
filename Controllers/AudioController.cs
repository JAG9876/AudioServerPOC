using Microsoft.AspNetCore.Mvc;

namespace AudioCollectorPOC1.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]/[action]")]
    //[Route("api/v1/[controller]")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        [HttpPost]
        //public async Task<IActionResult> PostAudio([FromBody] AudioRecording recording)
        public IActionResult PostAudio([FromBody] AudioRecordingDto recording)
        {
            if (recording.AudioBuffer.Length == 0)
            {
                return BadRequest("Invalid audio recording.");
            }

            string recordingId = _audioService.AddRecording(recording);

            var firstValue = recording.AudioBuffer.First();
            var lastValue = recording.AudioBuffer.Last();
            var msg = $"Audio recording (deviceId={recording.DeviceId}, idx={recording.BufferIndex}, {_audioService.GetRecordingCount()}) received successfully. Id={recordingId}. {firstValue}-{lastValue}";
            Console.WriteLine(msg);

            return Ok(msg); // TODO: Check if the device should send more audio, then return with a TimeRangeDto.
        }

        [HttpGet]
        public IActionResult PollForAudioRetrieval([FromQuery] string DeviceId)
        {
            TimeRangeDto interestingTimeRange = GetInterestingTimeRangeFromDevice(DeviceId);
            if (interestingTimeRange.StartTime == 0 && interestingTimeRange.EndTime == 0)
                return Ok();

            return Ok(interestingTimeRange);
        }

        private TimeRangeDto GetInterestingTimeRangeFromDevice(string deviceId)
        {
            var timeRange = new TimeRangeDto { StartTime = 0, EndTime = 0 };
            if (true)
            {
                // Get Unix time in milliseconds.
                var currentTimeMs = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Milliseconds;

                // Retrieve audio from between 30 and 25 seconds ago.
                timeRange.EndTime = currentTimeMs - 25 * 1000;
                timeRange.StartTime = timeRange.EndTime - 30 * 1000;
            }

            return timeRange;
        }
    }
}
