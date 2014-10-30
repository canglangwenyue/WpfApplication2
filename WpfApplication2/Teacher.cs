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

namespace StuSystem
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        TeacherInfo teacherinfo = new TeacherInfo();
        SQL SQL = new SQL();
        string strWhere = string.Empty;
        int Flag = 0;
        private void Teacher_Load(object sender, EventArgs e)
        {
            bindgvw();
        }

        #region 绑定数据
        /// <summary>
        /// 绑定Gridview
        /// </summary>
        private void bindgvw()
        {
            gvwdispose();
            GetSqlWhere();
            teacherinfo.GetSqlBase(strWhere, gvwTeacherList);
        }
        #endregion


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
            if (combSelect.Text == "教职工号")
                strWhere += " and ID like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "姓名")
                strWhere += " and CName like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "分院")
                strWhere += " and Sorting like '%" + txtSelect.Text.Trim() + "%'";

        }
        /// <summary>
        /// 数据清空
        /// </summary>
        private void gvwdispose()
        {
            gvwTeacherList.Rows.Clear();
        }
        #endregion

        

        #region 事件
        /// <summary>
        /// gridview行点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvwTeacherList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = gvwTeacherList.Columns[0].ToString();
            txtName.Text = gvwTeacherList.Columns[1].ToString();
            txtSorting.Text = gvwTeacherList.Columns[2].ToString();
            combSex.Text = gvwTeacherList.Columns[3].ToString();
            txtIdCard.Text = gvwTeacherList.Columns[4].ToString();
            txtPhone.Text = gvwTeacherList.Columns[5].ToString();
            txtAddress.Text = gvwTeacherList.Columns[6].ToString();
            txtDemo.Text = gvwTeacherList.Columns[7].ToString();
        }
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
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtName.Text = "";
            txtSorting.Text = "";
            combSex.Text = "";
            txtIdCard.Text = "";
            txtPhone.Text = "";
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
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (Flag == 1)
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("姓名不能为空！");
                    return;
                }
                string id = "0";
                string sorting = "0";
                string cname = string.Empty;
                string sex = "0";
                string idcard = "0";
                string phone = "0";
                string address = "0";
                string demo = "0";
                id = teacherinfo.GetNextID().ToString();
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
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                int count = teacherinfo.Add(id, sorting, cname, sex, idcard, phone, address, demo);
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
                    if (SQL.GetSelectCount("Teacher", " and CName='" + txtName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere += " and CName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定人名！");
                        return;
                    }
                }
                string id = "0";
                string sorting = "0";
                string cname = string.Empty;
                string sex = "0";
                string idcard = "0";
                string phone = "0";
                string address = "0";
                string demo = "0";
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
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                sql = " Sorting='" + sorting + "',CName='" + cname + "',Sex='" + sex + "',IdCard='" + idcard + "',Phone='" + phone + "',Address='" + address + "',Demo='" + demo + "' ";
                int count = teacherinfo.Update(sql, sqlWhere);
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
                    if (SQL.GetSelectCount("Teacher", " and CName='" + txtName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere = " CName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定人名！");
                        return;
                    }
                }
                int count = teacherinfo.Delete(sqlWhere);
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
    }
}
