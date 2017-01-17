using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.GridSearch
{
	public class Address
	{
        private string unitName;

        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }

        private string fldm;

        public string Fldm
        {
            get { return fldm; }
            set { fldm = value; }
        }

        private string mc;

        public string Mc
        {
            get { return mc; }
            set { mc = value; }
        }

        private string sjzgdw;

        public string Sjzgdw
        {
            get { return sjzgdw; }
            set { sjzgdw = value; }
        }

        private double jd;

        public double Jd
        {
            get { return jd; }
            set { jd = value; }
        }

        private double wd;

        public double Wd
        {
            get { return wd; }
            set { wd = value; }
        }

        private string dz;

        public string Dz
        {
            get { return dz; }
            set { dz = value; }
        }

        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string objectid;
        public string OBJECTID
        {
            get { return objectid; }
            set { objectid = value; }
        }

	}
}
