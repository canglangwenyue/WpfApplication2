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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        UsersInfo usersinfo = new UsersInfo();
        SQL SQL = new SQL();
        string strWhere = string.Empty;
        int Flag = 0;
        private void Users_Load(object sender, EventArgs e)
        {
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
            if (combSelect.Text == "姓名")
                strWhere += " and CName like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "登录名")
                strWhere += " and LoginName like '%" + txtSelect.Text.Trim() + "%'";

        }
        /// <summary>
        /// 数据清空
        /// </summary>
        private void gvwdispose()
        {
            gvwUserList.Rows.Clear();
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
            usersinfo.GetSqlBase(strWhere, gvwUserList);
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
        private void gvwUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = gvwUserList.Columns[0].ToString();
            txtName.Text = gvwUserList.Columns[3].ToString();
            txtLoginName.Text = gvwUserList.Columns[1].ToString();
            txtLoginPwd.Text = gvwUserList.Columns[2].ToString();
            txtPhone.Text = gvwUserList.Columns[4].ToString();
            txtDemo.Text = gvwUserList.Columns[5].ToString();
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
            txtLoginName.Text = "";
            txtLoginPwd.Text = "";
            txtPhone.Text = "";
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
                if (string.IsNullOrEmpty(txtLoginName.Text) || string.IsNullOrEmpty(txtLoginPwd.Text))
                {
                    MessageBox.Show("登录名或密码不能为空！");
                    return;
                }
                string id = "0";
                string loginname = "0";
                string loginpwd = "0";
                string cname = "0";
                string phone = "0";
                string demo = "0";
                id = usersinfo.GetNextID().ToString();
                loginname = txtLoginName.Text.Trim();
                loginpwd = txtLoginPwd.Text.Trim();
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    phone = txtPhone.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                int count = usersinfo.Add(id, loginname, loginpwd, cname, phone, demo);
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
                txtLoginName.Enabled = false;
                string sqlWhere = string.Empty;
                string sql = string.Empty;
                if (!string.IsNullOrEmpty(lblID.Text))
                {
                    sqlWhere += " and ID='" + lblID.Text + "'";
                }
                else
                {
                    if (SQL.GetSelectCount("User", " and LoginName='" + txtLoginName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere += " LoginName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定登录名！");
                        return;
                    }
                }
                string loginpwd = "0";
                string cname = "0";
                string phone = "0";
                string demo = "0";
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtLoginName.Text))
                {
                    loginpwd = txtLoginName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    phone = txtPhone.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                sql = " LoginPwd='" + loginpwd + "',CName='" + cname + "',Phone='" + phone + "',Demo='" + demo + "' ";
                int count = usersinfo.Update(sql, sqlWhere);
                if (count == 1)
                {
                    MessageBox.Show("修改成功！");
                    bottonStatus();
                    bindgvw();
                    pnlStudent.Enabled = false;
                    txtLoginName.Enabled = true;
                    return;
                }
                else
                {
                    MessageBox.Show("修改失败！");
                    bottonStatus();
                    pnlStudent.Enabled = false;
                    txtLoginName.Enabled = true;
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
                    if (SQL.GetSelectCount("User", " and LoginName='" + txtLoginName.Text.Trim() + "'") != 0)
                    {
                        sqlWhere += " LoginName='" + txtName.Text.Trim() + "'";
                    }
                    else
                    {
                        MessageBox.Show("数据库中不存在本人，请确定登录名！");
                        return;
                    }
                }
                int count = usersinfo.Delete(sqlWhere);
                if (count != 0)
                {
                    MessageBox.Show("删除成功！");
                    bottonStatus();
                    bindgvw();
                    pnlStudent.Enabled = false;
                    txtLoginName.Enabled = true;
                    return;
                }
                else
                {
                    MessageBox.Show("删除失败！");
                    bottonStatus();
                    pnlStudent.Enabled = false;
                    txtLoginName.Enabled = true;
                    return;
                }
            }
        }
        #endregion
    }
}
