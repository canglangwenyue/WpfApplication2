using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SQLBase;
using System.Windows.Forms;

namespace WpfApplication2.DAL
{
    class TeacherInfo
    {
        SQL SQL = new SQL();

        string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        string sorting;

        public string Sorting
        {
            get { return sorting; }
            set { sorting = value; }
        }
        string cName;

        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }
        string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        string idCard;

        public string IdCard
        {
            get { return idCard; }
            set { idCard = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        string demo;

        public string Demo
        {
            get { return demo; }
            set { demo = value; }
        }

        /// <summary>
        /// 绑定gridview
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlBase(string SqlWhere, object DataGrid)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,Sorting,CName,Sex,IdCard,Phone,Address,Demo from Teacher where 1=1 " + SqlWhere, conn);
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
                    dgv[2, i].Value = dr["Sorting"].ToString();
                    dgv[3, i].Value = dr["Sex"].ToString();
                    dgv[4, i].Value = dr["IdCard"].ToString();
                    dgv[5, i].Value = dr["Phone"].ToString();
                    dgv[6, i].Value = dr["Demo"].ToString();
                    i++;
                }
                //conn.Close();
            }
            conn.Close();
        }
        /// <summary>
        /// 获得单个数据
        /// </summary>
        /// <param name="LoinName"></param>
        public void GetOne(string strWhere)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,Sorting,CName,Sex,IdCard,Phone,Address,Demo from Teacher where 1=1 " + strWhere, conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            id = dr["ID"].ToString();
            sorting = dr["Sorting"].ToString();
            cName = dr["CName"].ToString();
            sex = dr["Sex"].ToString();
            idCard = dr["IdCard"].ToString();
            phone = dr["Phone"].ToString();
            address = dr["Address"].ToString();
            demo = dr["Demo"].ToString();
            conn.Close();
        }
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlCombbox(string SqlWhere, object combobox)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,Sorting,CName,Sex,IdCard,Phone,Address,Demo from Teacher where 1=1" + SqlWhere, conn);
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
        /// 添加
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Sorting"></param>
        /// <param name="CName"></param>
        /// <param name="Sex"></param>
        /// <param name="IdCard"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        /// <param name="Demo"></param>
        /// <returns></returns>
        public int Add(string ID, string Sorting, string CName, string Sex, string IdCard, string Phone, string Address, string Demo)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "insert into Teacher values('" + ID + "','" + Sorting + "','" + CName + "','" + Sex + "','" + IdCard + "','" + Phone + "','" + Address + "','" + Demo + "')";
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
            string strsql = "select count(*) from Teacher";
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
            string strsql = "update Teacher set " + sql + "where " + strWhere;
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
            string strsql = "delete from Teacher where " + strWhere;
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
