using LiteDB;
using liteDBSolution.BsonMappers;
using liteDBSolution.DbReference;
using liteDBSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution.DAL
{
    public  class LiteDbDAL : IDisposable
    {
        
        private LiteDatabase LiteDataBase;
        private string DbPath = @"D:\mpall3\VisualProjects\LiteDBProjects\liteDBSolution\liteDBSolution\Data\";

        public void OpenConnection()
        {
            using (LiteDataBase = new LiteDatabase(DbPath+"MyData.db"))
            {
                 //Create a new one, If there is no any collection
                var collection = LiteDataBase.GetCollection<Customer>("Customer");

                var customer = new Customer() { Id = 1, IsActive = false, Name = "Pallamalli", Phones = new string[] { "9988776655","9912345678" } };

                collection.Insert(customer);

            }
        }

        public void CreateBsonDocumentCollection()
        {
            using(LiteDataBase =new LiteDatabase(DbPath+"MyData.db"))
            {
                var bsonDocument = GetBsonDocument();
                var collection = LiteDataBase.GetCollection<BsonDocument>("BCustomer");
                collection.Insert(bsonDocument);
            }
        }


        public IEnumerable<Product> GetProductList()
        {
            List<Product> listProduct = new List<Product>();

            listProduct.Add(new Product() { FirstName = "X-Product-09", AliasName = "Axel" });
            listProduct.Add(new Product() { FirstName = "X-Product-09", AliasName = "Axel" });

            return listProduct;
        }

        public IEnumerable<BsonDocument> GetCollectionByName(string collectionName = "BCustomer")
        {

            ////BsonMapper.Global.RegisterAutoId(value => value.Equals(ObjectId.Empty));

            //var doc = BsonMapper.Global.ToDocument(new Product()
            //    {
            //        FirstName = "X-Product-09",
            //        AliasName = "Axel"
            //    });

            //doc = BsonMapper.Global.ToDocument(new Product()
            //    {
            //        FirstName = "X-Product-099",
            //        AliasName = "Axel9"
            //    });

            using (LiteDataBase = new LiteDatabase(DbPath + "MyData.db"))
            {
                var collection = LiteDataBase.GetCollection<Product>("Customer");
                var resp = collection.Insert(GetProductList());
                collection.EnsureIndex(x => x.FirstName);
            }

            //int id = doc["_id"].AsInt32;
            //string ProductFirstName = doc["FirstName"].AsString;
            //string ProductAliasName = doc["ProductAliasName"].AsString;

            using (LiteDataBase = new LiteDatabase(DbPath + "MyData.db"))
            {
                return LiteDataBase.GetCollection(collectionName).FindAll();
            }
        }

        public BsonDocument GetBsonDocument()
        {
            var customerDocument = new BsonDocument();
            customerDocument["_id"] = ObjectId.NewObjectId();
            customerDocument["Name"] = "pallamalli";
            customerDocument["CreatedDate"] = DateTime.Now;
            customerDocument["Phones"] = new BsonArray { "8008580085", "9008590085" };
            customerDocument["IsAdmin"] = new BsonValue(true);
            customerDocument.Set("Address.Steet", "C-24,HighSchool Road");
            return customerDocument;
        }

        public object GetSerializeDocument()
        {

            var customer = new Customer() { Id = 1, IsActive = false, Name = "Pallamalli", Phones = new string[] { "9988776655", "9912345678" } };

            var doc = BsonMapper.Global.ToDocument(customer);

            var id = ObjectId.NewObjectId();

            return JsonSerializer.Serialize(doc, pretty: false, writeBinary: true);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            // Todo : Free your resource
        }
    }
}
