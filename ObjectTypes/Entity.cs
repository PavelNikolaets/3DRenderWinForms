
using System.Numerics;
using static WinFormsRender3D.EnumType.EnumStruct;

namespace WinFormsRender3D.ObjectTypes
{
    internal class Entity(Vector3 pos, Vector3 rot, Vector3 scale, bool fill, Color color, List<Face> Faces)
    {
        public Vector3 Position { get; set; } = pos;
        public Vector3 Rotation { get; set; } = rot;
        public Vector3 Scale { get; set; } = scale;
        public bool IsFill { get; set; } = fill;
        public Color Color { get; set; } = color;
        public List<Face> Faces { get; set; } = Faces;
    }
}
