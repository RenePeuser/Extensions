using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Extensions
{
    public static class DriveInfoExtensions
    {
        public static double AvailableFreeSpaceGb(this DriveInfo driveInfo, int decimals = 1)
        {
            Contract.Requires(driveInfo.IsNotNull());

            var divisor = Math.Pow(1024, 3);
            var result = driveInfo.TotalFreeSpace / divisor;
            return Math.Round(result, 1);
        }
    }
}