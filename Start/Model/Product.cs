using System;
using System.Drawing;

namespace HYProject.Model
{
    [Serializable]
    public class Product
    {
        public Image ProductImage;
        public DateTime CreateTime;
        public string ProductName;
    }
}