using ChanceNET;
using NSubstitute;
using NUnit.Framework;
using WeightTrackerApi.DataAccess;
using WeightTrackerApi.DataAccess.Repositories;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.DataTests.RepositoryTests
{
    public class UserRepositoryTests
    {
        private readonly Chance _chance;
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        private readonly UserRepository _subjectUnderTest;

        public UserRepositoryTests()
        {
            _chance = new Chance();
            _databaseConnectionProvider = Substitute.For<IDatabaseConnectionProvider>();
            _subjectUnderTest = new UserRepository(_databaseConnectionProvider);
        }

        [Test]
        public void AddUser_ShouldContainValidSqlSyntax()
        {
            var user = new User
            {
                Username = _chance.Word(),
                FirstName = _chance.Word(),
                LastName = _chance.Word()
            };

            _subjectUnderTest.AddUser(user);

            var query = ""; // TODO

            DatabaseTestsHelper.ValidateSqlQuery(query);
        }
    }
}
