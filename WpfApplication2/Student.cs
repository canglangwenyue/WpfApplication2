using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WpfApplication2.DAL;
using SQLBase;


namespace WpfApplication2
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        StudentInfo studentinfo = new StudentInfo();
        ClassesInfo classinfo = new ClassesInfo();
        TeacherInfo teacherinfo = new TeacherInfo();
        SQL SQL = new SQL();
        string strWhere = string.Empty;
        int Flag = 0;
        private void Student_Load(object sender, EventArgs e)
        {
            classdrop();
            headtercherdrop();
            bindgvw();
        }

        #region 公共方法
        /// <summary>
        /// 按钮互斥
        /// </summary>
        private void bottonStatus()
        {
            this.btnsave.Enabled = !this.btnsave.Enabled;
            this.btnCancle.Enabled = !this.btnCancle.Enabled;
            this.btnAdd.Enabled = !this.btnAdd.Enabled;
            this.btnEdit.Enabled = !this.btnEdit.Enabled;
            this.btnDelete.Enabled = !this.btnDelete.Enabled;
        }
        /// <summary>
        /// 获得条件
        /// </summary>
        private void GetSqlWhere()
        {
            strWhere = string.Empty;
            if (combSelect.Text == "学号")
                strWhere += " and ID like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "姓名")
                strWhere += " and CName like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "分院")
                strWhere += " and Sorting like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "班级")
                strWhere += " and ClassNum like '%" + txtSelect.Text.Trim() + "%'";

        }
        /// <summary>
        /// 数据清空
        /// </summary>
        private void gvwdispose()
        {
            gvwStudentList.Rows.Clear();
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定Gridview
        /// </summary>
        private void bindgvw()
        {
            gvwdispose();
            GetSqlWhere();
            studentinfo.GetSqlBase(strWhere, gvwStudentList);
        }
        /// <summary>
        /// 绑定导员下拉列表
        /// </summary>
        private void headtercherdrop()
        {
            teacherinfo.GetSqlCombbox("", combHeadTeacher);
        }
        /// <summary>
        /// 绑定班级下拉列表
        /// </summary>
        private void classdrop()
        {
            classinfo.GetSqlBase("", combClass);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            GetSqlWhere();
            gvwdispose();
            bindgvw();
        }
        /// <summary>
        /// GridView行点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvwStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = gvwStudentList.Columns[0].ToString();
            txtName.Text = gvwStudentList.Columns[1].ToString();
            combClass.Text = gvwStudentList.Columns[2].ToString();
            txtSorting.Text = gvwStudentList.Columns[3].ToString();
            combSex.Text = gvwStudentList.Columns[4].ToString();
            //timeBirthday.Value = Convert.ToDateTime(gvwStudentList.Columns[5].ToString());
            txtIdCard.Text = gvwStudentList.Columns[6].ToString();
            txtPhone.Text = gvwStudentList.Columns[7].ToString();
            combHeadTeacher.Text = gvwStudentList.Columns[8].ToString();
            txtAddress.Text = gvwStudentList.Columns[9].ToString();
            txtDemo.Text = gvwStudentList.Columns[10].ToString();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtName.Text = "";
            combClass.Text = "";
            txtSorting.Text = "";
            combSex.Text = "";
            timeBirthday.Value = DateTime.Now;
            txtIdCard.Text = "";
            txtPhone.Text = "";
            combHeadTeacher.Text = "";
            txtAddress.Text = "";
            txtDemo.Text = "";
        }
        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bottonStatus();
            btnCancle_Click(sender, e);
            pnlStudent.Enabled = true;
            Flag = 1;
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bottonStatus();
            pnlStudent.Enabled = true;
            Flag = 2;
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bottonStatus();
            pnlStudent.Enabled = true;
            Flag = 3;
        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (Flag == 1)
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(combClass.Text))
                {
                    MessageBox.Show("姓名或班级不能为空！");
                    return;
                }
                string classNum = "0";
                string id = "0";
                string sorting = "0";
                string cname = string.Empty;
                string sex = "0";
                string birthday = string.Empty;
                string idcard = "0";
                string phone = "0";
                string address = "0";
                string headteacher = "0";
                string demo = "0";
                if (!string.IsNullOrEmpty(combClass.Text))
                {
                    classinfo.GetOne(" and CName='" + combClass.Text.Trim() + "'");
                     classNum = classinfo.ID;
                }
                id = classNum + SQL.GetSelectCount("Student", " and ClassNum='" + classNum + "'").ToString();
                if (!string.IsNullOrEmpty(txtSorting.Text))
                {
                    sorting = txtSorting.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(combSex.Text))
                {
                    sex = combSex.Text.Trim();
                }
                birthday = timeBirthday.Value.ToString();
                if (!string.IsNullOrEmpty(txtIdCard.Text))
                {
                    idcard = txtIdCard.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    phone = txtPhone.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    address = txtAddress.Text.Trim();
                }
                if (!string.IsNullOrEmpty(combHeadTeacher.Text))
                {
                    teacherinfo.GetOne(" and CName='" + combHeadTeacher.Text.Trim() + "'");
                    headteacher = teacherinfo.ID;
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                int count=studentinfo.Add(id, sorting, classNum, cname, sex, birthday, idcard, phone, address, headteacher, demo);
                if (count == 1)
                {
                    MessageBox.Show("添加成功！");
                    bottonStatus();
                    bindgvw();
                    pnlStudent.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("添加失败！");
                    bottonStatus();
                    pnlStudent.Enabled = false;
                    return;
                }
               
            }
            if (Flag == 2)
            {
                string sqlWhere = string.Empty;
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(lblID.Text))
                {
                    sqlWhere += " and ID='" + lblID.Text + "'";
                }
                else
                {
                    if (SQL.GetSelectCount("Student", " and CName='" + txtName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere += " and CName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定人名！");
                        return;
                    }
                }
                string classNum = "0";
                string sorting = "0";
                string cname = string.Empty;
                string sex = "0";
                string birthday = string.Empty;
                string idcard = "0";
                string phone = "0";
                string address = "0";
                string headteacher = "0";
                string demo = "0";
                if (!string.IsNullOrEmpty(combClass.Text))
                {
                    classinfo.GetOne(" and CName='" + combClass.Text.Trim() + "'");
                    classNum = classinfo.ID;
                }
                if (!string.IsNullOrEmpty(txtSorting.Text))
                {
                    sorting = txtSorting.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(combSex.Text))
                {
                    sex = combSex.Text.Trim();
                }
                birthday = timeBirthday.Value.ToString();
                if (!string.IsNullOrEmpty(txtIdCard.Text))
                {
                    idcard = txtIdCard.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    phone = txtPhone.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    address = txtAddress.Text.Trim();
                }
                if (!string.IsNullOrEmpty(combHeadTeacher.Text))
                {
                    teacherinfo.GetOne(" and CName='" + combHeadTeacher.Text.Trim() + "'");
                    headteacher = teacherinfo.ID;
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                sql = " Sorting='" + sorting + "',ClassNum='" + classNum + "',CName='" + cname + "',Sex='" + sex + "',Birthday='" + timeBirthday.Text.Trim() + "',IdCard='" + idcard + "',Phone='" + phone + "',Address='" + address + "',HeadTeacher='" + headteacher + "',Demo='" + demo + "' ";
                int count = studentinfo.Update(sql, sqlWhere);
                if (count == 1)
                {
                    MessageBox.Show("修改成功！");
                    bottonStatus();
                    bindgvw();
                    pnlStudent.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("修改失败！");
                    bottonStatus();
                    pnlStudent.Enabled = false;
                    return;
                }
            }
            if (Flag == 3)
            {
                string sqlWhere = string.Empty;
                if (!string.IsNullOrEmpty(lblID.Text))
                {
                    sqlWhere = " ID='" + lblID.Text + "'";
                }
                else
                {
                    if (SQL.GetSelectCount("Student", " and CName='" + txtName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere = " CName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定人名！");
                        return;
                    }
                }
                int count = studentinfo.Delete(sqlWhere);
                if (count != 0)
                {
                    MessageBox.Show("删除成功！");
                    bottonStatus();
                    bindgvw();
                    pnlStudent.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("删除失败！");
                    bottonStatus();
                    pnlStudent.Enabled = false;
                    return;
                }
            }
        }
        #endregion

        private void gvwStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
