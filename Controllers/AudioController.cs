using Microsoft.AspNetCore.Mvc;

namespace AudioCollectorPOC1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
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

            var msg = $"Audio recording ({_audioService.GetRecordingCount()}) received successfully. Id={recordingId}.";
            Console.WriteLine(msg);

            return Ok(msg);
        }
    }
}
