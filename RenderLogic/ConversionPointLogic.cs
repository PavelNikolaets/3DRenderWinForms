
using System.Numerics;
using WinFormsRender3D.ObjectTypes;

namespace WinFormsRender3D.RenderLogic
{
    internal class ConversionPointLogic
    {
        public static Vector3 Main()
        {
            //главная функция хаб в которой все должно скапливаться вместе и отдаваться DrawPolygon
        }

        public static Vector3 ModificationPointPos(Entity obj,Vector3 pointPos)
        {
            Matrix4x4 matrixPositon = Matrix4x4.CreateTranslation(obj.Position);
            return Vector3.Transform(ModificationPointScale(obj, pointPos), matrixPositon);
        }

        public static Vector3 ModificationPointScale(Entity obj, Vector3 pointPos)
        {
            Matrix4x4 matrixScale = Matrix4x4.CreateScale(obj.Scale);
            return Vector3.Transform(pointPos, matrixScale);
        }

        public static Vector3 ModificationPointRotation(Entity obj)
        {
            Matrix4x4 matrixRotation = Matrix4x4.CreateRotationX(obj.Rotation.X, obj.Position) + Matrix4x4.CreateRotationX(obj.Rotation.Y, obj.Position) + Matrix4x4.CreateRotationX(obj.Rotation.Z, obj.Position);
            return Vector3.Transform(obj.Position, matrixRotation);
        }

        public static Vector3 ModificationPointCam(Entity obj, Camera camera, Vector3 point)
        {
            Matrix4x4 matrixCam = Matrix4x4.CreatePerspectiveFieldOfView(camera.FOV, 16f / 9f, 0.1f, 100f);
            //не доделано
        }
    }
}