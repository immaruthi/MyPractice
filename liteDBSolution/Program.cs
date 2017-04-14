using liteDBSolution.BL;
using liteDBSolution.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liteDBSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //new ReferenceLogic().mappingRef();
                //var result = new LiteDbDAL().GetCollectionByName("Customer");
                using (var liteDbDal = new LiteDbDAL())
                {
                    //liteDbDal.OpenConnection();
                    var result = liteDbDal.GetCollectionByName("Customer");
                    //Console.WriteLine(result.ToString());
                    //var result2 = liteDbDal.GetCollectionByName();
                    //Console.WriteLine(result2.ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
