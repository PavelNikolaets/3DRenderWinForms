
using System.Numerics;

namespace WinFormsRender3D.ObjectTypes
{
    internal class Camera
    {
        public Vector3 Position { get; set; } = new(0, 0, 0);
        //public Vector3 Rotation { get; set; } = new(0, 0, 0);
        public float pitch { get; set; } = 0.0f;
        public float yaw { get; set; } = 0.0f;
        public float FOV { get; set; } = float.DegreesToRadians(75.0f);
    }
}
