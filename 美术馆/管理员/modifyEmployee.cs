using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 美术馆.管理员
{
    public partial class modifyEmployee : Form
    {
        SqlConnection conn = null;
        employee page;
        int userid;
        int stid;
        public modifyEmployee(employee l,int stid,int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.userid = userid;
            this.stid = stid;
        }
    }
}
