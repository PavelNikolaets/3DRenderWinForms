
using System.Numerics;
using WinFormsRender3D.ObjectTypes;

namespace WinFormsRender3D.RenderLogic
{
    internal class ConversionPointLogic
    {
        public static Vector3 ModificationsMain(Entity obj, Vector3 pointPos)
        {
            //Vector3 point = new(
            //    (pointPos.X + obj.Position.X) * obj.Scale.X, //X
            //    (pointPos.Y + obj.Position.Y) * obj.Scale.Y, //Y
            //    (pointPos.Z + obj.Position.Z) * obj.Scale.Z  //Z
            //    );

            Vector3 point = pointPos;

            Matrix4x4 matrixTranslation = Matrix4x4.CreateTranslation(obj.Position);
            Matrix4x4 matrixScale = Matrix4x4.CreateScale(obj.Scale, obj.Position);

            point = Vector3.Transform(point, matrixTranslation);
            point = Vector3.Transform(point, matrixScale);

            return point;
        }

        public static Vector3 ModificationPointPos(Entity obj,Vector3 pointPos)
        {
            Matrix4x4 matrixPositon = Matrix4x4.CreateTranslation(obj.Position);
            return Vector3.Transform(obj.Position, matrixPositon);
        }

        public static Vector3 ModificationPointScale(Entity obj, Vector3 pointPos)
        {
            //Matrix4x4 matrixScale = Matrix4x4.CreateScale(obj.Scale, pointPos);
            //return Vector3.Transform(pointPos, matrixScale);
            return new(pointPos.X * obj.Scale.X, pointPos.Y * obj.Scale.Y, pointPos.Z * obj.Scale.Z);
        }

        public static Vector3 ModificationPointRotation(Entity obj)
        {
            Matrix4x4 matrixRotation = Matrix4x4.CreateRotationX(obj.Rotation.X, obj.Position) + Matrix4x4.CreateRotationX(obj.Rotation.Y, obj.Position) + Matrix4x4.CreateRotationX(obj.Rotation.Z, obj.Position);
            return Vector3.Transform(obj.Position, matrixRotation);
        }

        public static Vector3 ModificationPointCam(Entity obj, Camera camera, Vector3 point)
        {
            //Matrix4x4.
            //Matrix4x4 matrixCam = Matrix4x4.CreatePerspectiveFieldOfView(camera.FOV, 16f / 9f, 0.1f, 100f);
            //return Vector3.Transform(point,);
            return new();
        }
    }
}