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
    class ClassesInfo
    {
        SQL SQL = new SQL();

        string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        string cName;

        public string CName
        {
            get { return cName; }
            set { cName = value; }
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
        public void GetOne(string strWhere)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,CName,Demo from Classes where 1=1 " + strWhere + "", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            id = dr["ID"].ToString();
            cName = dr["CName"].ToString();
            demo = dr["Demo"].ToString();
            conn.Close();
        }
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlBase(string SqlWhere, object combobox)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,CName,Demo from Classes where 1=1" + SqlWhere, conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ComboBox combox = (ComboBox)combobox;
            //int count = 0;
            //while (dr.Read())
            //    count++;
            //conn.Close();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    combox.Items.Add(dr["CName"].ToString());
                }
            }
            conn.Close();
        }
        /// <summary>
        /// 绑定gridview
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlgvw(string SqlWhere, object DataGrid)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,CName,Demo from Classes where 1=1" + SqlWhere, conn);
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
                    dgv[1, i].Value = dr["CName"].ToString();
                    dgv[2, i].Value = dr["Demo"].ToString();
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
        /// <param name="CName"></param>
        /// <param name="Demo"></param>
        /// <returns></returns>
        public int Add(string ID, string CName, string Demo)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "insert into Student values('" + ID + "','" + CName + "','" + Demo + "')";
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
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
            string strsql = "update Classes set " + sql + "where " + strWhere;
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
            string strsql = "delete from Classes where " + strWhere;
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
