
using WinFormsRender3D.RenderLogic;
using WinFormsRender3D.ObjectTypes;
using System.Numerics;
using static WinFormsRender3D.EnumType.EnumStruct;

namespace WinFormsRender3D
{
    public partial class Form1 : Form
    {
        private Render LogicRender = new();

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

        //List<Face> Test = [
        //        new(new(0.1f, 0.1f, 0.1f), new(0.2f, 0.1f, 0.1f), new(0.1f, 0.2f, 0.1f)),

        //        new(new(0.2f, 0.1f, 0.1f), new(0.1f, 0.2f, 0.1f), new(0.2f, 0.2f, 0.1f)),

        //        new(new(0.2f, 0.1f, 0.2f), new(0.2f, 0.1f, 0.2f), new(0.2f, 0.2f, 0.1f)),

        //        new(new(0.2f, 0.1f, 0.2f), new(0.2f, 0.2f, 0.2f), new(0.2f, 0.2f, 0.1f)),

        //        new(new(0.2f, 0.1f, 0.2f), new(0.1f, 0.1f, 0.2f), new(0.2f, 0.2f, 0.2f)),

        //        new(new(0.1f, 0.1f, 0.2f), new(0.2f, 0.2f, 0.2f), new(0.1f, 0.2f, 0.2f)),

        //        new(new(0.1f, 0.1f, 0.2f), new(0.1f, 0.1f, 0.1f), new(0.1f, 0.2f, 0.1f)),

        //        new(new(0.1f, 0.1f, 0.2f), new(0.1f, 0.2f, 0.2f), new(0.1f, 0.2f, 0.1f)),

        //        new(new(0.1f, 0.2f, 0.2f), new(0.1f, 0.2f, 0.1f), new(0.2f, 0.2f, 0.2f)),

        //        new(new(0.2f, 0.2f, 0.2f), new(0.2f, 0.2f, 0.1f), new(0.1f, 0.2f, 0.1f)),

        //        new(new(0.2f, 0.1f, 0.2f), new(0.2f, 0.1f, 0.1f), new(0.1f, 0.1f, 0.1f)),

        //        new(new(0.1f, 0.1f, 0.1f), new(0.1f, 0.1f, 0.2f), new(0.2f, 0.1f, 0.2f))
        //    ];

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = timer1;
            timer.Interval = 10;
            timer.Tick += Update;
            timer.Start();

            LogicRender.WindowSize = this.Size;

            LogicRender.CreateEntity(new(new(0, 0, 0), new(0, 0, 0), new(100, 10, 1), false, Color.Black, Test));
            LogicRender.CreateEntity(new(new(0, 100, 0), new(0, 0, 0), new(100, 100, 200), true, Color.Black, Test));
        }

        private void Update(object sender, EventArgs e)
        {
            LogicRender.WindowSize = this.Size;
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
            var CamPos = LogicRender.UserCam.Position;
            var CamYaw = LogicRender.UserCam.yaw;
            var CamPitch = LogicRender.UserCam.pitch;

            switch (e.KeyCode)
            {
                //case Keys.W:
                //    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posY, -1.25f);
                //    break;
                //case Keys.S:
                //    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posY, 1.25f);
                //    break;
                //case Keys.D:
                //    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posX, 1.25f);
                //    break;
                //case Keys.A:
                //    LogicRender.ChangingParameters(parametrsEntity.position, posVector.posX, -1.25f);
                //    break;
                case Keys.W:
                    CamPos.Z -= 0.25f;
                    break;

                case Keys.S:
                    CamPos.Z += 0.25f;
                    break;

                case Keys.D:
                    CamPos.X -= 1.25f;
                    break;

                case Keys.A:
                    CamPos.X += 1.25f;
                    break;

                case Keys.Space:
                    CamPos.Y += 1.25f;
                    break;

                case Keys.ShiftKey:
                    CamPos.Y -= 1.25f;
                    break;

                case Keys.Q:
                    CamYaw += 1.25f;
                    break;
                case Keys.E:
                    CamYaw -= 1.25f;
                    break;

            }
            LogicRender.UserCam.Position = CamPos;
        }
    }
}

