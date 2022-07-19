using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Windows.Forms;

namespace OpenTK_STL_WinForms
{
    public partial class FormOpenTK : Form
    {
        private Timer _timer = null!;

        private bool _firstMove = true;
        private bool _firstMoveRight = true;

        private Vector2 _lastPos;
        private Vector2 _lastPosRight;

        GLObject stlObject = new GLObject();
        GLObjectCoordinatSystem coordObject = new GLObjectCoordinatSystem();

        public FormOpenTK()
        {
            InitializeComponent();
        }

        private void miOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogSTL.ShowDialog() == DialogResult.OK)
            {
                statusBarProgress.Value = 0;
                stlObject = new GLObject(openFileDialogSTL.FileName);
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из программы ?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Подгорнов Д.А. (2022)\nD.Podgornov@mail.ru", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            glControl.Resize += glControl_Resize;
            glControl.Paint += glControl_Paint;

            _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                Render();
            };
            _timer.Interval = 50;
            _timer.Start();

            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);
            GLLoad();
        }
        private void glControl_Resize(object? sender, EventArgs e)
        {
            glControl.MakeCurrent();
            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);
        }

        private void GLLoad()
        {
            glControl.MakeCurrent();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            if (stlObject.isLoadFigure)
            {
                stlObject.LoadObjectGL();
            }

            coordObject.LoadObjectGL();
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            
            if (stlObject.isLoadFigure && !stlObject.isLoadFigureInBuffer)
            {
                GLLoad();
                stlObject.isLoadFigureInBuffer = true;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            coordObject.RenderObjectGL();

            if (stlObject.isLoadFigure)
            {
                stlObject.angleX = coordObject.angleX;
                stlObject.angleZ = coordObject.angleZ;
                stlObject.RenderObjectGL();

                statusBarProgress.Value = (int)Math.Round(stlObject.processLoadingFile * 100.0f);
            }

            glControl.SwapBuffers();
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_firstMove)
                {
                    _lastPos = new Vector2(e.X, e.Y);
                    _firstMove = false;
                }
                else
                {
                    var deltaX = e.X - _lastPos.X;
                    var deltaY = e.Y - _lastPos.Y;
                    _lastPos = new Vector2(e.X, e.Y);

                    coordObject.angleZ += deltaX * 0.007f;
                    coordObject.angleX += -deltaY * 0.007f;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (_firstMoveRight)
                {
                    _lastPosRight = new Vector2(e.X, e.Y);
                    _firstMoveRight = false;
                }
                else
                {
                    var deltaX = e.X - _lastPosRight.X;
                    var deltaY = e.Y - _lastPosRight.Y;
                    _lastPosRight = new Vector2(e.X, e.Y);

                    stlObject.transX += deltaX * 0.007f;
                    stlObject.transY -= deltaY * 0.007f;
                }

            }
        }

        private void glControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _firstMove = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                _firstMoveRight = true;
            }

        }
    }
}
