using System;

namespace GLMathCSharp
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public struct Vec2
    {
        public float X;
        public float Y;

        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vec2(float s)
        {
            X = Y = s;
        }

        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vec2(Vec2 v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }

        public Vec2(Vec3 v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }

        public static Vec2 operator +(Vec2 lhs, Vec2 rhs)
        {
            return new Vec2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vec2 operator +(Vec2 lhs, float rhs)
        {
            return new Vec2(lhs.X + rhs, lhs.Y + rhs);
        }

        public static Vec2 operator -(Vec2 lhs, Vec2 rhs)
        {
            return new Vec2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vec2 operator -(Vec2 lhs, float rhs)
        {
            return new Vec2(lhs.X - rhs, lhs.Y - rhs);
        }

        public static Vec2 operator *(Vec2 self, float s)
        {
            return new Vec2(self.X * s, self.Y * s);
        }

        public static Vec2 operator *(float lhs, Vec2 rhs)
        {
            return new Vec2(rhs.X * lhs, rhs.Y * lhs);
        }

        public static Vec2 operator *(Vec2 lhs, Vec2 rhs)
        {
            return new Vec2(rhs.X * lhs.X, rhs.Y * lhs.Y);
        }

        public static Vec2 operator /(Vec2 lhs, float rhs)
        {
            return new Vec2(lhs.X / rhs, lhs.Y / rhs);
        }

        public float[] ToArray()
        {
            return new[] { X, Y };
        }

        #region Comparision

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// The Difference is detected by the different values
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vec2))
            {
                var vec = (Vec2)obj;
                if (this.X == vec.X && this.Y == vec.Y)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Vec2 v1, Vec2 v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Vec2 v1, Vec2 v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        #endregion

        #region ToString support

        public override string ToString()
        {
            return String.Format("[{0}, {1}]", X, Y);
        }

        #endregion
    }

}