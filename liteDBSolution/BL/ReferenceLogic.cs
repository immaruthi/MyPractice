using LiteDB;
using liteDBSolution.DbReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution.BL
{
    class ReferenceLogic
    {

        private LiteDatabase LiteDataBase;
        private string DbPath = @"D:\mpall3\VisualProjects\LiteDBProjects\liteDBSolution\liteDBSolution\Data\";


        public void mappingRef()
        {
            using (LiteDataBase = new LiteDatabase(DbPath + "MyData.db"))
            {

                //var cust = LiteDataBase.GetCollection<StudentComponent>("Customer");

                //var cust1 = cust.Include(x => x.AddressDetails.AddressId).FindById(1);

                //var customerCollection = LiteDataBase.GetCollection<StudentComponent>("Customer");
                //var addressCollection = LiteDataBase.GetCollection<AddressComponent>("Address");

                var customer = new StudentComponent()
                {
                    StudentId = 123,
                    AddressDetails = new AddressComponent() { AddressId=1234, pincode=567890,State="AP",Street1="#158",Street2="KRPuram" },
                    StudentName = "Maruthi"
                };

                //addressCollection.Insert(customer.AddressDetails);

                
                var doc = BsonMapper.Global.ToDocument<StudentComponent>(customer);

                var collection = LiteDataBase.GetCollection<BsonDocument>("Customer");

                collection.Insert(doc);

            }
        }
    }
}
