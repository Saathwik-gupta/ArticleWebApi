using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public interface IPackageServiceBL
    {
        IEnumerable<Package> GetAllPackages();
        Package GetPackageById(int packageId);
        void AddPackage(Package package);
        void UpdatePackage(Package package);
        void DeletePackage(int packageId);
    }
}
