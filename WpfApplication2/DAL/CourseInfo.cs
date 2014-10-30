using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLBase;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WpfApplication2.DAL
{
    class CourseInfo
    {
        SQL SQL = new SQL();

        string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        string cSharp;

        public string CSharp
        {
            get { return cSharp; }
            set { cSharp = value; }
        }
        string english;

        public string English
        {
            get { return english; }
            set { english = value; }
        }
        string java;

        public string Java
        {
            get { return java; }
            set { java = value; }
        }
        string xML;

        public string XML
        {
            get { return xML; }
            set { xML = value; }
        }
        string math;

        public string Math
        {
            get { return math; }
            set { math = value; }
        }
        string chinese;

        public string Chinese
        {
            get { return chinese; }
            set { chinese = value; }
        }
        string netWork;

        public string NetWork
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
            SqlCommand cmd = new SqlCommand("select ID,CSharp,English,Java,XML,Math,Chinese,NetWork from Course where 1=1" + SqlWhere, conn);
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
                    TeacherInfo teacherinfo = new TeacherInfo();
                    ClassesInfo classinfo = new ClassesInfo();
                    classinfo.GetOne(" and ID='" + dr["ID"].ToString() + "'");
                    dgv[0, i].Value = classinfo.CName;
                    if (!string.IsNullOrEmpty(dr["CSharp"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["CSharp"].ToString() + "'");
                        dgv[1, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[1, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["English"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["English"].ToString() + "'");
                        dgv[2, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[2, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["Java"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["Java"].ToString() + "'");
                        dgv[3, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[3, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["XML"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["XML"].ToString() + "'");
                        dgv[4, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[4, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["Math"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["Math"].ToString() + "'");
                        dgv[5, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[5, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["Chinese"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["Chinese"].ToString() + "'");
                        dgv[6, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[6, i].Value = "0";
                    }
                    if (!string.IsNullOrEmpty(dr["NetWork"].ToString()))
                    {
                        teacherinfo.GetOne(" and ID='" + dr["NetWork"].ToString() + "'");
                        dgv[7, i].Value = teacherinfo.CName;
                    }
                    else
                    {
                        dgv[7, i].Value = teacherinfo.CName;
                    }
                    i++;
                }
                //conn.Close();
            }
            conn.Close();
        }
    }
}
