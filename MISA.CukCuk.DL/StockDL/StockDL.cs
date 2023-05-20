using Dapper;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.ProceduceName;
using MISA.CukCuk.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.StockDL
{
    public class StockDL : BaseDL<Stock>,IStockDL
    {
    }
}
