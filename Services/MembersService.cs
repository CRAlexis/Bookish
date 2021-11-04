using System.Collections.Generic;
using Bookish.Models.View;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IMembersService
    {
        IEnumerable<MemberViewModel> GetAll();
        MemberViewModel GetById(int id);

    }

    public class MembersService : IMembersService
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=bookish;Username=postgres;Password=Mittens.data.biz";

        public IEnumerable<MemberViewModel> GetAll()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<MemberViewModel>("SELECT * FROM members");
        }
        
        public MemberViewModel GetById(int id)
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            var parameters = new {Id = id};
            return connection.QuerySingle<MemberViewModel>("SELECT * FROM members WHERE id = @Id", parameters);
        }
        
    }
}
