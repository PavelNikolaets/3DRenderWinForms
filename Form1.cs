
using WinFormsRender3D.RenderLogic;
using WinFormsRender3D.ObjectTypes;
using System.Numerics;
using static WinFormsRender3D.EnumType.EnumStruct;

namespace WinFormsRender3D
{
    public partial class Form1 : Form
    {
        private Render LogicRender = new();
        private Vector3 pos = new(0, 0, 0);

        List<Face> Test = [
            new( new(1,1,1), new(2,1,1), new(1,2,1) ),

            new( new(2,1,1), new(1,2,1), new(2,2,1)),

            new( new(2,1,2), new(2,1,2), new(2,2,1) ),

            new( new(2,1,2), new(2,2,2), new(2,2,1)),

            new( new(2,1,2), new(1,1,2), new(2,2,2) ),

            new( new(1,1,2), new(2,2,2), new(1,2,2)),

            new( new(1,1,2), new(1,1,1), new(1,2,1) ),

            new( new(1,1,2), new(1,2,2), new(1,2,1)),

            new( new(1,2,2), new(1,2,1), new(2,2,2) ),

            new( new(2,2,2), new(2,2,1), new(1,2,1)),

            new( new(2,1,2), new(2,1,1), new(1,1,1) ),

            new( new(1,1,1), new(1,1,2), new(2,1,2) ),];

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = timer1;
            timer.Interval = 10;
            timer.Tick += Update;
            timer.Start();

            LogicRender.CreateEntity(new(pos, new(0,0,0), new(100,100,100), false, Color.Black, Test));
        }

        private void Update(object? sender, EventArgs e)
        {
            Invalidate();
        }

        private void RenderForm(object sender, PaintEventArgs e)
        {
            using (Graphics render = e.Graphics)
            {
                LogicRender.RenderMain(render);
            }
        }

        private void KeyDownCheck(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posY, -0.05f);
                    break;
                case Keys.S:
                    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posY, 0.05f);
                    break;
                case Keys.D:
                    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posX, 0.05f);
                    break;
                case Keys.A:
                    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posX, -0.05f);
                    break;
            }
        }
    }
}

