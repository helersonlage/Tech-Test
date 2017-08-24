using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeMeTechTest.Models
{

    public class Package : IPackage
    {  

        const double MaxWeight = 25.00;

        public string Name { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }        

        public Package GetBestPackage(int length, int breadth, int height, double weight)
        {
            Package package = NewPackage(length, breadth, height, weight);
            Package BestPrice;
            List<Package> packageCompatibles = new List<Package>();
            packageSizes = GetPackageType();

            try
            {
                //Check Min and Max Values 
                CheckMinMaxValues(package);

                Parallel.ForEach(packageSizes, pkg =>
                {
                    if (package.Height <= pkg.Height && package.Length <= pkg.Length && package.Breadth <= pkg.Breadth)
                        packageCompatibles.Add(pkg);

                });

                // Get lower cost
                BestPrice = packageCompatibles.OrderBy(p => p.Cost).FirstOrDefault();
            }
            catch
            {
                BestPrice = new Package();
            }

            return BestPrice;
        }

        public List<Package> GetPackageType()
        {
            List<Package> GetPackageType = new List<Package>();

            Package small = new Package();
            small.Name = "Small";
            small.Length = 200;
            small.Breadth = 300;
            small.Height = 150;
            small.Weight = 25.00;
            small.Cost = 5.00;
            GetPackageType.Add(small);

            Package medium = new Package();
            medium.Name = "Medium";
            medium.Length = 300;
            medium.Breadth = 400;
            medium.Height = 200;
            medium.Weight = 25.00;
            medium.Cost = 7.50;
            GetPackageType.Add(medium);

            Package Large = new Package();
            Large.Name = "Large";
            Large.Length = 400;
            Large.Breadth = 600;
            Large.Height = 250;
            Large.Weight = 25.00;
            Large.Cost = 8.50;
            GetPackageType.Add(Large);

            return GetPackageType;

        }

        private List<Package> packageSizes;

        private void CheckMinMaxValues(Package package)
        {
            if (packageSizes.Count == 0)
                packageSizes = GetPackageType();


            Package MaxSize = packageSizes.Where(a => a.Name.ToLower().Equals("large")).FirstOrDefault();
            if (package.Length < 1 || package.Length > MaxSize.Length) throw new Exception("Invalid Length");
            if (package.Breadth < 1 || package.Breadth > MaxSize.Breadth) throw new Exception("Invalid Breadth");
            if (package.Height < 1 || package.Height > MaxSize.Height) throw new Exception("Invalid Height");
            if (package.Weight < 0.001 || package.Weight > MaxSize.Weight) throw new Exception("Invalid Weight");
        }

        private Package NewPackage(int length, int breadth, int height, double weight)
        {
            Package package = new Package();
            package.Length = length;
            package.Breadth = breadth;
            package.Height = height;
            package.Weight = weight;

            return package;

        }
    }

}