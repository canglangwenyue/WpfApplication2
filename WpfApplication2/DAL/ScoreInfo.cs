using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLBase;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WpfApplication2.DAL
{
    class ScoreInfo
    {
        SQL SQL = new SQL();

        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string classNum;

        public string ClassNum
        {
            get { return classNum; }
            set { classNum = value; }
        }
        int cSharp;

        public int CSharp
        {
            get { return cSharp; }
            set { cSharp = value; }
        }
        int english;

        public int English
        {
            get { return english; }
            set { english = value; }
        }
        int java;

        public int Java
        {
            get { return java; }
            set { java = value; }
        }
        int xML;

        public int XML
        {
            get { return xML; }
            set { xML = value; }
        }
        int math;

        public int Math
        {
            get { return math; }
            set { math = value; }
        }
        int chinese;

        public int Chinese
        {
            get { return chinese; }
            set { chinese = value; }
        }
        int netWork;


        public int NetWork
        {
            get { return netWork; }
            set { netWork = value; }
        }
        /// <summary>
        /// 绑定gridview
        /// </summary>
        /// <param name="SqlWhere"></param>
        public void GetSqlBase(string SqlWhere, object DataGrid)
        {
            SqlConnection conn = SQL.GetConn();
            SqlCommand cmd = new SqlCommand("select ID,ClassNum,CSharp,English,Java,XML,Math,Chinese,NetWork from Score where 1=1" + SqlWhere, conn);
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
                    ClassesInfo classinfo = new ClassesInfo();
                    classinfo.GetOne(" and ID='" + dr["ClassNum"].ToString() + "'");
                    dgv[1, i].Value = classinfo.CName;
                    dgv[2, i].Value = dr["CSharp"].ToString();
                    dgv[3, i].Value = dr["English"].ToString();
                    dgv[4, i].Value = dr["Java"].ToString();
                    dgv[5, i].Value = dr["XML"].ToString();
                    dgv[6, i].Value = dr["Math"].ToString();
                    dgv[7, i].Value = dr["Chinese"].ToString();
                    dgv[8, i].Value = dr["NetWork"].ToString();
                    i++;
                }
                //conn.Close();
            }
            conn.Close();
        }
    }
}
