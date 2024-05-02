
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySQLDriverCS;
using System.IO;
using System.Text.RegularExpressions;



namespace @case
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQLConnection con = new MySQLConnection(
                 new MySQLConnectionString(
                   "mysql", "root", "").AsString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            MySQLCommand query = new MySQLCommand(
                "show databases", con);

            MySQLDataReader data = query.ExecuteReaderEx();
            listBox1.Items.Clear();
            while (data.Read())
            {
                listBox1.Items.Add(string.Format("{0,-60}", data.GetString(0)));



            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySQLConnection con = new MySQLConnection(
                new MySQLConnectionString(
                  listBox1.SelectedItem.ToString().Trim(), "root", "").AsString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            MySQLCommand query = new MySQLCommand(
                "show tables", con);

            MySQLDataReader data = query.ExecuteReaderEx();
            listBox2.Items.Clear();
            while (data.Read())
            {
                listBox2.Items.Add(string.Format("{0,-60}", data.GetString(0)));



            }
            con.Close();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MySQLConnection con = new MySQLConnection(
                new MySQLConnectionString(
                  listBox1.SelectedItem.ToString().Trim(), "root", "").AsString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
            MySQLCommand query = new MySQLCommand(
                "describe " + listBox2.SelectedItem.ToString().Trim(), con);

            MySQLDataReader data = query.ExecuteReaderEx();
            listBox3.Items.Clear();
            while (data.Read())
            {
                listBox3.Items.Add(string.Format("{0,-60}", data.GetString(0)));
            }
            con.Close();

        }


        String final = " C:\\Users\\iram_\\Documents\\Visual Studio 2005\\Projects\\Final\\Final\\";

        private void button3_Click(object sender, EventArgs e)
        {

            StreamWriter f1 = new StreamWriter(final + "Form1.cs");
            f1.WriteLine("using System;");
            f1.WriteLine("using System.Collections.Generic;");
            f1.WriteLine("using System.ComponentModel;");
            f1.WriteLine("using System.Data;");
            f1.WriteLine("using System.Drawing;");
            f1.WriteLine("using System.Text;");
            f1.WriteLine("using System.Windows.Forms;");
            f1.WriteLine("");
            f1.WriteLine("namespace safeprojectname");
            f1.WriteLine("{");
            f1.WriteLine("public partial class Form1 : Form");
            f1.WriteLine("  {");
            f1.WriteLine("  public static string usuario = \"\"; ");
            f1.WriteLine("  public static int nivel = 0;");
            f1.WriteLine("");
            f1.WriteLine("public Form1()");
            f1.WriteLine("        {");
            f1.WriteLine("           InitializeComponent();");
            f1.WriteLine("        }");
            f1.WriteLine("");
            f1.WriteLine("private void Form1_Load(object sender, EventArgs e)");
            f1.WriteLine("");
            f1.WriteLine("        {");
            f1.WriteLine("           // Form2 f2 = new Form2();");
            f1.WriteLine("           // f2.ShowDialog();");
            f1.WriteLine("        }");
            f1.WriteLine("");
            int n = 3;
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                f1.WriteLine("    private void " + listBox2.Items[i].ToString().Trim()
                    + "ToolStripMenuItem_Click(object sender, EventArgs e)");
                f1.WriteLine("     {");
                f1.WriteLine("            Form" + n.ToString() + " f" + n.ToString()
                    + " = new Form" + n.ToString() + "();");
                f1.WriteLine("            f" + n.ToString() + ".ShowDialog();");
                f1.WriteLine("     }");
            }

            f1.WriteLine("    private void salirToolStripMenuItem_Click(object sender, EventArgs e)");
            f1.WriteLine("     {");
            f1.WriteLine("            Close();");
            f1.WriteLine("");
            f1.WriteLine("        }");
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                f1.WriteLine("    private void listado" + listBox2.Items[i].ToString().Trim()
                    + "ToolStripMenuItem_Click(object sender, EventArgs e)");
                f1.WriteLine("     {");
                f1.WriteLine("            Form" + n.ToString() + " f" + n.ToString()
                    + " = new Form" + n.ToString() + "();");
                f1.WriteLine("            f" + n.ToString() + ".Show();");
                f1.WriteLine("     }");
            }
            f1.WriteLine("     }");
            f1.WriteLine("}");

            f1.Close();


            StreamWriter fd = new StreamWriter(final + "Form1.Designer.cs");

            fd.WriteLine("	namespace safeprojectname	");
            fd.WriteLine("	{	");
            fd.WriteLine("	    partial class Form1	");
            fd.WriteLine("	    {	");
            fd.WriteLine("	        /// <summary>	");
            fd.WriteLine("	        /// Required designer variable.	");
            fd.WriteLine("	        /// </summary>	");
            fd.WriteLine("	        private System.ComponentModel.IContainer components = null;	");
            fd.WriteLine("		");
            fd.WriteLine("	        /// <summary>	");
            fd.WriteLine("	        /// Clean up any resources being used.	");
            fd.WriteLine("	        /// </summary>	");
            fd.WriteLine("	        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>	");
            fd.WriteLine("	        protected override void Dispose(bool disposing)	");
            fd.WriteLine("	        {	");
            fd.WriteLine("	            if (disposing && (components != null))	");
            fd.WriteLine("	            {	");
            fd.WriteLine("	                components.Dispose();	");
            fd.WriteLine("	            }	");
            fd.WriteLine("	            base.Dispose(disposing);	");
            fd.WriteLine("	        }	");
            fd.WriteLine("		");
            fd.WriteLine("	        #region Windows Form Designer generated code	");
            fd.WriteLine("		");
            fd.WriteLine("	        /// <summary>	");
            fd.WriteLine("	        /// Required method for Designer support - do not modify	");
            fd.WriteLine("	        /// the contents of this method with the code editor.	");
            fd.WriteLine("	        /// </summary>	");
            fd.WriteLine("	        private void InitializeComponent()	");
            fd.WriteLine("	        {	");
            fd.WriteLine("	            this.menuStrip1 = new System.Windows.Forms.MenuStrip();	");
            fd.WriteLine("	            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();	");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                        + "ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();	");
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                            + "ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();	");
            }
            fd.WriteLine("	            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();	");
            fd.WriteLine("	            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();	");
            fd.WriteLine("	            this.menuStrip1.SuspendLayout();	");
            fd.WriteLine("	            this.SuspendLayout();	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            // menuStrip1	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {	");
            fd.WriteLine("	            this.archivoToolStripMenuItem,	");
            fd.WriteLine("	            this.reportesToolStripMenuItem});	");
            fd.WriteLine("	            this.menuStrip1.Location = new System.Drawing.Point(0, 0);	");
            fd.WriteLine("	            this.menuStrip1.Name = \"menuStrip1\";	");
            fd.WriteLine("	            this.menuStrip1.Size = new System.Drawing.Size(584, 24);	");
            fd.WriteLine("	            this.menuStrip1.TabIndex = 0;	");
            fd.WriteLine("	            this.menuStrip1.Text = \"menuStrip1\";	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            // archivoToolStripMenuItem	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {	");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem,	");
            }
            fd.WriteLine("	            this.salirToolStripMenuItem});	");
            fd.WriteLine("	            this.archivoToolStripMenuItem.Name = \"archivoToolStripMenuItem\";	");
            fd.WriteLine("	            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);	");
            fd.WriteLine("	            this.archivoToolStripMenuItem.Text = \"Archivo\";	");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                fd.WriteLine("	            // 	");
                fd.WriteLine("	            // " + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem	");
                fd.WriteLine("	            // 	");
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Name = \"" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem\";	");
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);	");
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Text = \"" + listBox2.Items[i].ToString().Trim()
                       + "\";	");
                fd.WriteLine("	            this." + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Click += new System.EventHandler(this."
                       + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem_Click);	");
            }
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            // salirToolStripMenuItem	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            this.salirToolStripMenuItem.Name = \"salirToolStripMenuItem\";	");
            fd.WriteLine("	            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);	");
            fd.WriteLine("	            this.salirToolStripMenuItem.Text = \"Salir\";	");
            fd.WriteLine("	            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            // reportesToolStripMenuItem	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {	");
            for (int i = 0; i < listBox2.Items.Count - 1; i++)
            {
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem,	");
            }
            fd.WriteLine("	            this.listado" + listBox2.Items[listBox2.Items.Count - 1].ToString().Trim()
                       + "ToolStripMenuItem});	");
            fd.WriteLine("	            this.reportesToolStripMenuItem.Name = \"reportesToolStripMenuItem\";	");
            fd.WriteLine("	            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);	");
            fd.WriteLine("	            this.reportesToolStripMenuItem.Text = \"Reportes\";	");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                fd.WriteLine("	            // 	");
                fd.WriteLine("	            // listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem	");
                fd.WriteLine("	            // 	");
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Name = \"listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem\";	");
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);	");
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Text =\"Listado de " + listBox2.Items[i].ToString().Trim()
                       + "\";	");
                fd.WriteLine("	            this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem.Click += new System.EventHandler(this.listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem_Click);	");
            }
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            // Form1	");
            fd.WriteLine("	            // 	");
            fd.WriteLine("	            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);	");
            fd.WriteLine("	            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;	");
            fd.WriteLine("	            this.ClientSize = new System.Drawing.Size(584, 361);	");
            fd.WriteLine("	            this.Controls.Add(this.menuStrip1);	");
            fd.WriteLine("	            this.MainMenuStrip = this.menuStrip1;	");
            fd.WriteLine("	            this.Name = \"Form1\";	");
            fd.WriteLine("	            this.Text = \"Sistema\";	");
            fd.WriteLine("	            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;	");
            fd.WriteLine("	            this.Load += new System.EventHandler(this.Form1_Load);	");
            fd.WriteLine("	            this.menuStrip1.ResumeLayout(false);	");
            fd.WriteLine("	            this.menuStrip1.PerformLayout();	");
            fd.WriteLine("	            this.ResumeLayout(false);	");
            fd.WriteLine("	            this.PerformLayout();	");
            fd.WriteLine("		");
            fd.WriteLine("	        }	");
            fd.WriteLine("		");
            fd.WriteLine("	        #endregion	");
            fd.WriteLine("		");
            fd.WriteLine("	        private System.Windows.Forms.MenuStrip menuStrip1;	");
            fd.WriteLine("	        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;	");
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                fd.WriteLine("	        private System.Windows.Forms.ToolStripMenuItem " + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem;	");
                fd.WriteLine("	        private System.Windows.Forms.ToolStripMenuItem listado" + listBox2.Items[i].ToString().Trim()
                       + "ToolStripMenuItem;	");
            }
            fd.WriteLine("	        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;	");
            fd.WriteLine("	        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;	");
            fd.WriteLine("	    }	");
            fd.WriteLine("	}	");
            fd.Close();

            StreamWriter fp = new StreamWriter(final + "Program.cs");

            fp.WriteLine("	using System;	");
            fp.WriteLine("	using System.Collections.Generic;	");
            fp.WriteLine("	using System.Windows.Forms;	");
            fp.WriteLine("		");
            fp.WriteLine("	namespace safeprojectname	");
            fp.WriteLine("	{	");
            fp.WriteLine("	    static class Program	");
            fp.WriteLine("	    {	");
            fp.WriteLine("	        /// <summary>	");
            fp.WriteLine("	        /// The main entry point for the application.	");
            fp.WriteLine("	        /// </summary>	");
            fp.WriteLine("	        [STAThread]	");
            fp.WriteLine("	        static void Main()	");
            fp.WriteLine("	        {	");
            fp.WriteLine("	            Application.EnableVisualStyles();	");
            fp.WriteLine("	            Application.SetCompatibleTextRenderingDefault(false);	");
            fp.WriteLine("	            Application.Run(new Form1());	");
            fp.WriteLine("	        }	");
            fp.WriteLine("	    }	");
            fp.WriteLine("	}	");
            fp.Close();

            StreamWriter fr = new StreamWriter(final + "Form1.resx");
            fr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            fr.WriteLine("<root>");
            fr.WriteLine("<!-- ");
            fr.WriteLine("Microsoft ResX Schema ");
            fr.WriteLine("Version 2.0");
            fr.WriteLine(" The primary goals of this format is to allow a simple XML format");
            fr.WriteLine(" that is mostly human readable. The generation and parsing of the ");
            fr.WriteLine("various data types are done through the TypeConverter classes ");
            fr.WriteLine("associated with the data types.");
            fr.WriteLine("Example:");
            fr.WriteLine(" ... ado.net/XML headers & schema ...");
            fr.WriteLine("<resheader name=\"resmimetype\">text/microsoft-resx</resheader>");
            fr.WriteLine("<resheader name=\"version\">2.0</resheader>");
            fr.WriteLine("    <resheader name=\"reader\">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>");
            fr.WriteLine("    <resheader name=\"writer\">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>");
            fr.WriteLine(" <data name=\"Name1\"><value>this is my long string</value><comment>this is a comment</comment></data>");
            fr.WriteLine("<data name=\"Color1\" type=\"System.Drawing.Color, System.Drawing\">Blue</data>");
            fr.WriteLine(" <data name=\"Bitmap1\" mimetype=\"application/x-microsoft.net.object.binary.base64\">");
            fr.WriteLine("  <value>[base64 mime encoded serialized .NET Framework object]</value>");
            fr.WriteLine("</data>");
            fr.WriteLine("<data name=\"Icon1\" type=\"System.Drawing.Icon, System.Drawing\" mimetype=\"application/x-microsoft.net.object.bytearray.base64\">");
            fr.WriteLine("      <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>");
            fr.WriteLine(" <comment>This is a comment</comment>");



            fr.WriteLine("</data>");
            fr.WriteLine(" There are any number of \"resheader\" rows that contain simple ");
            fr.WriteLine("name/value pairs.");
            fr.WriteLine(" Each data row contains a name, and value. The row also contains a");
            fr.WriteLine("  type or mimetype. Type corresponds to a .NET class that support");
            fr.WriteLine("text/value conversion through the TypeConverter architecture.");
            fr.WriteLine("Classes that don't support this are serialized and stored with the ");
            fr.WriteLine(" mimetype set.");
            fr.WriteLine("The mimetype is used for serialized objects, and tells the ");
            fr.WriteLine("ResXResourceReader how to depersist the object. This is currently not ");
            fr.WriteLine("extensible. For a given mimetype the value must be set accordingly:");
            fr.WriteLine("  Note - application/x-microsoft.net.object.binary.base64 is the format ");
            fr.WriteLine("that the ResXResourceWriter will generate, however the reader can ");
            fr.WriteLine("read any of the formats listed below.");
            fr.WriteLine("  mimetype: application/x-microsoft.net.object.binary.base64");
            fr.WriteLine("value   : The object must be serialized with ");
            fr.WriteLine("  : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter");
            fr.WriteLine(" : and then encoded with base64 encoding.");
            fr.WriteLine(" mimetype: application/x-microsoft.net.object.soap.base64");
            fr.WriteLine("  value   : The object must be serialized with ");
            fr.WriteLine(" : System.Runtime.Serialization.Formatters.Soap.SoapFormatter");
            fr.WriteLine("  : and then encoded with base64 encoding.");
            fr.WriteLine("  mimetype: application/x-microsoft.net.object.bytearray.base64");
            fr.WriteLine(" value   : The object must be serialized into a byte array ");
            fr.WriteLine("  : using a System.ComponentModel.TypeConverter");
            fr.WriteLine("  : and then encoded with base64 encoding.");
            fr.WriteLine("   -->");
            fr.WriteLine("  <xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">");
            fr.WriteLine("  <xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />");
            fr.WriteLine(" <xsd:element name=\"root\" msdata:IsDataSet=\"true\">");
            fr.WriteLine("    <xsd:complexType>");
            fr.WriteLine("   <xsd:choice maxOccurs=\"unbounded\">");
            fr.WriteLine("   <xsd:element name=\"metadata\">");
            fr.WriteLine("<xsd:complexType>");
            fr.WriteLine("<xsd:sequence>");
            fr.WriteLine(" <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />");
            fr.WriteLine(" </xsd:sequence>");
            fr.WriteLine(" <xsd:attribute name=\"name\" use=\"required\" type= \"xsd:string\" />");
            fr.WriteLine(" <xsd:attribute name=\"type\" type=\"xsd:string\" />");
            fr.WriteLine("  <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />");
            fr.WriteLine("  <xsd:attribute ref=\"xml:space\" />");
            fr.WriteLine("</xsd:complexType>");
            fr.WriteLine("</xsd:element>");
            fr.WriteLine(" <xsd:element name=\"assembly\">");
            fr.WriteLine("  <xsd:complexType>");
            fr.WriteLine("    <xsd:attribute name=\"alias\" type=\"xsd:string\" />");
            fr.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" />");
            fr.WriteLine("  </xsd:complexType>");
            fr.WriteLine("</xsd:element>");
            fr.WriteLine("<xsd:element name=\"data\">");
            fr.WriteLine("<xsd:complexType>");
            fr.WriteLine("<xsd:sequence>");
            fr.WriteLine("<xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
            fr.WriteLine("  <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />");
            fr.WriteLine("</xsd:sequence>");
            fr.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />");
            fr.WriteLine("   <xsd:attribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />");
            fr.WriteLine("<xsd:attribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />");
            fr.WriteLine("<xsd:attribute ref=\"xml:space\" />");
            fr.WriteLine("   </xsd:complexType>");
            fr.WriteLine(" </xsd:element>");
            fr.WriteLine("<xsd:element name=\"resheader\">");
            fr.WriteLine("<xsd:complexType>");
            fr.WriteLine(" <xsd:sequence>");
            fr.WriteLine("<xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
            fr.WriteLine(" </xsd:sequence>");
            fr.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />");
            fr.WriteLine(" </xsd:complexType>");
            fr.WriteLine("  </xsd:element>");
            fr.WriteLine("</xsd:choice>");
            fr.WriteLine("</xsd:complexType>");
            fr.WriteLine("</xsd:element>");
            fr.WriteLine("</xsd:schema>");
            fr.WriteLine("<resheader name=\"resmimetype\">");
            fr.WriteLine("    <value>text/microsoft-resx</value>");
            fr.WriteLine(" </resheader>");
            fr.WriteLine("  <resheader name=\"version\">");
            fr.WriteLine(" <value>2.0</value>");
            fr.WriteLine(" </resheader>");
            fr.WriteLine("<resheader name=\"reader\">");
            fr.WriteLine(" <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            fr.WriteLine("</resheader>");
            fr.WriteLine("<resheader name=\"writer\">");
            fr.WriteLine(" <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            fr.WriteLine("</resheader>");
            fr.WriteLine(" <metadata name=\"menuStrip1.TrayLocation\" type=\"System.Drawing.Point, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\">");
            fr.WriteLine(" <value>17, 17</value>");
            fr.WriteLine(" </metadata>");
            fr.WriteLine("</root>");
            fr.Close();

            StreamWriter fs = new StreamWriter(final + "Final.csproj");
            fs.WriteLine("	<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">	");
            fs.WriteLine("	  <PropertyGroup>	");
            fs.WriteLine("	    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>	");
            fs.WriteLine("	    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>	");
            fs.WriteLine("	    <ProductVersion>8.0.50727</ProductVersion>	");
            fs.WriteLine("	    <SchemaVersion>2.0</SchemaVersion>	");
            fs.WriteLine("	    <ProjectGuid>{5F3E2193-7B91-45D2-838C-F527920FC527}</ProjectGuid>	");
            fs.WriteLine("	    <OutputType>WinExe</OutputType>	");
            fs.WriteLine("	    <AppDesignerFolder>Properties</AppDesignerFolder>	");
            //aqui le modifique
            fs.WriteLine("	    <RootNamespace>safeprojectname</RootNamespace>	");
            fs.WriteLine("	    <AssemblyName>safeprojectname</AssemblyName>	");

            fs.WriteLine("	  </PropertyGroup>	");
            fs.WriteLine("	  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">	");
            fs.WriteLine("	    <DebugSymbols>true</DebugSymbols>	");
            fs.WriteLine("	    <DebugType>full</DebugType>	");
            fs.WriteLine("	    <Optimize>false</Optimize>	");
            fs.WriteLine("	    <OutputPath>bin\\Debug\\</OutputPath>	");
            fs.WriteLine("	    <DefineConstants>DEBUG;TRACE</DefineConstants>	");
            fs.WriteLine("	    <ErrorReport>prompt</ErrorReport>	");
            fs.WriteLine("	    <WarningLevel>4</WarningLevel>	");
            fs.WriteLine("	  </PropertyGroup>	");
            fs.WriteLine("	  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">	");
            fs.WriteLine("	    <DebugType>pdbonly</DebugType>	");
            fs.WriteLine("	    <Optimize>true</Optimize>	");
            fs.WriteLine("	    <OutputPath>bin\\Release\\</OutputPath>	");
            fs.WriteLine("	    <DefineConstants>TRACE</DefineConstants>	");
            fs.WriteLine("	    <ErrorReport>prompt</ErrorReport>	");
            fs.WriteLine("	    <WarningLevel>4</WarningLevel>	");
            fs.WriteLine("	  </PropertyGroup>	");
            fs.WriteLine("	  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|x86' \">	");
            fs.WriteLine("	    <DebugSymbols>true</DebugSymbols>	");
            fs.WriteLine("	    <OutputPath>bin\\x86\\Debug\\</OutputPath>	");
            fs.WriteLine("	    <DefineConstants>DEBUG;TRACE</DefineConstants>	");
            fs.WriteLine("	    <DebugType>full</DebugType>	");
            fs.WriteLine("	    <PlatformTarget>x86</PlatformTarget>	");
            fs.WriteLine("	    <ErrorReport>prompt</ErrorReport>	");
            fs.WriteLine("	  </PropertyGroup>	");
            fs.WriteLine("	  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x86' \">	");
            fs.WriteLine("	    <OutputPath>bin\\x86\\Release\\</OutputPath>	");
            fs.WriteLine("	    <DefineConstants>TRACE</DefineConstants>	");
            fs.WriteLine("	    <Optimize>true</Optimize>	");
            fs.WriteLine("	    <DebugType>pdbonly</DebugType>	");
            fs.WriteLine("	    <PlatformTarget>x86</PlatformTarget>	");
            fs.WriteLine("	    <ErrorReport>prompt</ErrorReport>	");
            fs.WriteLine("	  </PropertyGroup>	");
            fs.WriteLine("	  <ItemGroup>	");
            fs.WriteLine("	    <Reference Include=\"MySQLDriverCS, Version=3.0.1735.36021, Culture=neutral, PublicKeyToken=172f94dfb0faf263\">	");
            fs.WriteLine("	      <SpecificVersion>False</SpecificVersion>	");
            fs.WriteLine("	      <HintPath>..\\..\\aplicacion\\bin\\Debug\\MySQLDriverCS.dll</HintPath>	");
            fs.WriteLine("	    </Reference>	");
            fs.WriteLine("	    <Reference Include=\"System\" />	");
            fs.WriteLine("	    <Reference Include=\"System.Data\" />	");
            fs.WriteLine("	    <Reference Include=\"System.Deployment\" />	");
            fs.WriteLine("	    <Reference Include=\"System.Drawing\" />	");
            fs.WriteLine("	    <Reference Include=\"System.Windows.Forms\" />	");
            fs.WriteLine("	    <Reference Include=\"System.Xml\" />	");
            fs.WriteLine("	  </ItemGroup>	");
            fs.WriteLine("	  <ItemGroup>	");

            fs.WriteLine("	    <Compile Include=\"Form1.cs\">	");
            fs.WriteLine("	      <SubType>Form</SubType>	");
            fs.WriteLine("	    </Compile>	");
            fs.WriteLine("	    <Compile Include=\"Form1.Designer.cs\">	");
            fs.WriteLine("	      <DependentUpon>Form1.cs</DependentUpon>	");
            fs.WriteLine("	    </Compile>	");

            //fs.WriteLine("	    <Compile Include=\"Form2.cs\">	");
            //fs.WriteLine("	      <SubType>Form</SubType>	");
            //fs.WriteLine("	    </Compile>	");
            //fs.WriteLine("	    <Compile Include=\"Form2.Designer.cs\">	");
            //fs.WriteLine("	      <DependentUpon>Form2.cs</DependentUpon>	");
            //fs.WriteLine("	    </Compile>	");

            n = 3;
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                fs.WriteLine("	    <Compile Include=\"Form" + n.ToString() + ".cs\">	");
                fs.WriteLine("	      <SubType>Form</SubType>	");
                fs.WriteLine("	    </Compile>	");
                fs.WriteLine("	    <Compile Include=\"Form" + n.ToString() + ".Designer.cs\">	");
                fs.WriteLine("	      <DependentUpon>Form" + n.ToString() + ".cs</DependentUpon>	");
                fs.WriteLine("	    </Compile>	");
            }
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                fs.WriteLine("	    <Compile Include=\"Form" + n.ToString() + ".cs\">	");
                fs.WriteLine("	      <SubType>Form</SubType>	");
                fs.WriteLine("	    </Compile>	");
                fs.WriteLine("	    <Compile Include=\"Form" + n.ToString() + ".Designer.cs\">	");
                fs.WriteLine("	      <DependentUpon>Form" + n.ToString() + ".cs</DependentUpon>	");
                fs.WriteLine("	    </Compile>	");
            }
            fs.WriteLine("	    <Compile Include=\"Program.cs\" />	");
            fs.WriteLine("	    <Compile Include=\"Properties\\AssemblyInfo.cs\" />	");

            fs.WriteLine("	    <EmbeddedResource Include=\"Form1.resx\">	");
            fs.WriteLine("	      <SubType>Designer</SubType>	");
            fs.WriteLine("	      <DependentUpon>Form1.cs</DependentUpon>	");
            fs.WriteLine("	    </EmbeddedResource>	");

            //fs.WriteLine("	    <EmbeddedResource Include=\"Form2.resx\">	");
            //fs.WriteLine("	      <SubType>Designer</SubType>	");
            //fs.WriteLine("	      <DependentUpon>Form2.cs</DependentUpon>	");
            //fs.WriteLine("	    </EmbeddedResource>	");
            n = 3;
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                fs.WriteLine("	    <EmbeddedResource Include=\"Form" + n.ToString() + ".resx\">	");
                fs.WriteLine("	      <SubType>Designer</SubType>	");
                fs.WriteLine("	      <DependentUpon>Form" + n.ToString() + ".cs</DependentUpon>	");
                fs.WriteLine("	    </EmbeddedResource>	");
            }

            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                fs.WriteLine("	    <EmbeddedResource Include=\"Form" + n.ToString() + ".resx\">	");
                fs.WriteLine("	      <SubType>Designer</SubType>	");
                fs.WriteLine("	      <DependentUpon>Form" + n.ToString() + ".cs</DependentUpon>	");
                fs.WriteLine("	    </EmbeddedResource>	");
            }
            fs.WriteLine("	    <EmbeddedResource Include=\"Properties\\Resources.resx\">	");
            fs.WriteLine("	      <Generator>ResXFileCodeGenerator</Generator>	");
            fs.WriteLine("	      <LastGenOutput>Resources.Designer.cs</LastGenOutput>	");
            fs.WriteLine("	      <SubType>Designer</SubType>	");
            fs.WriteLine("	    </EmbeddedResource>	");
            fs.WriteLine("	    <Compile Include=\"Properties\\Resources.Designer.cs\">	");
            fs.WriteLine("	      <AutoGen>True</AutoGen>	");
            fs.WriteLine("	      <DependentUpon>Resources.resx</DependentUpon>	");
            fs.WriteLine("	    </Compile>	");
            fs.WriteLine("	    <None Include=\"Properties\\Settings.settings\">	");
            fs.WriteLine("	      <Generator>SettingsSingleFileGenerator</Generator>	");
            fs.WriteLine("	      <LastGenOutput>Settings.Designer.cs</LastGenOutput>	");
            fs.WriteLine("	    </None>	");
            fs.WriteLine("	    <Compile Include=\"Properties\\Settings.Designer.cs\">	");
            fs.WriteLine("	      <AutoGen>True</AutoGen>	");
            fs.WriteLine("	      <DependentUpon>Settings.settings</DependentUpon>	");
            fs.WriteLine("	      <DesignTimeSharedInput>True</DesignTimeSharedInput>	");
            fs.WriteLine("	    </Compile>	");
            fs.WriteLine("	  </ItemGroup>	");
            fs.WriteLine("	  <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />	");
            fs.WriteLine("	  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 	");
            fs.WriteLine("	       Other similar extension points exist, see Microsoft.Common.targets.	");
            fs.WriteLine("	  <Target Name=\"BeforeBuild\">	");
            fs.WriteLine("	  </Target>	");
            fs.WriteLine("	  <Target Name=\"AfterBuild\">	");
            fs.WriteLine("	  </Target>	");
            fs.WriteLine("	  -->	");
            fs.WriteLine("	</Project>	");
            fs.Close();


            //generacion automatica de los forms respectivos de arriba 
            //mas abajo se generan sus respectivos diseños 

            n = 3;
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                StreamWriter formularios = new StreamWriter(final + "Form" + n.ToString() + ".cs");
                formularios.WriteLine("using System;");
                formularios.WriteLine("using System.Collections.Generic;");
                formularios.WriteLine("using System.ComponentModel;");
                formularios.WriteLine("using System.Data;");
                formularios.WriteLine("using System.Drawing;");
                formularios.WriteLine("using System.Text;");
                formularios.WriteLine("using System.Windows.Forms;");
                formularios.WriteLine("using MySQLDriverCS;");
                formularios.WriteLine("using System.IO;");
                formularios.WriteLine("namespace safeprojectname");
                formularios.WriteLine("{");
                formularios.WriteLine("public partial class Form" + n.ToString() + " : Form");
                formularios.WriteLine("{");
                formularios.WriteLine("public Form" + n.ToString() + "()");
                formularios.WriteLine("    {");
                formularios.WriteLine("    InitializeComponent();");
                formularios.WriteLine("    }");
                formularios.WriteLine("private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();	");
                formularios.WriteLine("	            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();	");
                formularios.WriteLine("	            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();	");
                formularios.WriteLine("	            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();	");
                formularios.WriteLine("	            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();	");
                formularios.WriteLine("	            	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button1_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                // formularios.WriteLine(" MessageBox.Show(\"Aqui esta el codigo \");");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("	                \"Select * from " + listBox2.Items[(n - 3) % 4].ToString().Trim() + "\" , con);	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            dataGridView1.Rows.Clear();	");

                formularios.WriteLine("	            while (data.Read())	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                dataGridView1.Rows.Add(	");

                listBox2.SelectedIndex = (n - 3) % 4;
                listBox2_MouseClick(sender, null);

                for (int j = 0; j < listBox3.Items.Count - 1; j++)
                {
                    formularios.WriteLine("data.GetString(" + j.ToString() + "),");
                }
                formularios.WriteLine("data.GetString(" + (listBox3.Items.Count - 2).ToString() + "));");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button2_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(");
                formularios.WriteLine("\"insert into " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " values('null\" +");
                for (int k = 0, c = 3; k < listBox3.Items.Count; k++, c++)
                {
                    formularios.WriteLine("\"', '\" + textBox" + c.ToString() + ".Text +");
                }
                formularios.WriteLine("\"')\", con);");

                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            button1_Click(sender, e);	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button3_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("	                \"delete from " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " where " + listBox3.Items[0].ToString().Trim() + "='\" + textBox2.Text, con);	");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("	            button1_Click(sender, e);	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button4_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	                {	");
                formularios.WriteLine("	                    con.Open();	");
                formularios.WriteLine("	                }	");
                formularios.WriteLine("	                catch (Exception ex)	");
                formularios.WriteLine("	                {	");
                formularios.WriteLine("	                    MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                    return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	                }	");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	                MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("\"update " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " set \" +");
                for (int k = 1, c = 3; k < listBox3.Items.Count - 1; k++, c++)
                {
                    formularios.WriteLine("\"" + listBox3.Items[k].ToString().Trim() + " = '\" + textBox" + c.ToString() + ".Text + \"', \" +");
                }
                formularios.WriteLine("\"" + listBox3.Items[listBox3.Items.Count - 1].ToString().Trim() + " = '\" + textBox" + (listBox3.Items.Count - 1).ToString() + ".Text + \"' where " + listBox3.Items[0].ToString().Trim() + "='\" + textBox" + (listBox3.Items.Count - 1).ToString() + ".Text + \"'\", con);");

                





                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	                MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	                con.Close();	");
                formularios.WriteLine("	                button1_Click(sender, e);	");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button5_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            Close();	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void Form3_Load(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");

                //depurar esta parte 
                /* formularios.WriteLine("	            dataGridView1.Columns.Add("id_alumno", "id_alumno");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("alumno", "alumno");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("domicilio", "domicilio");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("celular", "celular");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("email", "email");	");
                formularios.WriteLine("	            	");
                */
                formularios.WriteLine("	        }	");
                formularios.WriteLine("	    }	");
                formularios.WriteLine("	}	");
                formularios.Close();


                //Reportes
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                StreamWriter formularios = new StreamWriter(final + "Form" + n.ToString() + ".cs");
                formularios.WriteLine("using System;");
                formularios.WriteLine("using System.Collections.Generic;");
                formularios.WriteLine("using System.ComponentModel;");
                formularios.WriteLine("using System.Data;");
                formularios.WriteLine("using System.Drawing;");
                formularios.WriteLine("using System.Text;");
                formularios.WriteLine("using System.Windows.Forms;");
                formularios.WriteLine("using MySQLDriverCS;");
                formularios.WriteLine("using System.IO;");
                formularios.WriteLine("namespace safeprojectname");
                formularios.WriteLine("{");
                formularios.WriteLine("public partial class Form" + n.ToString() + " : Form");
                formularios.WriteLine("{");
                formularios.WriteLine("public Form" + n.ToString() + "()");
                formularios.WriteLine("    {");
                formularios.WriteLine("    InitializeComponent();");
                formularios.WriteLine("    }");
                formularios.WriteLine("private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();	");
                formularios.WriteLine("	            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();	");
                formularios.WriteLine("	            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();	");
                formularios.WriteLine("	            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();	");
                formularios.WriteLine("	            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();	");
                formularios.WriteLine("	            	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button1_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                // formularios.WriteLine(" MessageBox.Show(\"Aqui esta el codigo \");");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("	                \"Select * from " + listBox2.Items[(n - 3) % 4].ToString().Trim() + "\" , con);	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            dataGridView1.Rows.Clear();	");

                formularios.WriteLine("	            while (data.Read())	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                dataGridView1.Rows.Add(	");

                listBox2.SelectedIndex = (n - 3) % 4;
                listBox2_MouseClick(sender, null);

                for (int j = 0; j < listBox3.Items.Count - 1; j++)
                {
                    formularios.WriteLine("data.GetString(" + j.ToString() + "),");
                }
                formularios.WriteLine("data.GetString(" + (listBox3.Items.Count - 2).ToString() + "));");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button2_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(");
                formularios.WriteLine("\"insert into " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " values('null\" +");
                for (int k = 0, c = 3; k < listBox3.Items.Count; k++, c++)
                {
                    formularios.WriteLine("\"', '\" + textBox" + c.ToString() + ".Text +");
                }
                formularios.WriteLine("\"')\", con);");

                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            button1_Click(sender, e);	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button3_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                con.Open();	");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            catch (Exception ex)	");
                formularios.WriteLine("	            {	");
                formularios.WriteLine("	                MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            }	");
                formularios.WriteLine("	            MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("	                \"delete from " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " where " + listBox3.Items[0].ToString().Trim() + "='\" + textBox2.Text, con);	");
                formularios.WriteLine("	            MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	            con.Close();	");
                formularios.WriteLine("	            button1_Click(sender, e);	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button4_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("		");
                formularios.WriteLine("	            MySQLConnection con = new MySQLConnection(	");
                formularios.WriteLine("	               new MySQLConnectionString(\"" + listBox1.Items[listBox1.SelectedIndex].ToString().Trim() + "\", \"root\", \"\").AsString); ");
                formularios.WriteLine("	            try	");
                formularios.WriteLine("	                {	");
                formularios.WriteLine("	                    con.Open();	");
                formularios.WriteLine("	                }	");
                formularios.WriteLine("	                catch (Exception ex)	");
                formularios.WriteLine("	                {	");
                formularios.WriteLine("	                    MessageBox.Show(ex.Message);	");
                formularios.WriteLine("	                    return;	");
                formularios.WriteLine("		");
                formularios.WriteLine("	                }	");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	                MySQLCommand query = new MySQLCommand(	");
                formularios.WriteLine("\"update " + listBox2.Items[(n - 3) % 4].ToString().Trim() + " set \" +");
                for (int k = 1, c = 3; k < listBox3.Items.Count - 1; k++, c++)
                {
                    formularios.WriteLine("\"" + listBox3.Items[k].ToString().Trim() + " = '\" + textBox" + c.ToString() + ".Text + \"', \" +");
                }
                formularios.WriteLine("\"" + listBox3.Items[listBox3.Items.Count - 1].ToString().Trim() + " = '\" + textBox" + (listBox3.Items.Count - 1).ToString() + ".Text + \"' where " + listBox3.Items[0].ToString().Trim() + "='\" + textBox" + (listBox3.Items.Count - 1).ToString() + ".Text + \"'\", con);");

                





                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	                MySQLDataReader data = query.ExecuteReaderEx();	");
                formularios.WriteLine("	                con.Close();	");
                formularios.WriteLine("	                button1_Click(sender, e);	");
                formularios.WriteLine("		");
                formularios.WriteLine("		");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void button5_Click(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");
                formularios.WriteLine("	            Close();	");
                formularios.WriteLine("	        }	");
                formularios.WriteLine("		");
                formularios.WriteLine("	        private void Form3_Load(object sender, EventArgs e)	");
                formularios.WriteLine("	        {	");

                //depurar esta parte 
                /* formularios.WriteLine("	            dataGridView1.Columns.Add("id_alumno", "id_alumno");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("alumno", "alumno");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("domicilio", "domicilio");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("celular", "celular");	");
                formularios.WriteLine("	            dataGridView1.Columns.Add("email", "email");	");
                formularios.WriteLine("	            	");
                */
                formularios.WriteLine("	        }	");
                formularios.WriteLine("	    }	");
                formularios.WriteLine("	}	");
                formularios.Close();
                //Termina Reportes
            }


            n = 3;
            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                listBox2.SelectedIndex = i;
                listBox2_MouseClick(sender, null);
                StreamWriter formulariodisenador = new StreamWriter(final + "Form" + n.ToString() + ".Designer.cs");
                formulariodisenador.WriteLine("namespace safeprojectname");
                formulariodisenador.WriteLine("{");
                formulariodisenador.WriteLine("partial class Form" + n.ToString() + "");
                formulariodisenador.WriteLine(" {");
                formulariodisenador.WriteLine(" /// <summary>");
                formulariodisenador.WriteLine(" /// Required designer variable.");
                formulariodisenador.WriteLine("  /// </summary>");
                formulariodisenador.WriteLine(" private System.ComponentModel.IContainer components = null;");
                formulariodisenador.WriteLine("   /// <summary>");
                formulariodisenador.WriteLine("/// Clean up any resources being used.");
                formulariodisenador.WriteLine("  /// </summary>");
                formulariodisenador.WriteLine("/// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>");
                formulariodisenador.WriteLine(" protected override void Dispose(bool disposing)");
                formulariodisenador.WriteLine("  {");
                formulariodisenador.WriteLine("if (disposing && (components != null))");
                formulariodisenador.WriteLine("  {");
                formulariodisenador.WriteLine("components.Dispose();");
                formulariodisenador.WriteLine("  }");
                formulariodisenador.WriteLine("base.Dispose(disposing);");
                formulariodisenador.WriteLine("   }");
                formulariodisenador.WriteLine(" #region Windows Form Designer generated code");
                formulariodisenador.WriteLine("/// <summary>");
                formulariodisenador.WriteLine("/// Required method for Designer support - do not modify");
                formulariodisenador.WriteLine("/// the contents of this method with the code editor.");
                formulariodisenador.WriteLine("/// </summary>");
                formulariodisenador.WriteLine(" private void InitializeComponent()");
                formulariodisenador.WriteLine(" {");
                formulariodisenador.WriteLine("  this.components = new System.ComponentModel.Container();");
                formulariodisenador.WriteLine("this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
                formulariodisenador.WriteLine(" this.Text = \"Form" + n.ToString() + "\";");

                formulariodisenador.WriteLine("this.button1 = new System.Windows.Forms.Button();");
                formulariodisenador.WriteLine("this.textBox1 = new System.Windows.Forms.TextBox();");
                formulariodisenador.WriteLine("this.dataGridView1 = new System.Windows.Forms.DataGridView();");

                for (int j = 0; j < listBox3.Items.Count; j++)
                {
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + " = new System.Windows.Forms.Label();");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + " = new System.Windows.Forms.TextBox();");
                }
                formulariodisenador.WriteLine(" this.button5 = new System.Windows.Forms.Button();");
                formulariodisenador.WriteLine("this.button4 = new System.Windows.Forms.Button();");
                formulariodisenador.WriteLine("this.button3 = new System.Windows.Forms.Button();");
                formulariodisenador.WriteLine("this.button2 = new System.Windows.Forms.Button();");
                formulariodisenador.WriteLine("((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();");
                formulariodisenador.WriteLine("this.SuspendLayout();");

                formulariodisenador.WriteLine("// button1");
                formulariodisenador.WriteLine("this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));");
                formulariodisenador.WriteLine("this.button1.Location = new System.Drawing.Point(495, 9);");
                formulariodisenador.WriteLine("this.button1.Name = \"button1\";");
                formulariodisenador.WriteLine("this.button1.Size = new System.Drawing.Size(74, 23);");
                formulariodisenador.WriteLine("this.button1.TabIndex = 3;");
                formulariodisenador.WriteLine("this.button1.Text = \"Buscar\";");
                formulariodisenador.WriteLine("this.button1.UseVisualStyleBackColor = true;");
                formulariodisenador.WriteLine(" this.button1.Click += new System.EventHandler(this.button1_Click);");
                formulariodisenador.WriteLine("// textBox1");
                formulariodisenador.WriteLine("this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));");
                formulariodisenador.WriteLine("this.textBox1.Location = new System.Drawing.Point(12, 12);");
                formulariodisenador.WriteLine("this.textBox1.Name = \"textBox1\";");
                formulariodisenador.WriteLine("this.textBox1.Size = new System.Drawing.Size(477, 20);");
                formulariodisenador.WriteLine("this.textBox1.TabIndex = 2;");
                formulariodisenador.WriteLine("// dataGridView1");
                formulariodisenador.WriteLine("this.dataGridView1.AllowUserToAddRows = false;");
                formulariodisenador.WriteLine("this.dataGridView1.AllowUserToDeleteRows = false;");
                formulariodisenador.WriteLine("this.dataGridView1.AllowUserToOrderColumns = true;");
                formulariodisenador.WriteLine("this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));");
                formulariodisenador.WriteLine("this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;");
                formulariodisenador.WriteLine(" this.dataGridView1.Location = new System.Drawing.Point(9, 38);");
                formulariodisenador.WriteLine("this.dataGridView1.MultiSelect = false;");
                formulariodisenador.WriteLine("this.dataGridView1.Name = \"dataGridView1\";");
                formulariodisenador.WriteLine(" this.dataGridView1.ReadOnly = true;");
                formulariodisenador.WriteLine("this.dataGridView1.Size = new System.Drawing.Size(560, 238);");
                formulariodisenador.WriteLine("this.dataGridView1.TabIndex = 23;");
                formulariodisenador.WriteLine(" this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);");
                // for listbox3



                for (int j = 0; j < listBox3.Items.Count; j++)
                {

                    formulariodisenador.WriteLine("// label1");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".AutoSize = true;");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".Location = new System.Drawing.Point("
                        + (10 + j * (588 / listBox3.Items.Count)).ToString() + ", 291);");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".Name = \"label1\";");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".Size = new System.Drawing.Size(50, 13);");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".TabIndex = 24;");
                    formulariodisenador.WriteLine("this.label" + (j + 1).ToString() + ".Text = \"" + listBox3.Items[j].ToString().Trim() + "\";");
                    formulariodisenador.WriteLine(" // textBox" + (j + 2).ToString() + "");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + ".Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + ".Location = new System.Drawing.Point("
                        + (10 + j * (588 / listBox3.Items.Count)).ToString() + ", 307);");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + ".Name = \"textBox2\";");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + ".Size = new System.Drawing.Size(" + (576 / listBox3.Items.Count - 12).ToString() + ", 20);");
                    formulariodisenador.WriteLine("this.textBox" + (j + 2).ToString() + ".TabIndex = 25;");
                    //fin del for

                }
                //borrar
                formulariodisenador.WriteLine("// button5");
                formulariodisenador.WriteLine("this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                formulariodisenador.WriteLine("this.button5.Location = new System.Drawing.Point(277, 333);");
                formulariodisenador.WriteLine(" this.button5.Name = \"button5\";");
                formulariodisenador.WriteLine("this.button5.Size = new System.Drawing.Size(87, 23);");
                formulariodisenador.WriteLine("this.button5.TabIndex = 37;");
                formulariodisenador.WriteLine("this.button5.Text = \"Salir\";");
                formulariodisenador.WriteLine("this.button5.UseVisualStyleBackColor = true;");
                formulariodisenador.WriteLine(" this.button5.Click += new System.EventHandler(this.button5_Click);");
                formulariodisenador.WriteLine("// button4");
                formulariodisenador.WriteLine("this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                formulariodisenador.WriteLine("this.button4.Location = new System.Drawing.Point(184, 333);");
                formulariodisenador.WriteLine(" this.button4.Name = \"button4\";");
                formulariodisenador.WriteLine("this.button4.Size = new System.Drawing.Size(87, 23);");
                formulariodisenador.WriteLine("this.button4.TabIndex = 36;");
                formulariodisenador.WriteLine("this.button4.Text = \"Modificar\";");
                formulariodisenador.WriteLine("this.button4.UseVisualStyleBackColor = true;");
                formulariodisenador.WriteLine("this.button4.Click += new System.EventHandler(this.button4_Click);");
                formulariodisenador.WriteLine("// button3");
                formulariodisenador.WriteLine("this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                formulariodisenador.WriteLine("this.button3.Location = new System.Drawing.Point(92, 333);");
                formulariodisenador.WriteLine("this.button3.Name = \"button3\";");
                formulariodisenador.WriteLine(" this.button3.Size = new System.Drawing.Size(86, 23);");
                formulariodisenador.WriteLine(" this.button3.TabIndex = 35;");
                formulariodisenador.WriteLine("this.button3.Text = \"Eliminar\";");
                formulariodisenador.WriteLine("this.button3.UseVisualStyleBackColor = true;");
                formulariodisenador.WriteLine("this.button3.Click += new System.EventHandler(this.button3_Click);");
                formulariodisenador.WriteLine("  // button2");
                formulariodisenador.WriteLine("this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));");
                formulariodisenador.WriteLine("this.button2.Location = new System.Drawing.Point(11, 333);");
                formulariodisenador.WriteLine("this.button2.Name = \"button2\";");
                formulariodisenador.WriteLine("this.button2.Size = new System.Drawing.Size(75, 23);");
                formulariodisenador.WriteLine("this.button2.TabIndex = 34;");
                formulariodisenador.WriteLine("this.button2.Text = \"Agregar\";");
                formulariodisenador.WriteLine(" this.button2.UseVisualStyleBackColor = true;");
                formulariodisenador.WriteLine("this.button2.Click += new System.EventHandler(this.button2_Click);");
                formulariodisenador.WriteLine("// Form3");
                formulariodisenador.WriteLine("this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);");
                formulariodisenador.WriteLine(" this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
                formulariodisenador.WriteLine("this.ClientSize = new System.Drawing.Size(584, 361);");
                formulariodisenador.WriteLine("this.Controls.Add(this.button5);");
                formulariodisenador.WriteLine("this.Controls.Add(this.button4);");
                formulariodisenador.WriteLine("this.Controls.Add(this.button3);");
                formulariodisenador.WriteLine("this.Controls.Add(this.button2);");
                formulariodisenador.WriteLine("this.Controls.Add(this.textBox6);");
                for (int j = 0; j < listBox3.Items.Count; j++)
                {
                    formulariodisenador.WriteLine("this.Controls.Add(this.label" + (j + 1).ToString() + ");");
                    formulariodisenador.WriteLine("this.Controls.Add(this.textBox" + (j + 2).ToString() + ");");
                }
                formulariodisenador.WriteLine("this.Controls.Add(this.dataGridView1);");
                formulariodisenador.WriteLine(" this.Controls.Add(this.button1);");
                formulariodisenador.WriteLine("this.Controls.Add(this.textBox1);");
                formulariodisenador.WriteLine(" this.MinimumSize = new System.Drawing.Size(600, 400);");
                formulariodisenador.WriteLine("this.Name = \"Form" + n.ToString() + "\";");
                formulariodisenador.WriteLine("this.Text = \"" + listBox2.Items[(n - 3) % 4].ToString().Trim() + "\";");
                //formulariodisenador.WriteLine("this.Load += new System.EventHandler(this.Form3_Load);");
                formulariodisenador.WriteLine("((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();");
                formulariodisenador.WriteLine("this.ResumeLayout(false);");
                formulariodisenador.WriteLine("this.PerformLayout();");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");



                formulariodisenador.WriteLine("    }");
                formulariodisenador.WriteLine(" #endregion");



                formulariodisenador.WriteLine("private System.Windows.Forms.Button button1;");
                formulariodisenador.WriteLine("private System.Windows.Forms.TextBox textBox1;");
                formulariodisenador.WriteLine("private System.Windows.Forms.DataGridView dataGridView1;");
                for (int j = 0; j < listBox3.Items.Count; j++)
                {
                    formulariodisenador.WriteLine("private System.Windows.Forms.Label label" + (j + 1).ToString() + ";");
                    formulariodisenador.WriteLine(" private System.Windows.Forms.TextBox textBox" + (j + 2).ToString() + ";");
                }
                formulariodisenador.WriteLine("private System.Windows.Forms.Button button5;");
                formulariodisenador.WriteLine("private System.Windows.Forms.Button button4;");
                formulariodisenador.WriteLine("private System.Windows.Forms.Button button3;");
                formulariodisenador.WriteLine("private System.Windows.Forms.Button button2;");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("");
                formulariodisenador.WriteLine("   }");
                formulariodisenador.WriteLine("}");
                formulariodisenador.WriteLine("");
                formulariodisenador.Close();


            }

            for (int i = 0; i < listBox2.Items.Count; i++, n++)
            {
                StreamWriter Formulariodisenador2 = new StreamWriter(final + "Form" + n.ToString() + ".Designer.cs");
                Formulariodisenador2.WriteLine("namespace safeprojectname");
                Formulariodisenador2.WriteLine("	{	");
                Formulariodisenador2.WriteLine("	    partial class Form" + n.ToString() + "	");
                Formulariodisenador2.WriteLine("	    {	");
                Formulariodisenador2.WriteLine("	        /// <summary>	");
                Formulariodisenador2.WriteLine("	        /// Required designer variable.	");
                Formulariodisenador2.WriteLine("	        /// </summary>	");
                Formulariodisenador2.WriteLine("	        private System.ComponentModel.IContainer components = null;	");
                Formulariodisenador2.WriteLine("		");
                Formulariodisenador2.WriteLine("	        /// <summary>	");
                Formulariodisenador2.WriteLine("	        /// Clean up any resources being used.	");
                Formulariodisenador2.WriteLine("	        /// </summary>	");
                Formulariodisenador2.WriteLine("	        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>	");
                Formulariodisenador2.WriteLine("	        protected override void Dispose(bool disposing)	");
                Formulariodisenador2.WriteLine("	        {	");
                Formulariodisenador2.WriteLine("	            if (disposing && (components != null))	");
                Formulariodisenador2.WriteLine("	            {	");
                Formulariodisenador2.WriteLine("	                components.Dispose();	");
                Formulariodisenador2.WriteLine("	            }	");
                Formulariodisenador2.WriteLine("	            base.Dispose(disposing);	");
                Formulariodisenador2.WriteLine("	        }	");
                Formulariodisenador2.WriteLine("		");
                Formulariodisenador2.WriteLine("	        #region Windows Form Designer generated code	");
                Formulariodisenador2.WriteLine("		");
                Formulariodisenador2.WriteLine("	        /// <summary>	");
                Formulariodisenador2.WriteLine("	        /// Required method for Designer support - do not modify	");
                Formulariodisenador2.WriteLine("	        /// the contents of this method with the code editor.	");
                Formulariodisenador2.WriteLine("	        /// </summary>	");
                Formulariodisenador2.WriteLine("	        private void InitializeComponent()	");
                Formulariodisenador2.WriteLine("	        {	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1 = new System.Windows.Forms.WebBrowser();	");
                Formulariodisenador2.WriteLine("	            this.button1 = new System.Windows.Forms.Button();	");
                Formulariodisenador2.WriteLine("	            this.button2 = new System.Windows.Forms.Button();	");
                Formulariodisenador2.WriteLine("	            this.button3 = new System.Windows.Forms.Button();	");
                Formulariodisenador2.WriteLine("	            this.SuspendLayout();	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            // webBrowser1	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)	");
                Formulariodisenador2.WriteLine("	                        | System.Windows.Forms.AnchorStyles.Left)	");
                Formulariodisenador2.WriteLine("	                        | System.Windows.Forms.AnchorStyles.Right)));	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.Location = new System.Drawing.Point(12, 42);	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.Name = \"webBrowser1\";	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.Size = new System.Drawing.Size(560, 307);	");
                Formulariodisenador2.WriteLine("	            this.webBrowser1.TabIndex = 5;	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            // button1	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            this.button1.Location = new System.Drawing.Point(12, 12);	");
                Formulariodisenador2.WriteLine("	            this.button1.Name = \"button1\";	");
                Formulariodisenador2.WriteLine("	            this.button1.Size = new System.Drawing.Size(75, 23);	");
                Formulariodisenador2.WriteLine("	            this.button1.TabIndex = 6;	");
                Formulariodisenador2.WriteLine("	            this.button1.Text = \"Generar\";	");
                Formulariodisenador2.WriteLine("	            this.button1.UseVisualStyleBackColor = true;	");
                Formulariodisenador2.WriteLine("	            this.button1.Click += new System.EventHandler(this.button1_Click);	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            // button2	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            this.button2.Location = new System.Drawing.Point(93, 12);	");
                Formulariodisenador2.WriteLine("	            this.button2.Name = \"button2\";	");
                Formulariodisenador2.WriteLine("	            this.button2.Size = new System.Drawing.Size(75, 23);	");
                Formulariodisenador2.WriteLine("	            this.button2.TabIndex = 7;	");
                Formulariodisenador2.WriteLine("	            this.button2.Text = \"Navegador\";	");
                Formulariodisenador2.WriteLine("	            this.button2.UseVisualStyleBackColor = true;	");
                Formulariodisenador2.WriteLine("	            this.button2.Click += new System.EventHandler(this.button2_Click);	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            // button3	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            this.button3.Location = new System.Drawing.Point(174, 13);	");
                Formulariodisenador2.WriteLine("	            this.button3.Name = \"button3\";	");
                Formulariodisenador2.WriteLine("	            this.button3.Size = new System.Drawing.Size(75, 23);	");
                Formulariodisenador2.WriteLine("	            this.button3.TabIndex = 8;	");
                Formulariodisenador2.WriteLine("	            this.button3.Text = \"Salir\";	");
                Formulariodisenador2.WriteLine("	            this.button3.UseVisualStyleBackColor = true;	");
                Formulariodisenador2.WriteLine("	            this.button3.Click += new System.EventHandler(this.button3_Click);	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            // Form8	");
                Formulariodisenador2.WriteLine("	            // 	");
                Formulariodisenador2.WriteLine("	            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);	");
                Formulariodisenador2.WriteLine("	            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;	");
                Formulariodisenador2.WriteLine("	            this.ClientSize = new System.Drawing.Size(584, 361);	");
                Formulariodisenador2.WriteLine("	            this.Controls.Add(this.button3);	");
                Formulariodisenador2.WriteLine("	            this.Controls.Add(this.button2);	");
                Formulariodisenador2.WriteLine("	            this.Controls.Add(this.button1);	");
                Formulariodisenador2.WriteLine("	            this.Controls.Add(this.webBrowser1);	");
                Formulariodisenador2.WriteLine("	            this.MinimumSize = new System.Drawing.Size(600, 400);	");
                Formulariodisenador2.WriteLine("	            this.Name = \"Form" + n.ToString() + "\";	");
                Formulariodisenador2.WriteLine("	            this.Text = \"" + listBox2.Items[(n - 3) % 4].ToString().Trim() + "\";");
                Formulariodisenador2.WriteLine("	            this.ResumeLayout(false);	");
                Formulariodisenador2.WriteLine("		}");
                Formulariodisenador2.WriteLine("	        #endregion	");
                Formulariodisenador2.WriteLine("		");
                Formulariodisenador2.WriteLine("	        private System.Windows.Forms.WebBrowser webBrowser1;	");
                Formulariodisenador2.WriteLine("	        private System.Windows.Forms.Button button1;	");
                Formulariodisenador2.WriteLine("	        private System.Windows.Forms.Button button2;	");
                Formulariodisenador2.WriteLine("	        private System.Windows.Forms.Button button3;	");
                Formulariodisenador2.WriteLine("	        }	");
                Formulariodisenador2.WriteLine("		}");

                Formulariodisenador2.Close();


            }



            n = 3;
            for (int i = 0; i < listBox2.Items.Count * 2; i++, n++)
            {
                StreamWriter fresx = new StreamWriter(final + "Form" + n.ToString() + ".resx");
                fresx.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                fresx.WriteLine("<root>");
                fresx.WriteLine("<!-- ");
                fresx.WriteLine("Microsoft ResX Schema ");
                fresx.WriteLine("Version 2.0");
                fresx.WriteLine(" The primary goals of this format is to allow a simple XML format");
                fresx.WriteLine(" that is mostly human readable. The generation and parsing of the ");
                fresx.WriteLine("various data types are done through the TypeConverter classes ");
                fresx.WriteLine("associated with the data types.");
                fresx.WriteLine("Example:");
                fresx.WriteLine(" ... ado.net/XML headers & schema ...");
                fresx.WriteLine("<resheader name=\"resmimetype\">text/microsoft-resx</resheader>");
                fresx.WriteLine("<resheader name=\"version\">2.0</resheader>");
                fresx.WriteLine("    <resheader name=\"reader\">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>");
                fresx.WriteLine("    <resheader name=\"writer\">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>");
                fresx.WriteLine(" <data name=\"Name1\"><value>this is my long string</value><comment>this is a comment</comment></data>");
                fresx.WriteLine("<data name=\"Color1\" type=\"System.Drawing.Color, System.Drawing\">Blue</data>");
                fresx.WriteLine(" <data name=\"Bitmap1\" mimetype=\"application/x-microsoft.net.object.binary.base64\">");
                fresx.WriteLine("  <value>[base64 mime encoded serialized .NET Framework object]</value>");
                fresx.WriteLine("</data>");
                fresx.WriteLine("<data name=\"Icon1\" type=\"System.Drawing.Icon, System.Drawing\" mimetype=\"application/x-microsoft.net.object.bytearray.base64\">");
                fresx.WriteLine("      <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>");
                fresx.WriteLine(" <comment>This is a comment</comment>");
                fresx.WriteLine("</data>");
                fresx.WriteLine(" There are any number of \"resheader\" rows that contain simple ");
                fresx.WriteLine("name/value pairs.");
                fresx.WriteLine(" Each data row contains a name, and value. The row also contains a");
                fresx.WriteLine("  type or mimetype. Type corresponds to a .NET class that support");
                fresx.WriteLine("text/value conversion through the TypeConverter architecture.");
                fresx.WriteLine("Classes that don't support this are serialized and stored with the ");
                fresx.WriteLine(" mimetype set.");
                fresx.WriteLine("The mimetype is used for serialized objects, and tells the ");
                fresx.WriteLine("ResXResourceReader how to depersist the object. This is currently not ");
                fresx.WriteLine("extensible. For a given mimetype the value must be set accordingly:");
                fresx.WriteLine("  Note - application/x-microsoft.net.object.binary.base64 is the format ");
                fresx.WriteLine("that the ResXResourceWriter will generate, however the reader can ");
                fresx.WriteLine("read any of the formats listed below.");
                fresx.WriteLine("  mimetype: application/x-microsoft.net.object.binary.base64");
                fresx.WriteLine("value   : The object must be serialized with ");
                fresx.WriteLine("  : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter");
                fresx.WriteLine(" : and then encoded with base64 encoding.");
                fresx.WriteLine(" mimetype: application/x-microsoft.net.object.soap.base64");
                fresx.WriteLine("  value   : The object must be serialized with ");
                fresx.WriteLine(" : System.Runtime.Serialization.Formatters.Soap.SoapFormatter");
                fresx.WriteLine("  : and then encoded with base64 encoding.");
                fresx.WriteLine("  mimetype: application/x-microsoft.net.object.bytearray.base64");
                fresx.WriteLine(" value   : The object must be serialized into a byte array ");
                fresx.WriteLine("  : using a System.ComponentModel.TypeConverter");
                fresx.WriteLine("  : and then encoded with base64 encoding.");
                fresx.WriteLine("   -->");
                fresx.WriteLine("  <xsd:schema id=\"root\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">");
                fresx.WriteLine("  <xsd:import namespace=\"http://www.w3.org/XML/1998/namespace\" />");
                fresx.WriteLine(" <xsd:element name=\"root\" msdata:IsDataSet=\"true\">");
                fresx.WriteLine("    <xsd:complexType>");
                fresx.WriteLine("   <xsd:choice maxOccurs=\"unbounded\">");
                fresx.WriteLine("   <xsd:element name=\"metadata\">");
                fresx.WriteLine("<xsd:complexType>");
                fresx.WriteLine("<xsd:sequence>");
                fresx.WriteLine(" <xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" />");
                fresx.WriteLine(" </xsd:sequence>");
                fresx.WriteLine(" <xsd:attribute name=\"name\" use=\"required\" type= \"xsd:string\" />");
                fresx.WriteLine(" <xsd:attribute name=\"type\" type=\"xsd:string\" />");
                fresx.WriteLine("  <xsd:attribute name=\"mimetype\" type=\"xsd:string\" />");
                fresx.WriteLine("  <xsd:attribute ref=\"xml:space\" />");
                fresx.WriteLine("</xsd:complexType>");
                fresx.WriteLine("</xsd:element>");
                fresx.WriteLine(" <xsd:element name=\"assembly\">");
                fresx.WriteLine("  <xsd:complexType>");
                fresx.WriteLine("    <xsd:attribute name=\"alias\" type=\"xsd:string\" />");
                fresx.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" />");
                fresx.WriteLine("  </xsd:complexType>");
                fresx.WriteLine("</xsd:element>");
                fresx.WriteLine("<xsd:element name=\"data\">");
                fresx.WriteLine("<xsd:complexType>");
                fresx.WriteLine("<xsd:sequence>");
                fresx.WriteLine("<xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
                fresx.WriteLine("  <xsd:element name=\"comment\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"2\" />");
                fresx.WriteLine("</xsd:sequence>");
                fresx.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" msdata:Ordinal=\"1\" />");
                fresx.WriteLine("   <xsd:attribute name=\"type\" type=\"xsd:string\" msdata:Ordinal=\"3\" />");
                fresx.WriteLine("<xsd:attribute name=\"mimetype\" type=\"xsd:string\" msdata:Ordinal=\"4\" />");
                fresx.WriteLine("<xsd:attribute ref=\"xml:space\" />");
                fresx.WriteLine("   </xsd:complexType>");
                fresx.WriteLine(" </xsd:element>");
                fresx.WriteLine("<xsd:element name=\"resheader\">");
                fresx.WriteLine("<xsd:complexType>");
                fresx.WriteLine(" <xsd:sequence>");
                fresx.WriteLine("<xsd:element name=\"value\" type=\"xsd:string\" minOccurs=\"0\" msdata:Ordinal=\"1\" />");
                fresx.WriteLine(" </xsd:sequence>");
                fresx.WriteLine("<xsd:attribute name=\"name\" type=\"xsd:string\" use=\"required\" />");
                fresx.WriteLine(" </xsd:complexType>");
                fresx.WriteLine("  </xsd:element>");
                fresx.WriteLine("</xsd:choice>");
                fresx.WriteLine("</xsd:complexType>");
                fresx.WriteLine("</xsd:element>");
                fresx.WriteLine("</xsd:schema>");
                fresx.WriteLine("<resheader name=\"resmimetype\">");
                fresx.WriteLine("    <value>text/microsoft-resx</value>");
                fresx.WriteLine(" </resheader>");
                fresx.WriteLine("  <resheader name=\"version\">");
                fresx.WriteLine(" <value>2.0</value>");
                fresx.WriteLine(" </resheader>");
                fresx.WriteLine("<resheader name=\"reader\">");
                fresx.WriteLine(" <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
                fresx.WriteLine("</resheader>");
                fresx.WriteLine("<resheader name=\"writer\">");
                fresx.WriteLine(" <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
                fresx.WriteLine("</resheader>");
                fresx.WriteLine(" <metadata name=\"menuStrip1.TrayLocation\" type=\"System.Drawing.Point, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\">");
                fresx.WriteLine(" <value>17, 17</value>");
                fresx.WriteLine(" </metadata>");
                fresx.WriteLine("</root>");
                fresx.Close();


            }













        

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            button2_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}