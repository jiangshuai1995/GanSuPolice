using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeyonDB.Client;
using System.Data;

namespace Beyon.Dao
{
        /// <summary>
        /// 数据库操作类
        /// </summary>
        public class DBOperate
        {
            //连接字符串
            private String _connectStr;
            public String ConnectString
            {
                get { return _connectStr; }
                set { _connectStr = value; }
            }

            public DBOperate()
            {
                //do nothing
            }

            public DBOperate(String connectStr)
            {
                _connectStr = connectStr;
            }

            //测试数据库是否成功连接
            public bool DetectDBConnectState()
            {
                using (BeyonDBConnection conn = new BeyonDBConnection(ConnectString))
                {
                    try
                    {
                        //打开连接
                        conn.Open();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        //捕捉异常，不作其他处理
                        string str = ex.ToString();
                        return false;
                    }
                }
            }

            //执行数据库操作，插入、更新、删除
            public object ExecuteScalar(string commandText)
            {
                object result;
                if (ConnectString == null || ConnectString.Length == 0)
                    throw new ArgumentNullException("connectionString");
                if (commandText == null || commandText.Length == 0)
                    throw new ArgumentNullException("commandText");
                BeyonDBCommand cmd = new BeyonDBCommand();
                using (BeyonDBConnection conn = new BeyonDBConnection(ConnectString))
                {
                    //BeyonDB事务
                    BeyonDBTransaction trans = null;
                    if (!PrepareCommand(cmd, conn, ref trans, true, CommandType.Text, commandText, null))
                        return null;
                    try
                    {
                        result = cmd.ExecuteScalar();
                        //提交事务
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        trans.Rollback();
                        //  return null;
                        throw ex;

                    }
                }
                return result;
            }

            //执行数据库操作，插入、更新、删除
            public object ExecuteScalar(string commandText, params IDataParameter[] cmdParams)
            {
                object result;
                if (ConnectString == null || ConnectString.Length == 0)
                    throw new ArgumentNullException("connectionString");
                if (commandText == null || commandText.Length == 0)
                    throw new ArgumentNullException("commandText");
                BeyonDBCommand cmd = new BeyonDBCommand();
                using (BeyonDBConnection conn = new BeyonDBConnection(ConnectString))
                {
                    //BeyonDB事务
                    BeyonDBTransaction trans = null;
                    if (!PrepareCommand(cmd, conn, ref trans, true, CommandType.Text, commandText, cmdParams))
                        return null;
                    try
                    {
                        result = cmd.ExecuteScalar();
                        //提交事务
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        trans.Rollback();
                        //  return null;
                        throw ex;

                    }
                }
                return result;
            }


            //执行数据库查询，返回DataReader对象
            public BeyonDBDataReader ExecuteReader(string commandText)
            {
                BeyonDBDataReader result = null;
                if (ConnectString == null || ConnectString.Length == 0)
                    throw new ArgumentNullException("connectionString");
                if (commandText == null || commandText.Length == 0)
                    throw new ArgumentNullException("commandText");
                BeyonDBCommand cmd = new BeyonDBCommand();
                BeyonDBConnection con = new BeyonDBConnection(ConnectString);

                BeyonDBTransaction trans = null;
                if (!PrepareCommand(cmd, con, ref trans, true, CommandType.Text, commandText, null))
                    return null;
                try
                {
                    result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return result;
                }
                catch (Exception ex)
                {

                    con.Close();
                    return null;
                    throw ex;
                }
            }

            //执行数据库查询
            public DataSet ExecuteDataSet(string commandText)
            {
                DataSet ds = new DataSet();
                if (ConnectString == null || ConnectString.Length == 0)
                    throw new Exception("数据库连接字符串为空！");
                if (commandText == null || commandText.Length == 0)
                    throw new Exception("SQL 语句为空！");
                BeyonDBCommand cmd = new BeyonDBCommand();
                using (BeyonDBConnection con = new BeyonDBConnection(ConnectString))
                {
                    BeyonDBTransaction trans = null;
                    if (!PrepareCommand(cmd, con, ref trans, true, CommandType.Text, commandText, null))
                        return ds;
                    try
                    {
                        BeyonDBDataAdapter sda = new BeyonDBDataAdapter(cmd);
                        sda.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            if (con.State == ConnectionState.Open)
                                con.Clone();
                        }
                    }
                }
                return ds;
            }

            //预处理命令
            private bool PrepareCommand(BeyonDBCommand cmd, BeyonDBConnection conn, ref BeyonDBTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params IDataParameter[] cmdParms)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = cmdText;
                    if (useTrans)
                    {
                        //启动事务，关联事务
                        trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                        cmd.Transaction = trans;
                    }
                    cmd.CommandType = cmdType;
                    if (cmdParms != null)
                    {
                        foreach (BeyonDBParameter p in cmdParms)
                            cmd.Parameters.Add(p);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
}
