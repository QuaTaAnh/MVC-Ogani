using System;
using System.Collections.Generic;

namespace WebNo3.Models;

public partial class TUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte? LoaiUser { get; set; }

    public virtual ICollection<TKhachHang> TKhachHangs { get; } = new List<TKhachHang>();

    public virtual ICollection<TNhanVien> TNhanViens { get; } = new List<TNhanVien>();
}
