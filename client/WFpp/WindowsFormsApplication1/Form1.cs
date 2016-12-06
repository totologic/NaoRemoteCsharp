using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NaoRemote;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Boolean _active;

        private Nao _nao;

        private List<TextBox> _anglesBoxes;

        private List<String> _queueEvt;

        public Form1()
        {
            InitializeComponent();
            

            _anglesBoxes = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8
            , textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17
            , textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26};

            _queueEvt = new List<string>();

            _active = false;
            _nao = new Nao();
            timer1.Interval = 200;
            logOutput.AppendText("Ready\n");

        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            logOutput.AppendText("paint");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logOutput.AppendText("Connect to " + IPinput.Text + " ...\n");
            try
            {
                _nao.Connect(IPinput.Text);
            }
            catch (Exception exc)
            {
                logOutput.AppendText("Connection failed\n");
                return;
            }
            logOutput.AppendText("Connection success\n");
            _active = true;

            _nao.ALMotion.StiffnessInterpolation("Body", 0, 1);

            _nao.SubscribeToEvent("RightBumperPressed", onSensorEvent);
            _nao.SubscribeToEvent("LeftBumperPressed", onSensorEvent);
            _nao.SubscribeToEvent("FrontTactilTouched", onSensorEvent);
            _nao.SubscribeToEvent("MiddleTactilTouched", onSensorEvent);
            _nao.SubscribeToEvent("RearTactilTouched", onSensorEvent);
            
            List<String> b = _nao.ALBehaviorManager.GetInstalledBehaviors();
            foreach ( String s in b )
            {
                listBehaviors.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _active = false;
            _nao.Disconnect();
            logOutput.AppendText("Disconnected.\n");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = listBehaviors.SelectedItems[0].Text;
            logOutput.AppendText( "Run " + s + "\n" );
            _nao.ALBehaviorManager.post.RunBehavior(s);
        }

        private void onSensorEvent(String eventName, NaoEventData data)
        {
            double value = data.Extract<double>();
            _queueEvt.Add( eventName + " " + value );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_active)
            {
                List<double> angles = _nao.ALMotion.GetAngles("Body", false);
                for (int i = 0; i < angles.Count; i++)
                {
                    _anglesBoxes[i].Text = angles[i].ToString();
                }
                Boolean needScroll = false;
                while (_queueEvt.Count > 0)
                {
                    logOutput.AppendText("EVENT -> " + _queueEvt[0] + "\n");
                    _queueEvt.RemoveAt(0);
                    needScroll = true;
                }
                if (needScroll)
                    logOutput.ScrollToCaret();
            }
        }


    }
}
