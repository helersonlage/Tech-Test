using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradeMeTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMeTechTest.Models.Tests
{
    [TestClass()]
    public class PackageTests
    {
        [TestMethod()]
        public void GetBestPackageTest()
        {

            IPackage pkg = new Package();

            // Get Package Type
            IList<Package> PkgTypes = pkg.GetPackageType();

            //Small Box
            IPackage Pkgtype = PkgTypes.Where(s => s.Name.Equals("Small")).First();
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth, Pkgtype.Height, Pkgtype.Weight).Name, "Small");
            
            // Small sizes + 1 = Medium 
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length + 1, Pkgtype.Breadth, Pkgtype.Height, Pkgtype.Weight).Name, "Medium");
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth +1, Pkgtype.Height, Pkgtype.Weight).Name, "Medium");
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth, Pkgtype.Height + 1 , Pkgtype.Weight).Name, "Medium");

            //Medium Box 
            Pkgtype = PkgTypes.Where(s => s.Name.Equals("Medium")).First();
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth, Pkgtype.Height, Pkgtype.Weight).Name, "Medium");
           
            // Medium Sizes + 1 = Medium 
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length + 1, Pkgtype.Breadth, Pkgtype.Height, Pkgtype.Weight).Name, "Large");
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth + 1, Pkgtype.Height, Pkgtype.Weight).Name, "Large");
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth, Pkgtype.Height + 1, Pkgtype.Weight).Name, "Large");


            // Large Box 
            Pkgtype = PkgTypes.Where(s => s.Name.Equals("Large")).First();
            Assert.AreEqual(pkg.GetBestPackage(Pkgtype.Length, Pkgtype.Breadth, Pkgtype.Height, Pkgtype.Weight).Name, "Large");

            // Over Lenght
            Assert.AreEqual(pkg.GetBestPackage(401,1,1,0.1).Name, null);
            
            // Over Breadth
            Assert.AreEqual(pkg.GetBestPackage(1, 601,1,0.1).Name, null);

            // Over Height
            Assert.AreEqual(pkg.GetBestPackage(1, 1,251, 0.1).Name, null);

            // Over Weight
            Assert.AreEqual(pkg.GetBestPackage(1, 1, 1, 25.001).Name, null);

            // Zero Values
            Assert.AreEqual(pkg.GetBestPackage(0, 0, 0, 0.1).Name, null);           
            Assert.AreEqual(pkg.GetBestPackage(0, 0, 0, 0).Name, null);

            //Negative Values
            Assert.AreEqual(pkg.GetBestPackage(-1, 1, 1, 1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(-1, -1, 1, 1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(-1, -1, -1, 1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(-1, -1, -1, -1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(1, -1, 1, 1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(1, 1, -1, 1).Name, null);
            Assert.AreEqual(pkg.GetBestPackage(1, 1, 1, -1).Name, null);



        }

      

    }
}