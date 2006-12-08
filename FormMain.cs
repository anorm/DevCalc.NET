using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace DevCalcNET
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.TextBox txtOutput;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MathParser parser;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem operatorsConstantsToolStripMenuItem;
        private string log;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            Text = Application.ProductName + " v" + Application.ProductVersion;
			parser = new MathParser();
            log = "";

            txtInput.Text = "help";

            string[] operatorFiles = Directory.GetFiles(Properties.Settings.Default.OperatorPath, "*.operator");
            foreach(string operatorFile in operatorFiles)
            {
                try
                {
                    CSharpCodeProvider csCompiler = new CSharpCodeProvider();
                    CodeDomProvider iCodeCompiler = CSharpCodeProvider.CreateProvider("C#");

                    CompilerParameters par = new System.CodeDom.Compiler.CompilerParameters();
                    par.GenerateInMemory = true;
                    par.GenerateExecutable = false;
                    par.ReferencedAssemblies.Add("System.dll");
                    par.ReferencedAssemblies.Add("dc.exe");
                    par.CompilerOptions = "/target:library";

                    StreamReader reader = new StreamReader(operatorFile);
                    string content = reader.ReadToEnd();
                    reader.Close();
                    CompilerResults res = iCodeCompiler.CompileAssemblyFromSource(par, new string[] { content });
                    foreach(string s in res.Output)
                    {
                        log = log + s + "\r\n";
                    }

                    Assembly asm = res.CompiledAssembly;
                    if(asm != null)
                    {
                        foreach(Type type in asm.GetExportedTypes())
                        {
                            if(type.IsSubclassOf(typeof(Operator)))
                            {
                                parser.AddOperator(type);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    log += ex.Message + "\r\n";
                }
            }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorsConstantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(8, 27);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(506, 26);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(8, 59);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(506, 288);
            this.txtOutput.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operatorsConstantsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // operatorsConstantsToolStripMenuItem
            // 
            this.operatorsConstantsToolStripMenuItem.Name = "operatorsConstantsToolStripMenuItem";
            this.operatorsConstantsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.operatorsConstantsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.operatorsConstantsToolStripMenuItem.Text = "Operators && Constants";
            this.operatorsConstantsToolStripMenuItem.Click += new System.EventHandler(this.operatorsConstantsToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 353);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "DevCalc.NET (C) 2006 Anders Norman";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(ApplicationInstanceLimiter.Limit())
			{
				return;
			}
			Application.Run(new FormMain());
		}

		private void txtInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
                if(txtInput.Text.ToLower() == "help")
                {
                    operatorsConstantsToolStripMenuItem_Click(this, EventArgs.Empty);
                }
                else if(txtInput.Text.ToLower() == "exit")
                {
                    Application.Exit();
                }
                else
                {
                    log = GetLogEntry(txtInput.Text) + log;
                    txtOutput.Text = log;
                }
				txtInput.SelectAll();
			}
			else if(e.KeyData == Keys.Escape)
			{
				Application.Exit();
			}
		}

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.Text = GetLogEntry(txtInput.Text) + log;
        }

        private string GetLogEntry(string expression)
        {
            string ret = expression + "\r\n = ";
            if(expression.ToLower() == "help")
            {
                ret += "Press ENTER to show help\r\n\r\n";
                return ret;
            }
            else if(expression.ToLower() == "exit")
            {
                ret += "Press ENTER to exit DevCalc.NET\r\n\r\n";
                return ret;
            }
            try
            {
                double dResult = parser.Parse(expression);
                int iResult = (int)dResult;

                ret += string.Format("{0,-16} (0x{1:X})", dResult, iResult);
            }
            catch
            {
                ret += "?";
            }
            ret += "\r\n\r\n";
            return ret;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void operatorsConstantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp frm = new FormHelp();
            frm.HelpText = "Available operators:\r\n";
            frm.HelpText += "  +    - Add" + "\r\n";
            frm.HelpText += "  -    - Subtract" + "\r\n";
            frm.HelpText += "  *    - Multiply" + "\r\n";
            frm.HelpText += "  /    - Divide" + "\r\n";
            frm.HelpText += "  ^    - Power" + "\r\n";
            frm.HelpText += "  sqrt - Square root" + "\r\n";
            frm.HelpText += "  sin  - Sinus" + "\r\n";
            frm.HelpText += "  ln   - Logarithm (base e)" + "\r\n";
            frm.HelpText += "  lb   - Logarithm (base 2)" + "\r\n";
            frm.HelpText += "  log  - Logarithm (base 10)" + "\r\n";
            frm.HelpText += "  tsum - Tverrsum" + "\r\n";
            frm.HelpText += "  kurs - Exchange (parameter is USD/EUR/SEK etc." + "\r\n";
            frm.HelpText += "\r\n";
            frm.HelpText += "Constants:\r\n";
            frm.HelpText += "  pi   - 3.14..." + "\r\n";
            frm.HelpText += "  e    - 2.7..." + "\r\n";
            frm.Show();
            frm.DesktopLocation = new Point(DesktopLocation.X + DesktopBounds.Width, DesktopLocation.Y);
            this.BringToFront();
        }
	}
}
