﻿namespace BITOJ.Core.Data.Queries
{
    using BITOJ.Core;

    /// <summary>
    /// 为查询用户信息提供数据。
    /// </summary>
    public sealed class UserQueryParameter
    {
        /// <summary>
        /// 获取或设置一个值，该值指示是否按照用户名进行查询。
        /// </summary>
        public bool QueryByUsername { get; set; }

        /// <summary>
        /// 当 QueryByUser 为 true 时，获取或设置查询用户名。
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否按照组织名称进行查询。
        /// </summary>
        public bool QueryByOrganization { get; set; }

        /// <summary>
        /// 当 QueryByOrganization 为 true 时，获取或设置组织名称。
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否按照用户权限集进行查询。
        /// </summary>
        public bool QueryByUsergroup { get; set; }

        /// <summary>
        /// 当 QueryByUsergroup 为 true 时，获取或设置要查询的用户权限集。 
        /// </summary>
        public UserGroup UserGroup { get; set; }

        /// <summary>
        /// 初始化 UserQueryParameter 类的新实例。
        /// </summary>
        public UserQueryParameter()
        {
            QueryByUsername = false;
            Username = string.Empty;

            QueryByOrganization = false;
            Organization = string.Empty;

            QueryByUsergroup = false;
            UserGroup = UserGroup.Administrators;
        }
    }
}
