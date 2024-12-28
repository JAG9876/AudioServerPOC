using Microsoft.AspNetCore.Mvc;

namespace AudioCollectorPOC1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    //[Route("api/v1/[controller]")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioRepository _audioRepository;


        public AudioController(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        [HttpPost]
        //public async Task<IActionResult> PostAudio([FromBody] AudioRecording recording)
        public IActionResult PostAudio([FromBody] AudioRecordingDto recording)
        {
            if (recording.AudioBuffer.Length == 0)
            {
                return BadRequest("Invalid audio recording.");
            }

            var entity = new AudioRecordingEntity
            {
                DeviceId = recording.DeviceId,
                ReadTime = recording.ReadTime,
                AudioBuffer = recording.AudioBuffer
            };
            _audioRepository.AddRecording(entity);
            var msg = $"Audio recording ({_audioRepository.GetRecordingCount()}) received successfully. Id={entity.Id}.";
            Console.WriteLine(msg);

            return Ok(msg);
        }
    }
}
