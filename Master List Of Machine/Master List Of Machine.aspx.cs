using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace Master_List_Of_Machine
{
    public partial class Master_List_Of_Machine : System.Web.UI.Page
    {
        DataTable OldUID = new DataTable();
        DataTable cdata = new DataTable();
        OleDbConnection con = new OleDbConnection();
        //private OleDbCommand oleDbCmd = new OleDbCommand();
        String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\access\Tablas.mdb";
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(connParam);
        }
        void Machinelist()
        {
            //string strNewPath = @"D:\CSK\Carbide\Stock Statement - ATS.xlsx";
            string strNewPath = @"D:\CSK\Master.xlsx";
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

            string query = "SELECT * FROM [MACHINE$A:G]";
            //string query = "SELECT TOP 1 [F1],[F2],[Required T#C# Size],[F4],[F5],[F6],[F7] FROM [T#C# Issue Details$] WHERE F2 = " + OldUID.Rows[j][0].ToString() + "";
            con = new OleDbConnection(connString);
            //if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(cdata);
            foreach (DataRow dr in cdata.Rows)
            {
                dr[4] = dr[4].ToString().Replace("'", " ");
            }

            GridView1.DataSource = cdata;
            GridView1.DataBind();
        }
        void UpdateMasterList()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = W:\test\access\Tablas.mdb");
            foreach (DataRow dr in cdata.Rows)
            {
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd = new OleDbCommand("UPDATE [Máquinas] SET InstallationDate = '" + dr[4].ToString() + "' WHERE CodMaq = " + Convert.ToInt32(dr[1]) + "", con);
                OleDbDataReader reader = cmd.ExecuteReader();
                con.Close();
            }

        }
        void MasterListOfMachine()
        {
            //string strNewPath = @"D:\CSK\Carbide\Stock Statement - ATS.xlsx";
            //string strNewPath = @"D:\CSK\Master.xlsx";
            //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

            string query = "SELECT CodMaq, TipMaq, InstallationDate, [¿Activa?] as Active, AMC, SupportEquip FROM [Máquinas] ORDER BY [Máquinas].CodMaq ASC";
            //string query = "SELECT TOP 1 [F1],[F2],[Required T#C# Size],[F4],[F5],[F6],[F7] FROM [T#C# Issue Details$] WHERE F2 = " + OldUID.Rows[j][0].ToString() + "";
            con = new OleDbConnection(connParam);
            //if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(cdata);
            //GridView1.DataSource = cdata;
            //GridView1.DataBind();
        }
        void AWS1()
        {
            foreach (DataRow dr in cdata.Rows)
            {
                if (dr[0].ToString().Length == 4)
                {
                    dr.Delete();
                }
            }
            cdata.AcceptChanges();
            foreach (DataRow dr in cdata.Rows)
            {
                if (dr[3].ToString() == "False")
                {
                    dr.Delete();
                }
            }
            cdata.AcceptChanges();
            
        }
        void AWS2()
        {
            foreach (DataRow dr in cdata.Rows)
            {
                if (dr[0].ToString().Length != 4)
                {
                    dr.Delete();
                }
            }
            cdata.AcceptChanges();
            foreach (DataRow dr in cdata.Rows)
            {
                if (dr[3].ToString() == "False")
                {
                    dr.Delete();
                }
            }
            cdata.AcceptChanges();
        }

        protected void btnMasterListOfMachine_Click(object sender, EventArgs e)
        {
            //Machinelist();
            //UpdateMasterList();
            MasterListOfMachine();
            if (rdbtn1.Checked == true)
            {
                AWS1();
                if (rdbtn5.Checked == false)
                {
                    foreach (DataRow dr in cdata.Rows)
                    {
                        if (dr[5].ToString() == "True")
                        {
                            dr.Delete();
                        }
                    }
                    cdata.AcceptChanges();
                }
            }
            if (rdbtn2.Checked == true)
            {
                AWS2();
                if (rdbtn5.Checked == false)
                {
                    foreach (DataRow dr in cdata.Rows)
                    {
                        if (dr[5].ToString() == "True")
                        {
                            dr.Delete();
                        }
                    }
                    cdata.AcceptChanges();
                }
            }
            if (rdbtn3.Checked == true)
            {
                InActiveMachine();
                if (rdbtn5.Checked == false)
                {
                    foreach (DataRow dr in cdata.Rows)
                    {
                        if (dr[5].ToString() == "True")
                        {
                            dr.Delete();
                        }
                    }
                    cdata.AcceptChanges();
                }
            }
            DataTable dtCloned = cdata.Clone();
            dtCloned.Columns[3].DataType = typeof(string);
            foreach (DataRow row in cdata.Rows)
            {
                dtCloned.ImportRow(row);
            }
            foreach (DataRow dr in dtCloned.Rows)
            {
                string remak = dr[3].ToString();
                if (dr[3].ToString() == "True")
                {
                    dr[3] = dr[3].ToString().Replace("True","In Use");
                }
            }
            dtCloned.AcceptChanges();
            if (rdbtn5.Checked == true)
            {
                foreach (DataRow dr in dtCloned.Rows)
                {
                    if (dr[5].ToString() == "False")
                    {
                        dr.Delete();
                    }
                }
                dtCloned.AcceptChanges();
            }

            GridView1.DataSource = dtCloned;
            GridView1.DataBind();
        }
        void InActiveMachine()
        {
            foreach (DataRow dr in cdata.Rows)
            {
                if (dr[3].ToString() == "False")
                {
                    dr.Delete();
                }
            }
            cdata.AcceptChanges();
        }

    }
}