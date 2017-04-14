using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution.DbReference
{
    public class StudentComponent
    {
        [BsonId]
        public int StudentId { get; set; }
        [BsonField]
        public string StudentName { get; set; }

        [BsonRef("Address")]
        public AddressComponent AddressDetails { get; set; }
    }
}
