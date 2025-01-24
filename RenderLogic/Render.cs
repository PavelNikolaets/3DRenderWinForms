
using System.Numerics;
using WinFormsRender3D.ObjectTypes;
using WinFormsRender3D.RenderLogic;
using static WinFormsRender3D.EnumType.EnumStruct;

namespace WinFormsRender3D.RenderLogic
{
    internal class Render
    {
        public List<Entity> GlobalEntityStorage = [];
        public Camera UserCam = new();

        public void RenderMain(Graphics graphics)
        {
            foreach (Entity entity in GlobalEntityStorage)
            {
                foreach (Face face in entity.Faces)
                {
                    graphics.DrawPolygon(Pens.Black, ConvertFace3Dto2D(entity, face));
                }
            }
        }

        public PointF[] ConvertFace3Dto2D(Entity obj, Face objFace)
        {
            
            List<PointF> convertedFacePoints = [];

            foreach (Vector3 point in objFace.VertexSet)
            {
                Vector3 convertedPoint = ConversionPointLogic.ModificationPointPos(obj, UserCam, point);
                convertedFacePoints.Add(new());//не доделано
            }

            return convertedFacePoints.ToArray();
        }

        public void CreateEntity(Entity obj)
        {
            GlobalEntityStorage.Add(obj);
        }

        public void ChangingParameters(parametrsEntity type, posVector pVector, float value)
        {
            var obj = GlobalEntityStorage[0];
            var objPos = obj.Position;

            switch (type)
            {
                case parametrsEntity.position:

                    switch(pVector)
                    {
                        case posVector.posX:
                            objPos.X += value;
                            obj.Position = objPos;
                            GlobalEntityStorage[0] = obj;
                            break;

                        case posVector.posY:
                            objPos.Y += value;
                            obj.Position = objPos;
                            GlobalEntityStorage[0] = obj;
                            break;
                    }
                    
                    break;
            }
        }
    }
}
