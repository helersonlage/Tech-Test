using System.Collections.Generic;

namespace TradeMeTechTest.Models
{

    public interface IPackage
    {
        int Breadth { get; set; }
        double Cost { get; set; }
        int Height { get; set; }
        int Length { get; set; }
        string Name { get; set; }
        double Weight { get; set; }

        Package GetBestPackage(int length, int breadth, int height, double weight);

        List<Package> GetPackageType();
    }

}