//GPUManager.cs
using LibreHardwareMonitor.Hardware;
using Microsoft.VisualBasic.Devices;
using System;
using System.Linq;
namespace ZyberClient.Core
{
    public struct GpuStats
    {
        public float skibidi35;
        public float skibidi36;
    }
    public class GPUManager : IDisposable
    {
        private readonly LibreHardwareMonitor.Hardware.Computer _skibidi37;
        private readonly IHardware _skibidi38;

        public GPUManager()
        {
            _skibidi37 = new LibreHardwareMonitor.Hardware.Computer
            {
                IsGpuEnabled = true
            };

            _skibidi37.Open();
            _skibidi38 = _skibidi37.Hardware.FirstOrDefault(h =>
                h.HardwareType == HardwareType.GpuNvidia ||
                h.HardwareType == HardwareType.GpuAmd ||
                h.HardwareType == HardwareType.GpuIntel);
        }

        public string GetGpuName()
        {
            return _skibidi38?.Name ?? "No GPU Found";
        }

        public GpuStats GetGpuStats()
        {
            if (_skibidi38 == null) return new GpuStats { skibidi35 = 0, skibidi36 = 0 };

            _skibidi38.Update();

            var skibidi39 = new GpuStats();

            foreach (var skibidi40 in _skibidi38.Sensors)
            {
                if (skibidi40.SensorType == SensorType.Load && skibidi40.Name.Contains("GPU Core"))
                {
                    skibidi39.skibidi35 = skibidi40.Value ?? 0;
                }
                else if (skibidi40.SensorType == SensorType.Temperature && skibidi40.Name.Contains("GPU Core"))
                {
                    skibidi39.skibidi36 = skibidi40.Value ?? 0;
                }
            }
            return skibidi39;
        }

        public void Dispose()
        {
            _skibidi37?.Close();
        }
    }
} 