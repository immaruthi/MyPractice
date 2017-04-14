using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution.DbReference
{
    public class AddressComponent
    {
        [BsonId]
        public int AddressId { get; set; }
        [BsonField]
        public string Street1 { get; set; }
        [BsonField]
        public string Street2 { get; set; }
        [BsonField]
        public string State { get; set; }
        [BsonField]
        public long pincode { get; set; }
    }
}
