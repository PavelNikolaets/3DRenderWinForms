using System.Numerics;

namespace WinFormsRender3D.ObjectTypes
{
    internal class Face(Vector3 Point1, Vector3 Point2, Vector3 Point3)
    {
        public Vector3[] VertexSet { get; set; } = [Point1, Point2, Point3];
    }
}
