using System;

namespace AnyReadOnline.Models
{
    public interface IAudit
    {
        int InsBy { get; set; }
        DateTime InsDate { get; set; }
        int UpdBy { get; set; }
        DateTime UpdDate { get; set; }
        int UpdNo { get; set; }
    }
}