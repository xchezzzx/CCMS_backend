namespace ASPNETCore.Interfaces.Common
{
    public interface IFillable
    {
        int StatusId { get; set; }
        int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
