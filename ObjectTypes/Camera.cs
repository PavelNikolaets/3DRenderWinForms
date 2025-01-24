
using System.Numerics;

namespace WinFormsRender3D.ObjectTypes
{
    internal class Camera
    {
        public Vector3 Position { get; set; } = new(0, 0, 0);
        public Vector3 Rotation { get; set; } = new(0, 0, 0);
        public float FOV { get; set; } = 1.309f;
    }
}
