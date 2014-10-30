﻿using System;
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
    public partial class Score : Form
    {
        public Score()
        {
            InitializeComponent();
        }
        SQL SQL = new SQL();
        ScoreInfo scoreinfo = new ScoreInfo();
        string strWhere = string.Empty;
        private void Score_Load(object sender, EventArgs e)
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
            scoreinfo.GetSqlBase(strWhere, gvwScoretList);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获得条件
        /// </summary>
        private void GetSqlWhere()
        {
            strWhere = string.Empty;
            if (combSelect.Text == "学号")
                strWhere += " and ID like '%" + txtSelect.Text.Trim() + "%'";
            if (combSelect.Text == "班级")
                strWhere += " and ClassNum like '%" + txtSelect.Text.Trim() + "%'";

        }
        /// <summary>
        /// 数据清空
        /// </summary>
        private void gvwdispose()
        {
            gvwScoretList.Rows.Clear();
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
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
