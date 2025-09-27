using migApp.Shared.MsgBus.Enums;

namespace migApp.Shared.MsgBus.Dtos.Vendors
{
    public class VendorEventDto<T> : BaseEventDto<VendorEventDto<T>>
    {
        public VendorEvents EventType { get; set; }
        public required T Data { get; set; }
    }
}
