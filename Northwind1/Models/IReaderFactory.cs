using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Northwind1.Models
{
    public interface IReaderFactory
    {
        IDataReader GetReader(string sql);
    }
}