using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SQLBase
{
    class SQL
    {
        SqlConnection conn = new SqlConnection("Data Source=.;database=Stu_System;Trusted_Connection=SSPI");
        SqlCommand cmd;
        SqlDataReader dr;


        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConn()
        {
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 得到查询数量
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetSelectCount(string table, string sqlWhere)
        {
            conn.Open();
            cmd = new SqlCommand("select count(*) from " + table + " where 1=1 " + sqlWhere, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return count;
        }

        /// <summary>
        /// 得到修改，删除，新增数量
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetCount(string sql)
        {
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
