using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution.BsonMappers
{

    public class Product
    {
        public int ProductId { get; set; }

        [BsonIndex]
        public string FirstName { get; set; }

        [BsonIndex(true)]
        [BsonField("ProductAliasName")]
        public string AliasName { get; set; }
    }
}
