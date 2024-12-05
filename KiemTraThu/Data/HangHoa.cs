using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KiemTraThu.Data;

public partial class HangHoa
{
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(100, 5000)]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^(http(s)?:\/\/)?.*\.(jpg|png|gif|tiff)$")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
