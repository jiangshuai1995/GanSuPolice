using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.GridSearch
{
	public class SearchResult
	{
        private List<CsType> csType;

        public List<CsType> CsType
        {
            get { return csType; }
            set { csType = value; }
        }

        private List<Address> result;

        public List<Address> Result
        {
            get { return result; }
            set { result = value; }
        }

	}
}
