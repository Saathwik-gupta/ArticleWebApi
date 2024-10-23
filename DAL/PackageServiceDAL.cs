using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public class PackageServiceDAL : IPackageServiceDAL
    {
        private readonly ArticleContext _context;

        public PackageServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        // Get all packages
        public IEnumerable<Package> GetAllPackages()
        {
            return _context.Packages.ToList();
        }

        // Get package by ID
        public Package GetPackageById(int packageId)
        {
            return _context.Packages.Find(packageId);
        }

        // Add new package
        public void AddPackage(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        // Update package
        public void UpdatePackage(Package package)
        {
            _context.Packages.Update(package);
            _context.SaveChanges();
        }

        // Delete package
        public void DeletePackage(int packageId)
        {
            var package = _context.Packages.Find(packageId);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }
    }
}
