using System.Windows.Forms;
using System.Drawing;
using System;

namespace GUI
{
    public class GussesForm : Form
    {
        public const int k_Padding = 10;
        public const int k_Width = 300;

        private byte m_NumberOfGusses;
        private Button m_Inc_Button;
        private Button m_Start_Button;

        public GussesForm()
        {
            m_NumberOfGusses = 4;

            Text = "Bool Pgia";
            Size = new Size(k_Width, k_Width / 2);
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            m_Inc_Button = new Button();
            m_Inc_Button.Location = new Point(k_Padding, k_Padding);
            m_Inc_Button.Text = string.Format("Number of chances: {0}", m_NumberOfGusses);
            m_Inc_Button.Width = ClientSize.Width - 2 * k_Padding;
            m_Inc_Button.Click += m_Inc_Button_Click;

            m_Start_Button = new Button();
            m_Start_Button.Location = new Point(ClientSize.Width - k_Padding - m_Start_Button.ClientSize.Width, ClientSize.Height - k_Padding - m_Start_Button.ClientSize.Height);
            m_Start_Button.Text = "Start";
            m_Start_Button.Click += m_Start_Button_Click;

            Controls.Add(m_Start_Button);
            Controls.Add(m_Inc_Button);
        }

        public void m_Inc_Button_Click(object sender, EventArgs e)
        {
            m_NumberOfGusses++;
            if (m_NumberOfGusses == 11)
            {
                m_NumberOfGusses = 4;
            }

            (sender as Button).Text = string.Format("Number of chances: {0}", m_NumberOfGusses);
        }

        public void m_Start_Button_Click(object sender, EventArgs e)
        {
            Visible = false;
            (new Board(m_NumberOfGusses)).ShowDialog();
        }
    }
}
