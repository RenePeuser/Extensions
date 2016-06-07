using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic.Devices;

namespace Extensions
{
    public static class ComputerInfoExtensions
    {
        public static double AvailablePhysicalMemoryInGb(this ComputerInfo computerInfo, int decimals = 1)
        {
            Contract.Requires(computerInfo.IsNotNull());

            return CalculateValue(computerInfo.AvailablePhysicalMemory, 3, decimals);
        }

        public static double TotalPhysicalMemoryInGb(this ComputerInfo computerInfo, int decimals = 1)
        {
            Contract.Requires(computerInfo.IsNotNull());

            return CalculateValue(computerInfo.TotalPhysicalMemory, 3, decimals);
        }

        public static double AvailablePhysicalMemoryInMb(this ComputerInfo computerInfo, int decimals = 0)
        {
            Contract.Requires(computerInfo.IsNotNull());

            return CalculateValue(computerInfo.AvailablePhysicalMemory, 2, decimals);
        }

        public static double TotalPhysicalMemoryInMb(this ComputerInfo computerInfo, int decimals = 0)
        {
            Contract.Requires(computerInfo.IsNotNull());

            return CalculateValue(computerInfo.TotalPhysicalMemory, 2, decimals);
        }

        private static double CalculateValue(ulong value, int powValue, int decimals)
        {
            var divisor = Math.Pow(1024, powValue);
            var result = value / divisor;
            return Math.Round(result, decimals);
        }
    }
}