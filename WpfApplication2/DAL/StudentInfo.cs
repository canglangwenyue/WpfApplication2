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
    class StudentInfo
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
        string classNum;

        public string ClassNum
        {
            get { return classNum; }
            set { classNum = value; }
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
        string birthday;

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
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
        string headTeacher;

        public string HeadTeacher
        {
            get { return headTeacher; }
            set { headTeacher = value; }
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
            SqlCommand cmd = new SqlCommand("select ID,Sorting,ClassNum,CName,Sex,Birthday,IdCard,Phone,Address,HeadTeacher,Demo from Student where 1=1" + SqlWhere, conn);
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
                    ClassesInfo classinfo = new ClassesInfo();
                    classinfo.GetOne(" and ID='" + dr["ClassNum"].ToString() + "'");
                    dgv[2, i].Value = classinfo.CName;
                    dgv[3, i].Value = dr["Sorting"].ToString();
                    dgv[4, i].Value = dr["Sex"].ToString();
                    dgv[5, i].Value = dr["Birthday"].ToString();
                    dgv[6, i].Value = dr["IdCard"].ToString();
                    dgv[7, i].Value = dr["Phone"].ToString();
                    dgv[8, i].Value = dr["Address"].ToString();
                    if (dr["HeadTeacher"].ToString() != "0")
                    {
                        TeacherInfo teacherinfo = new TeacherInfo();
                        teacherinfo.GetOne(" and ID='" + dr["HeadTeacher"].ToString() + "'");
                        dgv[9, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[9, i].Value = "0";
                    }
                    dgv[10, i].Value = dr["Demo"].ToString();
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
        public void GetOne(string studentid)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,Sorting,ClassNum,CName,Sex,Birthday,IdCard,Phone,Address,HeadTeacher,Demo from Student where ID='" + studentid + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            id = dr["ID"].ToString();
            sorting = dr["Sorting"].ToString();
            classNum = dr["ClassNum"].ToString();
            cName = dr["CName"].ToString();
            sex = dr["Sex"].ToString();
            birthday = dr["Birthday"].ToString();
            idCard = dr["IdCard"].ToString();
            phone = dr["Phone"].ToString();
            address = dr["Address"].ToString();
            headTeacher = dr["HeadTeacher"].ToString();
            demo = dr["Demo"].ToString();
            conn.Close();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Sorting"></param>
        /// <param name="ClassNum"></param>
        /// <param name="CName"></param>
        /// <param name="Sex"></param>
        /// <param name="Birthday"></param>
        /// <param name="IdCard"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        /// <param name="HeadTeacher"></param>
        /// <param name="Demo"></param>
        public int Add(string ID, string Sorting, string ClassNum, string CName, string Sex, string Birthday, string IdCard, string Phone, string Address, string HeadTeacher, string Demo)
        {
            SqlConnection conn = SQL.GetConn();
            string strsql = "insert into Student values('" + ID + "','" + Sorting + "','" + ClassNum + "','" + CName + "','" + Sex + "','" + Birthday + "','" + IdCard + "','" + Phone + "','" + Address + "','" + HeadTeacher + "','" + Demo + "')";
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
            string strsql = "select count(*) from Student";
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
            string strsql = "update Student set " + sql + "where " + strWhere;
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
            string strsql = "delete from Student where " + strWhere;
            SqlCommand cmd = new SqlCommand(strsql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
