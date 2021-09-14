using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYProject.Model
{
    [Serializable]
    public struct RobotPoint
    {
        /// <summary>
        /// X
        /// </summary>
        public double X;
        /// <summary>
        /// Y
        /// </summary>
        public double Y;
        /// <summary>
        /// 角度
        /// </summary>
        public double U;
    }
}
