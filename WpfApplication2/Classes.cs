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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }
        ClassesInfo classesinfo = new ClassesInfo();
        SQL SQL = new SQL();
        string strWhere = string.Empty;
        int Flag = 0;
        private void Classes_Load(object sender, EventArgs e)
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
            if (combSelect.Text == "班级编号")
                strWhere += " and ID like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "班级名称")
                strWhere += " and CName like '%" + txtSelect.Text.Trim() + "%'";

        }
        /// <summary>
        /// 数据清空
        /// </summary>
        private void gvwdispose()
        {
            gvwClassList.Rows.Clear();
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
            classesinfo.GetSqlgvw(strWhere, gvwClassList);
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
        private void gvwClassList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gvwClassList.Columns[0].ToString();
            txtName.Text = gvwClassList.Columns[1].ToString();
            txtDemo.Text = gvwClassList.Columns[10].ToString();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
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
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("班级编号不能为空！");
                    return;
                }
                string id = "0";
                string cname = "0";
                string demo = "0";
                id = txtID.Text.Trim();
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                int count = classesinfo.Add(id, cname, demo);
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
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("班级编号不能为空！");
                }
                if (SQL.GetSelectCount("Classes", " and ID='" + txtID.Text.Trim() + "'") != 0)
                {
                    sqlWhere += " and ID='" + txtName.Text.Trim() + "'";
                }
                else
                {
                    MessageBox.Show("数据库中不存在本班，请确定班级编号！");
                    return;
                }
                string cname = "0" ;
                string demo = "0";
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    cname = txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtDemo.Text))
                {
                    demo = txtDemo.Text.Trim();
                }
                sql = " CName='" + cname + "',Demo='" + demo + "' ";
                int count = classesinfo.Update(sql, sqlWhere);
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
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("班级编号不能为空！");
                }
                if (SQL.GetSelectCount("Classes", " and ID='" + txtID.Text.Trim() + "'") != 0)
                {
                    sqlWhere += " and ID='" + txtName.Text.Trim() + "'";
                }
                else
                {
                    MessageBox.Show("数据库中不存在本班，请确定班级编号！");
                    return;
                }
                int count = classesinfo.Delete(sqlWhere);
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
