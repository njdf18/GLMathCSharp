namespace GLMNet_CSNC
{
    // ReSharper disable InconsistentNaming
    public static partial class GLM
    {
        public static Mat2 Inverse(Mat2 m)
        {

            float oneOverDeterminant = (1f) / (
                +m[0][0] * m[1][1]
                - m[1][0] * m[0][1]);

            Mat2 inverse = new Mat2(
                +m[1][1] * oneOverDeterminant,
                -m[0][1] * oneOverDeterminant,
                -m[1][0] * oneOverDeterminant,
                +m[0][0] * oneOverDeterminant);

            return inverse;
        }
        
        public static Mat3 Inverse(Mat3 m)
        {
            float oneOverDeterminant = (1f) / (
                +m[0][0] * (m[1][1] * m[2][2] - m[2][1] * m[1][2])
                - m[1][0] * (m[0][1] * m[2][2] - m[2][1] * m[0][2])
                + m[2][0] * (m[0][1] * m[1][2] - m[1][1] * m[0][2]));

            Mat3 inverse = new Mat3(0);
            inverse[0, 0] = +(m[1][1] * m[2][2] - m[2][1] * m[1][2]) * oneOverDeterminant;
            inverse[1, 0] = -(m[1][0] * m[2][2] - m[2][0] * m[1][2]) * oneOverDeterminant;
            inverse[2, 0] = +(m[1][0] * m[2][1] - m[2][0] * m[1][1]) * oneOverDeterminant;
            inverse[0, 1] = -(m[0][1] * m[2][2] - m[2][1] * m[0][2]) * oneOverDeterminant;
            inverse[1, 1] = +(m[0][0] * m[2][2] - m[2][0] * m[0][2]) * oneOverDeterminant;
            inverse[2, 1] = -(m[0][0] * m[2][1] - m[2][0] * m[0][1]) * oneOverDeterminant;
            inverse[0, 2] = +(m[0][1] * m[1][2] - m[1][1] * m[0][2]) * oneOverDeterminant;
            inverse[1, 2] = -(m[0][0] * m[1][2] - m[1][0] * m[0][2]) * oneOverDeterminant;
            inverse[2, 2] = +(m[0][0] * m[1][1] - m[1][0] * m[0][1]) * oneOverDeterminant;

            return inverse;

        }
        
        public static Mat4 Inverse(Mat4 m)
        {
            float coef00 = m[2][2] * m[3][3] - m[3][2] * m[2][3];
            float coef02 = m[1][2] * m[3][3] - m[3][2] * m[1][3];
            float coef03 = m[1][2] * m[2][3] - m[2][2] * m[1][3];

            float coef04 = m[2][1] * m[3][3] - m[3][1] * m[2][3];
            float coef06 = m[1][1] * m[3][3] - m[3][1] * m[1][3];
            float coef07 = m[1][1] * m[2][3] - m[2][1] * m[1][3];

            float coef08 = m[2][1] * m[3][2] - m[3][1] * m[2][2];
            float coef10 = m[1][1] * m[3][2] - m[3][1] * m[1][2];
            float coef11 = m[1][1] * m[2][2] - m[2][1] * m[1][2];

            float coef12 = m[2][0] * m[3][3] - m[3][0] * m[2][3];
            float coef14 = m[1][0] * m[3][3] - m[3][0] * m[1][3];
            float coef15 = m[1][0] * m[2][3] - m[2][0] * m[1][3];

            float coef16 = m[2][0] * m[3][2] - m[3][0] * m[2][2];
            float coef18 = m[1][0] * m[3][2] - m[3][0] * m[1][2];
            float coef19 = m[1][0] * m[2][2] - m[2][0] * m[1][2];

            float coef20 = m[2][0] * m[3][1] - m[3][0] * m[2][1];
            float coef22 = m[1][0] * m[3][1] - m[3][0] * m[1][1];
            float coef23 = m[1][0] * m[2][1] - m[2][0] * m[1][1];

            Vec4 fac0 = new Vec4(coef00, coef00, coef02, coef03);
            Vec4 fac1 = new Vec4(coef04, coef04, coef06, coef07);
            Vec4 fac2 = new Vec4(coef08, coef08, coef10, coef11);
            Vec4 fac3 = new Vec4(coef12, coef12, coef14, coef15);
            Vec4 fac4 = new Vec4(coef16, coef16, coef18, coef19);
            Vec4 fac5 = new Vec4(coef20, coef20, coef22, coef23);

            Vec4 vec0 = new Vec4(m[1][0], m[0][0], m[0][0], m[0][0]);
            Vec4 vec1 = new Vec4(m[1][1], m[0][1], m[0][1], m[0][1]);
            Vec4 vec2 = new Vec4(m[1][2], m[0][2], m[0][2], m[0][2]);
            Vec4 vec3 = new Vec4(m[1][3], m[0][3], m[0][3], m[0][3]);

            Vec4 inv0 = new Vec4(vec1 * fac0 - vec2 * fac1 + vec3 * fac2);
            Vec4 inv1 = new Vec4(vec0 * fac0 - vec2 * fac3 + vec3 * fac4);
            Vec4 inv2 = new Vec4(vec0 * fac1 - vec1 * fac3 + vec3 * fac5);
            Vec4 inv3 = new Vec4(vec0 * fac2 - vec1 * fac4 + vec2 * fac5);

            Vec4 signA = new Vec4(+1, -1, +1, -1);
            Vec4 signB = new Vec4(-1, +1, -1, +1);
            Mat4 inverse = new Mat4(inv0 * signA, inv1 * signB, inv2 * signA, inv3 * signB);

            Vec4 row0 = new Vec4(inverse[0][0], inverse[1][0], inverse[2][0], inverse[3][0]);

            Vec4 dot0 = new Vec4(m[0] * row0);
            float dot1 = (dot0.X + dot0.Y) + (dot0.Z + dot0.W);

            float oneOverDeterminant = (1f) / dot1;

            return inverse * oneOverDeterminant;
        }
    }
    // ReSharper restore InconsistentNaming
}
