using StackExchange.Redis;
using System;
using Xunit;

namespace Imache.Test
{
    public class UnitTest1
    {
        const string connectionString = @"servelesschalleng.redis.cache.windows.net:6380,password=oIzHnI2a3thy2JiO6WBtxgHoTpuRizxz9h6q3O7xHpM=,ssl=True,abortConnect=False";

        [Fact]
        public void Test1()
        {
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
            IDatabase db = redis.GetDatabase();

            string value = "abcdefg";
            db.StringSet("mykey", value);
            //...
            value = db.StringGet("mykey");
            Console.WriteLine(value); // writes: "abcdefg"
        }
    }
}
