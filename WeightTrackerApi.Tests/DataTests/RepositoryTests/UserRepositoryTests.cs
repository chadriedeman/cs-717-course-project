using ChanceNET;
using NSubstitute;
using NUnit.Framework;
using System;
using WeightTrackerApi.DataAccess;
using WeightTrackerApi.DataAccess.Repositories;

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
            throw new NotImplementedException();
        }

        [Test]
        public void AddUserWeighIn_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetUser_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void UpdateUser_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void DeleteUser_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetUserWeighIn_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void DeleteUserWeighIn_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void UpdateUserWeighIn_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetUserWeighIns_ShouldContainValidSqlSyntax()
        {
            throw new NotImplementedException();
        }
    }
}
