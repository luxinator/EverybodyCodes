using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using API.Model;
using DatabaseLoader;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class CameraParser
    {
        private readonly CameraContext context;
        private readonly Options options;

        private readonly Regex CamLine =
            new Regex(@"(.{3}-.{2}-\d{3}[-\s])(.+)?;(\d+.?\d*);(\d+.?\d*)", RegexOptions.Compiled);


        public CameraParser(CameraContext context, Options options)
        {
            this.context = context;
            this.options = options;
        }

        public void LoadCsv()
        { 
            var cams = GetCameras().ToArray();
            var newCams = cams.Except(context.Cameras);
            
            Console.WriteLine($"Found {newCams.Count()} new cameras");
            
            context.Cameras.AddRange(newCams);
            context.SaveChanges();
        }

        private IEnumerable<Camera> GetCameras()
        {
            using (var file = File.OpenRead(options.csvPath))
            using (var stream = new StreamReader(file))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var cam = ParseLine(line);
                    if (cam == null)
                        continue;

                    yield return cam;
                }
            }
        }

        private Camera ParseLine(string line)
        {
            var m = CamLine.Match(line);

            if (!m.Success)
            {
                Console.Error.WriteLine($"Skipping line: '{line}'");
                return null;
            }

            var id = m.Groups[1].Value;
            var street = m.Groups[2].Value;
            var latStr = m.Groups[3].Value;
            var lonStr = m.Groups[4].Value;

            if (!float.TryParse(latStr, out var lat))
            {
                Console.Error.WriteLine($"Could Not parse Latitude from {line}");
                return null;
            }

            if (!float.TryParse(lonStr, out var lon))
            {
                Console.Error.WriteLine($"Could Not parse Longitude from {line}");
                return null;
            }

            return new Camera
            {
                CamId = id,
                Street = street,
                Latitude = lat,
                Longitude = lon
            };
        }

      
    }
}