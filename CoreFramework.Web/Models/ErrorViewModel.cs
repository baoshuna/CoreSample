using System;

namespace CoreFramework.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        /// <summary>代表一个只读的属性</summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>代表一个方法,直接return</summary>
        public bool A() => !string.IsNullOrEmpty(RequestId);

        //lambda版属性
        //public string B { get => b; set => b = value; }
    }
}