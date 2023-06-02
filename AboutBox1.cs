using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VulcanShotSuccess
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            
            this.labelProductName.Text = "Software Name: Vulcan  Statistics Retriever";
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            
            this.richTextBox1.AppendText(@"This software is designed to calculate statistics for an experimental period by searching the Excel document shot records, which can typically be found at:

     'M:\Vulcan operations\.Shot Data Record'.

The software returns the total number of shots fired into an area, the number of shots determined to be failures, the number of inconclusive shots (due to insufficient information) and the percentage of successful shots for an experiment. The programme also returns information on why a shot has failed. This is saved in a text file in a directory of your choosing.");
            this.richTextBox1.SelectionFont = new Font(this.richTextBox1.Font, FontStyle.Bold);
            this.richTextBox1.AppendText("\n\nHow to use:\n");
            this.richTextBox1.SelectionFont = new Font(this.richTextBox1.Font, FontStyle.Regular);
            this.richTextBox1.AppendText(@"
1) Fill in all the fields in the main window

2) Press the 'Go' button and wait while the programme executes

3) Retrieve your data from the location you chose to save it

4) You can re-run the programme by pressing the 'Start Over' button.

If you find any bugs which require attention, please email them to: jack.morse@stfc.ac.uk. Thank you");


        }

        #region Assembly Attribute Accessors

        static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelProductName_Click(object sender, EventArgs e)
        {

        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
