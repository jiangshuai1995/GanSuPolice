using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.GridSearch
{
	public class CsType
	{
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string mc;

        public string Mc
        {
            get { return mc; }
            set { mc = value; }
        }

	}
}
