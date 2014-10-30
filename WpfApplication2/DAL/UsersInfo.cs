using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using SQLBase;

namespace WpfApplication2.DAL
{
    class UsersInfo
    {
        SQL SQL = new SQL();

        int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        string loginPwd;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        string cName;

        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string demo;

        public string Demo
        {
            get { return demo; }
            set { demo = value; }
        }
        /// <summary>
        /// 获得单个数据
        /// </summary>
        /// <param name="LoinName"></param>
        public void GetOne(string LoinName)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,LoginName,LoginPwd,CName,Phone,Demo from Users where LoginName='" + LoinName + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            id = Convert.ToInt32(dr["ID"]);
            loginName = dr["LoginName"].ToString();
            loginPwd = dr["LoginPwd"].ToString();
            cName = dr["CName"].ToString();
            phone = dr["Phone"].ToString();
            demo = dr["Demo"].ToString();
        }
        /// <summary>
        /// 绑定gridview
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlBase(string SqlWhere, object DataGrid)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,LoginName,LoginPwd,CName,Phone,Demo from Users where ID<>1" + SqlWhere, conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataGridView dgv = (DataGridView)DataGrid;
            //int count = 0;
            //while (dr.Read())
            //    count++;
            //conn.Close();
            if (dr.HasRows)
            {
                int i = 0;
                //dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv[0, i].Value = dr["ID"].ToString();
                    dgv[1, i].Value = dr["LoginName"].ToString();
                    dgv[2, i].Value = dr["LoginPwd"].ToString();
                    dgv[3, i].Value = dr["CName"].ToString();
                    dgv[4, i].Value = dr["Phone"].ToString();
                    dgv[5, i].Value = dr["Demo"].ToString();
                    i++;
                }
                //conn.Close();
            }
            conn.Close();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <param name="CName"></param>
        /// <param name="Phone"></param>
        /// <param name="Demo"></param>
        /// <returns></returns>
        public int Add(string ID, string LoginName, string LoginPwd, string CName, string Phone, string Demo)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "insert into User values('" + ID + "','" + LoginName + "','" + LoginPwd + "','" + CName + "','" + Phone + "','" + Demo + "')";
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
        /// <summary>
        /// 获取下一个ID
        /// </summary>
        /// <returns></returns>
        public int GetNextID()
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "select count(*) from User";
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            conn.Close();
            return count;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int Update(string sql, string strWhere)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "update User set " + sql + "where " + strWhere;
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int Delete(string strWhere)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "delete from User where " + strWhere;
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
