using System;

namespace CoreFramework.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        /// <summary>����һ��ֻ��������</summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>����һ������,ֱ��return</summary>
        public bool A() => !string.IsNullOrEmpty(RequestId);

        //lambda������
        //public string B { get => b; set => b = value; }
    }
}