﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

public partial class AuthUserRole
{
    /// <summary>
    /// 自增
    /// </summary>
    public int SeqNo { get; set; }

    /// <summary>
    /// 使用者帳號
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 關聯Auth_Role
    /// </summary>
    public string RoleId { get; set; }

    /// <summary>
    /// 新增員工
    /// </summary>
    public string AddUserId { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime AddTime { get; set; }
}