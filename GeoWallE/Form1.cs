using Compiling;
using Syncfusion.Windows.Forms.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compiling.Parsing;
using Compiling.AST;


namespace GeoWallE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            editcontrol = GetEditControl();
            editcontrol.Dock = DockStyle.Fill;
            codePanel.Controls.Add(editcontrol);

            canvas1.Clear(Color.Gray);
            canvas1.SetColor(Color.Black);
        }

        EditControl editcontrol;

        private EditControl GetEditControl()
        {
            var sceneCodeTextBox = new EditControl();
            sceneCodeTextBox.BackColor = Color.Black;
            sceneCodeTextBox.ForeColor = Color.White;
            sceneCodeTextBox.AcceptsReturn = true;
            sceneCodeTextBox.AcceptsTab = true;
            sceneCodeTextBox.AllowDrop = true;
            sceneCodeTextBox.Font = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            sceneCodeTextBox.Location = new System.Drawing.Point(8, 0);
            sceneCodeTextBox.Multiline = true;
            sceneCodeTextBox.Name = "tbCode";
            sceneCodeTextBox.Size = new System.Drawing.Size(568, 352);
            sceneCodeTextBox.TabIndex = 0;
            sceneCodeTextBox.Text = "";
            sceneCodeTextBox.WordWrap = false;

            sceneCodeTextBox.StatusBarVisible = false;
            sceneCodeTextBox.LineNumberMarginVisible = true;
            sceneCodeTextBox.IndicatorMarginVisible = false;
            sceneCodeTextBox.OutliningEnabled = true;
            sceneCodeTextBox.BraceMatchingEnabled = true;
            sceneCodeTextBox.WhiteSpaceVisible = false;
            sceneCodeTextBox.KeepTabs = false;
            sceneCodeTextBox.ContextPromptEnabled = false;
            sceneCodeTextBox.ContextChoiceEnabled = false;
            sceneCodeTextBox.SyntaxColoringEnabled = true;
            sceneCodeTextBox.GridLinesVisible = false;
            sceneCodeTextBox.IndentType = EditIndentType.Block;
            sceneCodeTextBox.ShowSplitterButton = false;

            sceneCodeTextBox.AutomaticOutliningEnabled = true;

            sceneCodeTextBox.StartAutomaticOutlining();

            sceneCodeTextBox.AddColorGroup("keywords", System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.Black, true, false, EditColorGroupType.RegularText);
            //string[] keywords = "if,then,else,undefined,let,in,intersect,and,or,not,draw,include,color,restore,clear".Split(',');
            foreach (string k in Compiling.Lexical.Keywords)
                sceneCodeTextBox.AddKeyword(k, "keywords");

            sceneCodeTextBox.AddColorGroup("strings", System.Drawing.Color.Khaki, System.Drawing.Color.Black, true, false, EditColorGroupType.RegularText);
            sceneCodeTextBox.AddTag("\"", "\"", "\\", false, "strings");

            sceneCodeTextBox.AddColorGroup("comments", System.Drawing.Color.Green, System.Drawing.Color.Black, true, false, EditColorGroupType.RegularText);
            sceneCodeTextBox.AddTag("/*", "*/", "", true, "comments");
            sceneCodeTextBox.AddTag("//", "", "", false, "comments");

            sceneCodeTextBox.Dock = DockStyle.Fill;
            sceneCodeTextBox.LineNumberBackColor = Color.Black;
            sceneCodeTextBox.LineNumberForeColor = Color.Blue;
            Refresh();
            return sceneCodeTextBox;
        }

        private void SaveAll()
        {
            editcontrol.Save();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();

            if (!File.Exists(editcontrol.CurrentFile))
                return;

            var code = File.ReadAllText(editcontrol.CurrentFile);

            List<CompilingError> errors = new List<CompilingError> ();
            var tokens = Compiling.Lexical.GetTokens(editcontrol.CurrentFile, code, errors);


            //Borrar
            canvas1.Clear(Color.LightBlue);
            var parser = new Parser();
            var program = parser.ParseProgram(tokens,errors);
            var memory = new ExecutionScope(new CanvasDrawer(canvas1));
            var context = new SemanticScope();
            var drawer = new CanvasDrawer(canvas1);
            if(errors.Count==0)
                program.CheckSemantics(context, errors);
            if (errors.Count==0)
                program.Run(memory,errors);
            Refresh();
            //----- 
          
            if (errors.Any())
            {
                output.ForeColor = Color.Red;
                string errorList = "Error!\n";
                foreach (var er in errors)
                    errorList += string.Format("{0}: {1} at {2} line {3}\n", er.Code, er.Argument, Path.GetFileName(er.Location.File), er.Location.Line);
                output.Text = errorList;
                
            }
            else
            {
                output.ForeColor = Color.LightBlue;
                string o = "Done!\n";
                foreach (var token in tokens)
                    o += token.ToString() + "\n";
                output.Text = o;
            }
        }
    }
}
