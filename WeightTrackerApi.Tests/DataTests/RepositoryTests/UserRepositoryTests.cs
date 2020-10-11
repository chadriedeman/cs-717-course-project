using ChanceNET;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;
using WeightTrackerApi.DataAccess;
using WeightTrackerApi.DataAccess.Repositories;
using WeightTrackerApi.Domain.Models;

namespace WeightTrackerApi.Tests.DataTests.RepositoryTests
{
    public class UserRepositoryTests
    {
        private readonly Chance _chance;
        private IDatabaseConnectionProvider _databaseConnectionProvider;
        private UserRepository _subjectUnderTest;

        public UserRepositoryTests()
        {
            _chance = new Chance();
        }

        [SetUp]
        public void SetUp()
        {
            _databaseConnectionProvider = Substitute.For<IDatabaseConnectionProvider>();
            _subjectUnderTest = new UserRepository(_databaseConnectionProvider);
        }

        [Test]
        public void AddUser_ContainValidSqlSyntaxAndAddUser()
        {
            var user = new User();

            _subjectUnderTest.AddUser(user);

            var queryCall = _databaseConnectionProvider.ReceivedCalls()
                .First();

            var sqlQuery = queryCall.GetArguments()
                .First()
                .ToString();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void AddUserWeighIn_ShouldContainValidSqlSyntaxAndAddWeighIn()
        {
            var username = _chance.Word();

            var weighIn = new WeighIn();

            _subjectUnderTest.AddUserWeighIn(username, weighIn);

            var queryCall = _databaseConnectionProvider.ReceivedCalls()
                .First();

            var sqlQuery = queryCall.GetArguments()
                .First()
                .ToString();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
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
