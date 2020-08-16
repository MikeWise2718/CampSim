using System;
using UnityEngine;

namespace Aiskwk.Map
{
    public struct LineSegment2xz
    {

        // stole this from here: https://stackoverflow.com/a/37406831/3458744

        //public Vector3 From { get; }
        //public Vector3 Toto { get; }

        //public LineSegment2xz(Vector3 @from, Vector3 toto)
        //{
        //    From = @from;
        //    Toto = toto;
        //}

        public Vector3 from;
        public Vector3 toto;
        public Vector3 delta;

        public LineSegment2xz(Vector3 from, Vector3 toto)
        {
            this.from = from;
            this.toto = toto;
            this.delta = toto-from;
        }


        //public Vector3 Delta => new Vector3(toto.x - from.x, toto.y - from.y, toto.z - from.z);

        /// <summary>
        /// Attempt to intersect two line segments.
        /// </summary>
        /// <remarks>
        /// Even if the line segments do not intersect, <paramref name="t"/> and <paramref name="u"/> will be set.
        /// If the lines are parallel, <paramref name="t"/> and <paramref name="u"/> are set to <see cref="float.NaN"/>.
        /// </remarks>
        /// <param name="other">The line to attempt intersection of this line with.</param>
        /// <param name="intersectionPoint">The point of intersection if within the line segments, or empty..</param>
        /// <param name="t">The distance along this line at which intersection would occur, or NaN if lines are collinear/parallel.</param>
        /// <param name="u">The distance along the other line at which intersection would occur, or NaN if lines are collinear/parallel.</param>
        /// <returns><c>true</c> if the line segments intersect, otherwise <c>false</c>.</returns>
        public (bool itdid,Vector3 intersectionPoint, float t,float u) TryIntersect(LineSegment2xz other)
        {
            var p = from;
            var q = other.from;
            var qmp = q - p;
            //var r = Delta;
            //var s = other.Delta;
            var r = delta;
            var s = other.delta;

            // t = (q - p) × s / (r × s)
            // u = (q - p) × r / (r × s)

            //var denom = Fake2DCross(r, s);
            var denom = r.x*s.z - r.z*s.x;
            var intersectionPoint = Vector3.zero;
            var t = 0f;
            var u = 0f;

            if (denom == 0)
            {
                // lines are collinear or parallel
                t = float.NaN;
                u = float.NaN;
                return (false,intersectionPoint,t,u);
            }

            //var tNumer = Fake2DCross(q - p, s);
            //var uNumer = Fake2DCross(q - p, r);
            //var tNumer = qmp.x*s.z - qmp.z*s.x;
            //var uNumer = qmp.x*r.z - qmp.z*r.x;
            //var tNumer = Fake2DCross(qmp, s);
            //var uNumer = Fake2DCross(qmp, r);

            t = (qmp.x*s.z - qmp.z*s.x) / denom;
            u = (qmp.x*r.z - qmp.z*r.x) / denom;

            if (t < 0 || t > 1 || u < 0 || u > 1)
            {
                // line segments do not intersect within their ranges
                return (false, intersectionPoint, t, u);
            }

            intersectionPoint = p + r*t;
            return (true, intersectionPoint, t, u); 
        }

        private static float Fake2DCross(Vector3 a, Vector3 b)
        {
            return a.x * b.z - a.z * b.x;
        }
    }
}