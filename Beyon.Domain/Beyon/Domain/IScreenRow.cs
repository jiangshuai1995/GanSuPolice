namespace Beyon.Domain
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public interface IScreenRow
    {
        string GetHostURL(string xzqh);
        string GetResultURL(string[] param);
        string GetResultURLTwoParam(string type, string xzqh);
        DataRow Screen(string xzqhID, AffairsType at, string xzqh = "XZQH");

        string NewUrlParam { get; set; }
    }
}

