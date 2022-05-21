using System;
using System.Linq;

namespace GLMNet_CSNC
{
    /// <summary>
    /// Represents a 3x3 matrix.
    /// </summary>
    public struct Mat3
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat3"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public Mat3(float scale)
        {
            _cols = new[]
            {
                new Vec3(scale, 0.0f, 0.0f),
                new Vec3(0.0f, scale, 0.0f),
                new Vec3(0.0f, 0.0f, scale)
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mat3"/> struct.
        /// The matrix is initialised with the <paramref name="_cols"/>.
        /// </summary>
        /// <param name="_cols">The colums of the matrix.</param>
        public Mat3(Vec3[] _cols)
        {
            this._cols = new[]
            {
                _cols[0],
                _cols[1],
                _cols[2]
            };
        }

        public Mat3(Vec3 a, Vec3 b, Vec3 c)
        {
            this._cols = new[]
            {
                a, b, c
            };
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static Mat3 Identity()
        {
            return new Mat3
            {
                _cols = new[]
                {
                    new Vec3(1,0,0),
                    new Vec3(0,1,0),
                    new Vec3(0,0,1)
                }
            };
        }

        #endregion

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="Vec3"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Vec3"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public Vec3 this[int column]
        {
            get { return _cols[column]; }
            set { _cols[column] = value; }
        }

        /// <summary>
        /// Gets or sets the element at <paramref name="column"/> and <paramref name="row"/>.
        /// </summary>
        /// <value>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <param name="row">The row index.</param>
        /// <returns>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </returns>
        public float this[int column, int row]
        {
            get { return _cols[column][row]; }
            set { _cols[column][row] = value; }
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Returns the matrix as a flat array of elements, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            return _cols.SelectMany(v => v.ToArray()).ToArray();
        }

        /// <summary>
        /// Returns the <see cref="Mat3"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="Mat3"/> portion of this matrix.</returns>
        public Mat2 ToMat2()
        {
            return new Mat2(new[] {
      new Vec2(_cols[0][0], _cols[0][1]),
      new Vec2(_cols[1][0], _cols[1][1])});
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static Vec3 operator *(Mat3 lhs, Vec3 rhs)
        {
            return new Vec3(
                lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1] + lhs[2, 0] * rhs[2],
                lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1] + lhs[2, 1] * rhs[2],
                lhs[0, 2] * rhs[0] + lhs[1, 2] * rhs[1] + lhs[2, 2] * rhs[2]
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static Mat3 operator *(Mat3 lhs, Mat3 rhs)
        {
            return new Mat3(new[]
            {
          lhs[0][0] * rhs[0] + lhs[1][0] * rhs[1] + lhs[2][0] * rhs[2],
          lhs[0][1] * rhs[0] + lhs[1][1] * rhs[1] + lhs[2][1] * rhs[2],
          lhs[0][2] * rhs[0] + lhs[1][2] * rhs[1] + lhs[2][2] * rhs[2]
            });
        }

        public static Mat3 operator *(Mat3 lhs, float s)
        {
            return new Mat3(new[]
            {
                lhs[0]*s,
                lhs[1]*s,
                lhs[2]*s
            });
        }

        #endregion

        #region ToString support

        public override string ToString()
        {
            return String.Format(
                "[{0}, {1}, {2}; {3}, {4}, {5}; {6}, {7}, {8}]",
                this[0, 0], this[1, 0], this[2, 0],
                this[0, 1], this[1, 1], this[2, 1],
                this[0, 2], this[1, 2], this[2, 2]
            );
        }
        #endregion

        #region comparision
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
            if (obj.GetType() == typeof(Mat3))
            {
                var mat = (Mat3)obj;
                if (mat[0] == this[0] && mat[1] == this[1] && mat[2] == this[2])
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="m1">The first Matrix.</param>
        /// <param name="m2">The second Matrix.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Mat3 m1, Mat3 m2)
        {
            return m1.Equals(m2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="m1">The first Matrix.</param>
        /// <param name="m2">The second Matrix.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Mat3 m1, Mat3 m2)
        {
            return !m1.Equals(m2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this[0].GetHashCode() ^ this[1].GetHashCode() ^ this[2].GetHashCode();
        }
        #endregion

        /// <summary>
        /// The columms of the matrix.
        /// </summary>
        private Vec3[] _cols;
    }
}