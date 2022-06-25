using System;

namespace GLMathCSharp
{
    /// <summary>
    /// The glm class contains static functions as exposed in the glm namespace of the 
    /// GLM library. The lowercase naming is to keep the code as consistent as possible
    /// with the real GLM.
    /// </summary>
// ReSharper disable InconsistentNaming
    public static partial class GLM
    {
        public static Vec3 Cross(Vec3 lhs, Vec3 rhs)
        {
            return new Vec3(
                lhs.Y * rhs.Z - rhs.Y * lhs.Z,
                lhs.Z * rhs.X - rhs.Z * lhs.X,
                lhs.X * rhs.Y - rhs.X * lhs.Y);
        }

        public static float Dot(Vec2 x, Vec2 y)
        {
            Vec2 tmp = new Vec2(x * y);
            return tmp.X + tmp.Y;
        }

        public static float Dot(Vec3 x, Vec3 y)
        {
            Vec3 tmp = new Vec3(x * y);
            return tmp.X + tmp.Y + tmp.Z;
        }

        public static float Dot(Vec4 x, Vec4 y)
        {
            Vec4 tmp = new Vec4(x * y);
            return (tmp.X + tmp.Y) + (tmp.Z + tmp.W);
        }

        public static Vec2 Normalize(Vec2 v)
        {
            float sqr = v.X * v.X + v.Y * v.Y;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }

        public static Vec3 Normalize(Vec3 v)
        {
            float sqr = v.X * v.X + v.Y * v.Y + v.Z * v.Z;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }

        public static Vec4 Normalize(Vec4 v)
        {
            float sqr = v.X * v.X + v.Y * v.Y + v.Z * v.Z + v.W * v.W;
            return v * (1.0f / (float)Math.Sqrt(sqr));
        }
    }

// ReSharper restore InconsistentNaming
}
