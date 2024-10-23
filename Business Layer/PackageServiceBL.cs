using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.Models;


namespace ArticleWebApi.Services
{
    public class PackageServiceBL : IPackageServiceBL
    {
        private readonly IPackageServiceDAL _packageDAL;

        public PackageServiceBL(IPackageServiceDAL packageDAL)
        {
            _packageDAL = packageDAL;
        }

        public IEnumerable<Package> GetAllPackages()
        {
            return _packageDAL.GetAllPackages();
        }

        public Package GetPackageById(int packageId)
        {
            return _packageDAL.GetPackageById(packageId);
        }

        public void AddPackage(Package package)
        {
            _packageDAL.AddPackage(package);
        }

        public void UpdatePackage(Package package)
        {
            _packageDAL.UpdatePackage(package);
        }

        public void DeletePackage(int packageId)
        {
            _packageDAL.DeletePackage(packageId);
        }
    }
}
