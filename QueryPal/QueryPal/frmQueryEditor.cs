using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryPal
{
    public partial class frmQueryEditor : Form
    {

        private int preservedCharIndex = 0;
        private int preservedFirstVisibleLine = 0;
        private bool isHighlighting = false;


        public frmQueryEditor()
        {
            InitializeComponent();

            // Attach the TextChanged event handler to the FastColoredTextBox
            txtQueryEditor.TextChanged += txtQueryEditor_TextChanged;

            // Set initial formatting
            HighlightSyntax();
        }

        private void frmQueryEditor_Load(object sender, EventArgs e)
        {

        }

        public void LoadQuery(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Read the content of the file and set it to the RichTextBox
                txtQueryEditor.Text = File.ReadAllText(filePath);
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //save query
            this.Close();
        }


        private void HighlightSyntax()
        {
            // Define regular expressions for SQL keywords and comments
            string keywords = @"\b(SELECT|FROM|WHERE|AND|OR|INSERT INTO|VALUES|UPDATE|SET|DELETE FROM)\b";
            string comments = @"--.*?$|/\*.*?\*/";

            // Apply formatting to SQL keywords
            ApplyRegexFormatting(keywords, Color.Blue, true);

            // Apply formatting to comments
            ApplyRegexFormatting(comments, Color.Green, false);
        }

        private void ApplyRegexFormatting(string pattern, Color color, bool bold)
        {
            // Create a regex style for the specified color and boldness
            var regexStyle = new TextStyle(new SolidBrush(color), null, bold ? FontStyle.Bold : FontStyle.Regular);

            // Define the regular expression
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            // Apply the style to matches
            txtQueryEditor.Range.ClearStyle();
            // Match the regex and apply styles incrementally
            foreach (var range in txtQueryEditor.Range.GetRangesByLines(regex))
            {
                
                range.SetStyle(regexStyle);
            }
        }


        private void txtQueryEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            // Call the method to highlight syntax when the text changes
            HighlightSyntax();
        }
           
    }
}
