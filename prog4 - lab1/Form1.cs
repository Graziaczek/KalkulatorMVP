using System.Drawing.Drawing2D;

namespace prog4___lab1
{
    public enum Opr
    {
        None,
        Add,
        Sub,
        Div,
        Mul
    }
    public partial class Form1 : Form
    {
        private string fValue = "0", sValue = "0";
        private Opr currOpr = Opr.None;
        private bool isResult = false;
        private bool error = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private double solving(double x1, double x2)
        {
            var solve = 0d;
            switch (currOpr)
            {
                case Opr.Add:
                    solve = x1 + x2;
                    label2.Text += sValue;
                    break;
                case Opr.Sub:
                    solve = x1 - x2;
                    label2.Text += sValue;
                    break;
                case Opr.Mul:
                    solve = x1 * x2;
                    label2.Text += sValue;
                    break;
                case Opr.Div:
                    if (x2 == 0)
                    {
                        solve = 0;
                        error = true;
                    }
                    else
                    {
                        solve = x1 / x2;
                    }
                    label2.Text += sValue;
                    break;
                default:
                    solve = x1;
                    break;
            }
            fValue = solve.ToString();
            sValue = "0";
            currOpr = Opr.None;
            return solve;
        }
        private void buttonNbr_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0" || label1.Text == "Error")
            {
                label1.Text = string.Empty;
            }
            if (isResult)
            {
                if (currOpr == Opr.None)
                {
                    label2.Text = string.Empty;
                    label1.Text = string.Empty;
                    fValue = "0";
                    isResult = false;
                }
            }
            
            var clickedValue = (sender as Button).Text;
            if (currOpr != Opr.None)
            {
                if(sValue == "0")
                    sValue = clickedValue;
                else
                    sValue += clickedValue;

            }
            else
            {
                if (fValue == "0")
                    fValue = clickedValue;
                else
                    fValue += clickedValue;
            }
            label1.Text += clickedValue;
        }

        private void buttonSol_Click(object sender, EventArgs e)
        {
            if (sValue[sValue.Length - 1].Equals(','))
            {
                label1.Text += "0";
                sValue += "0";
            }
            if (currOpr == Opr.None)
            {
                if (fValue[fValue.Length - 1].Equals(','))
                {
                    label1.Text += "0";
                    fValue += "0";
                }
                return;
            }
            var fNumber = double.Parse(fValue);
            var sNumber = double.Parse(sValue);
            var x = solving(fNumber, sNumber).ToString();
            if (error)
                label1.Text = "Error";
            else
                label1.Text = x;
            isResult = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(label1.Text == "Error")
            {
                return;
            }
            if (isResult)
            {
                if (currOpr == Opr.None)
                {
                    label2.Text = string.Empty;
                    label1.Text = "0";
                    fValue = "0";
                    isResult = false;
                }
            }
            if (currOpr == Opr.None)
            {
                if (!fValue.Contains(","))
                {
                    fValue += ",";
                    label1.Text += ",";

                }
            }
            else
            {
                if (!sValue.Contains(","))
                {
                    sValue += ",";
                    label1.Text += ",";

                }
            }
        }

        private void buttonClr_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = string.Empty;
            fValue = "0";
            sValue = "0";
            currOpr=Opr.None;
        }

        private void buttonBck_Click(object sender, EventArgs e)
        {
            if(label1.Text == "Error")
            {
                return;
            }
            if (isResult)
            {
                if (currOpr == Opr.None)
                {
                    label2.Text = string.Empty;
                    label1.Text = "0";
                    fValue = "0";
                    isResult = false;
                }
            }
            if (label1.Text.Length > 0)
            {
                label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                if (currOpr == Opr.None)
                    fValue = fValue.Remove(fValue.Length - 1);
                else
                    sValue = sValue.Remove(sValue.Length - 1);
            }
            if (label1.Text.Length == 0)
            {
                label1.Text = "0";
                if (currOpr == Opr.None)
                    fValue = "0";
                else
                    sValue = "0";
            }
        }

        private void buttonpm_Click(object sender, EventArgs e)
        {
            if (currOpr == Opr.None)
            {
                if (fValue != "0")
                {
                    var pom = double.Parse(fValue);
                    pom = -pom;
                    fValue = pom.ToString();
                    label1.Text = fValue;
                }
            }
            else
            {
                if (sValue != "0")
                {
                    var pom = double.Parse(sValue);
                    pom = -pom;
                    sValue = pom.ToString();
                    label1.Text = sValue;
                }
            }
        }
        private void buttonOpr_Click(object sender, EventArgs e)
        {
            if (label1.Text[label1.Text.Length-1].Equals(','))
            {
                label1.Text += "0";
                fValue += "0";
            }
            var operation = (sender as Button).Text;
            if (currOpr != Opr.None)
            {
                label1.Text = solving(double.Parse(fValue), double.Parse(sValue)).ToString();
                currOpr = Opr.None;
                label2.Text = string.Empty;
            }
            if (isResult)
                label2.Text = string.Empty;

            label2.Text += fValue;
            label2.Text += operation;
            label1.Text = "0";
            currOpr = operation switch
            {
                "+" => Opr.Add,
                "-" => Opr.Sub,
                "*" => Opr.Mul,
                "/" => Opr.Div,
                _ => Opr.None,
            };
        }
    }
}