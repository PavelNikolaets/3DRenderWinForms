
using System.Drawing;
using System.Numerics;
using WinFormsRender3D;
using WinFormsRender3D.ObjectTypes;
using static WinFormsRender3D.EnumType.EnumStruct;

namespace WinFormsRender3D.RenderLogic
{
    internal class Render
    {
        public List<Entity> GlobalEntityStorage = [];
        public Camera UserCam = new();

        public Size WindowSize;

        public void RenderMain(Graphics graphics)
        {
            graphics.Clear(Color.White);
            foreach (Entity entity in GlobalEntityStorage)
            {
                foreach (Face face in entity.Faces)
                {
                    var convertedFace = ConvertFace3Dto2D(entity, face);
                    if (entity.IsFill)
                    {
                        graphics.FillPolygon(Brushes.Black, convertedFace);
                    }
                    else
                    {
                        graphics.DrawPolygon(Pens.Black, convertedFace);
                    }

                }
            }
        }

        public PointF[] ConvertFace3Dto2D(Entity obj, Face objFace)
        {
            List<PointF> convertedFacePoints = [];

            foreach (Vector3 point in objFace.VertexSet)
            {
                Vector3 convertedPoint = ConversionPointLogic.ModificationsMain(obj, point);
                
                convertedFacePoints.Add(
                    new(
                        (convertedPoint.X - UserCam.Position.X) / ((point.Z - UserCam.Position.Z) / (UserCam.FOV * MathF.PI)) + (WindowSize.Width / 2),
                        (convertedPoint.Y - UserCam.Position.Y) / ((point.Z - UserCam.Position.Z) / (UserCam.FOV * MathF.PI)) + (WindowSize.Height / 2))
                    );
            }

            return convertedFacePoints.ToArray();
        }

        public void CreateEntity(Entity obj)
        {
            GlobalEntityStorage.Add(obj);
        }

        public void ChangingParameters(parametrsEntity type, posVector pVector, float value)
        {
            //var obj = GlobalEntityStorage[0];
            //var objPos = obj.Position;

            //switch (type)
            //{
            //    case parametrsEntity.position:

            //        switch(pVector)
            //        {
            //            case posVector.posX:
            //                objPos.X += value;
            //                obj.Position = objPos;
            //                GlobalEntityStorage[0] = obj;
            //                break;

            //            case posVector.posY:
            //                objPos.Y += value;
            //                obj.Position = objPos;
            //                GlobalEntityStorage[0] = obj;
            //                break;
            //        }
                    
            //        break;
            //}
        }
    }
}
