using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelDesktopApp.Common
{
    public enum ImagePartType
    {
        /// <summary>
        /// 宽X2
        /// </summary>
        AB = 1,
        /// <summary>
        /// 宽磁贴X3
        /// </summary>
        ABC,
        /// <summary>
        /// 宽X1 + 小X4
        /// </summary>
        Ab4,
        /// <summary>
        /// 宽磁贴X2 + 小X4
        /// </summary>
        ABc4,
        /// <summary>
        /// 宽X3 + 小X4
        /// </summary>
        ABCd4,
        /// <summary>
        /// 中X4 + 小X3
        /// </summary>
        Seven
    }
}
