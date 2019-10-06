using API.Model;

namespace API.DTO
{
    public static class Mappers
    {
        public static CameraDto MapToDto(this Camera cam) =>
            new CameraDto
            {
                Id = cam.Id,
                Latitude = cam.Latitude,
                Longitude = cam.Longitude,
                Street = cam.Street,
                CamId = cam.CamId
            };
    }
}