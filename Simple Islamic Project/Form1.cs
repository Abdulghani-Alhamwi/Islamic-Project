using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Islamic_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       private enum _entypes
        {
          سبحان_الله =1,
            الحمدلله = 2,
           الله_أكبر=3,
            لا_إله_إلا_الله=4
        }

        _entypes _Types= _entypes.سبحان_الله;

        short _Counter = 0;
        bool _ChangeColor = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            timer1.Start();
            txtContent.ForeColor = Color.FromArgb(255,250,250,250);

        }

        void _ChangeContentColor()
        {
            if(_ChangeColor)
            switch(_Types)
                { 

                case _entypes.الحمدلله:
                        txtContent.ForeColor = Color.OrangeRed;
                        break;

                case _entypes.الله_أكبر:
                        txtContent.ForeColor = Color.Gold;
                        break;

                    case _entypes.لا_إله_إلا_الله:
                        txtContent.ForeColor = Color.GreenYellow;
                        break;
                }
            _ChangeColor = false;
            }
        void _ContentModifier(string content)
        {
            txtContent.Text = content;
        }

        void _SetNotifyIcon(string MessageBode,string Title)
        {
            notifyIcon1.Text = "Message";
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = MessageBode;
            notifyIcon1.BalloonTipTitle = Title;
            notifyIcon1.ShowBalloonTip(3000);
        }
        void _EndProgram()
        {
            btnStart.Enabled = true;
            timer1.Stop();
            _SetNotifyIcon("في ميزان حسناتكم", "Notification");
              _Types = _entypes.سبحان_الله;
            _Counter = 0;
        }

        void _SetProgramProperties()
        {
            if (_Counter==33 && _Types!=_entypes.لا_إله_إلا_الله)
            {
                _Counter = 0;
                switch (_Types)
                {
                    case _entypes.سبحان_الله:
                        _Types = _entypes.الحمدلله;
                        _ChangeColor = true;
                        break;

                    case _entypes.الحمدلله:
                        _Types = _entypes.الله_أكبر;
                        _ChangeColor = true;
                        break;

                    case _entypes.الله_أكبر:
                        _Types = _entypes.لا_إله_إلا_الله;
                        _ChangeColor = true;
                        break;
                }
            }
            else if (_Counter == 33&&_Types == _entypes.لا_إله_إلا_الله)
            {
                _EndProgram();
            }
        }

        void _GetVisualContent()
        {
            switch( _Types)
            {
                case _entypes.سبحان_الله:
            _ContentModifier(_Counter + " _  سبحان الله");
                    break;

                case _entypes.الحمدلله:
                    _ContentModifier(_Counter + " _  الحمد الله");
                    break;

                case _entypes.الله_أكبر:
                    _ContentModifier(_Counter + " _  الله أكبر");
                    break;

                case _entypes.لا_إله_إلا_الله:
                    _ContentModifier("لا إله إلا الله وحده لا شريك له  له الملك و له الحمد و هو على كل شيء قدير");
                    break;

            }
            _ChangeContentColor();
            _SetProgramProperties();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _Counter++;
            _GetVisualContent();
        }
    }
}
