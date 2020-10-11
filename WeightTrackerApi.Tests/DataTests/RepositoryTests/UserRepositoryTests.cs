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

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void AddUserWeighIn_ShouldContainValidSqlSyntaxAndAddWeighIn()
        {
            var username = _chance.Word();

            var weighIn = new WeighIn();

            _subjectUnderTest.AddUserWeighIn(username, weighIn);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void GetUser_ShouldContainValidSqlSyntaxAndGetUser()
        {
            var username = _chance.Word();

            _subjectUnderTest.GetUser(username);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).QuerySingle<User>(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void UpdateUser_ShouldContainValidSqlSyntaxAndUpdateUser()
        {
            var user = new User();

            _subjectUnderTest.UpdateUser(user);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void DeleteUser_ShouldContainValidSqlSyntaxAndDeleteUser()
        {
            var username = _chance.Word();

            _subjectUnderTest.DeleteUser(username);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void GetUserWeighIn_ShouldContainValidSqlSyntaxAndGetWeighIn()
        {
            var username = _chance.Word();

            var date = _chance.Date();

            _subjectUnderTest.GetUserWeighIn(username, date);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).QuerySingle<WeighIn>(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void UpdateUserWeighIn_ShouldContainValidSqlSyntaxAndUpdateWeighIn()
        {
            var username = _chance.Word();

            var weighIn = new WeighIn();

            _subjectUnderTest.UpdateUserWeighIn(username, weighIn);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).ExecuteScalar(Arg.Any<string>(), Arg.Any<object>());
        }

        [Test]
        public void GetUserWeighIns_ShouldContainValidSqlSyntaxAndGetWeighIns()
        {
            var username = _chance.Word();

            var date = _chance.Date();

            _subjectUnderTest.GetUserWeighIn(username, date);

            var sqlQuery = GetSqlQuery();

            DatabaseTestsHelper.ValidateSqlQuery(sqlQuery);

            _databaseConnectionProvider.Received(1).QuerySingle<WeighIn>(Arg.Any<string>(), Arg.Any<object>());
        }

        private string GetSqlQuery()
        {
            var queryCall = _databaseConnectionProvider.ReceivedCalls()
                .First();

            var sqlQuery = queryCall.GetArguments()
                .First()
                .ToString();

            return sqlQuery;
        }
    }
}
